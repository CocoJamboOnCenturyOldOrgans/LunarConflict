using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIScript : MonoBehaviour
{
    private enum Units
    {
        Astronaut,
        Rover,
        Tank,
        EntityD
    }
    [SerializeField] private GameObject settingsPanel;
    //UI CERTAIN ELEMENTS
    public Slider attack;
    public Slider fireRate;
    public Slider hp;
    public Slider speed;
    public Text attackValue;
    public Text fireRateValue;
    public Text hpValue;
    public Text speedValue;
    public Text unitName;
    public Text buildingName;
    public Text description;

    public Slider baseHealthSlider;
    public Text baseHealthValue;
        
    public Slider musicSlider;
    public Text musicValue;
    public Slider effectsSlider;
    public Text effectsValue;

    public Sprite astronautCanBuy;
    public Sprite astronautCannotBuy;
    public Sprite roverCanBuy;
    public Sprite roverCannotBuy;
    public Sprite canBuy;
    public Sprite cannotBuy;

    private PlayerScript _playerScript;
    [SerializeField] private GameObject unitsTabField;
    private List<Button> _unitsButtons;
    private List<Image> _unitsImages;
    private List<Text> _unitsPrice;

    private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;
    
    //private Button BaseButton1;
    //private Button BaseButton2;

    //TEMP
    public bool changed = false;

    [SerializeField] private Text budget;

    void Start()
    {
        _backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();

        musicSlider.value = SettingsScript.Music;
        musicValue.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        effectsSlider.value = SettingsScript.Effects;
        effectsValue.text = Mathf.RoundToInt(effectsSlider.value * 100) + "%";

        _playerScript = GameObject.Find("GameLogic").GetComponent<PlayerScript>();

        _unitsButtons = new List<Button>();
        _unitsImages = new List<Image>();
        _unitsPrice = new List<Text>();
        
        foreach (Transform child in unitsTabField.transform)
        {
            if (child.TryGetComponent(out Button button))
            {
                _unitsButtons.Add(button);
                if(child.TryGetComponent(out Image image))
                {
                    _unitsImages.Add(image);
                }
            }
            else if(child.TryGetComponent(out Text text))
            {
                _unitsPrice.Add(text);
            }
        }
        
        astronautCanBuy = SettingsScript.AstronautShopPositive;
        astronautCannotBuy = SettingsScript.AstronautShopNegative;
        roverCanBuy = SettingsScript.RoverShopPositive;
        roverCannotBuy = SettingsScript.RoverShopNegative;

    //Those Making Problems!
    //BaseButton1 = GameObject.Find("Unit1BaseImage").GetComponent<Button>();
    //BaseButton2 = GameObject.Find("Unit2BaseImage").GetComponent<Button>();
}
    
    void Update()
    {
        #warning This is temporary to view UI changes on different sides.
        if(changed)
        {
            astronautCanBuy = SettingsScript.AstronautShopPositive;
            astronautCannotBuy = SettingsScript.AstronautShopNegative;
            roverCanBuy = SettingsScript.RoverShopPositive;
            roverCannotBuy = SettingsScript.RoverShopNegative;
            _unitsPrice[(int)Units.Astronaut].text = "50" + SettingsScript.UIMoneyMark;
            _unitsPrice[(int)Units.Rover].text = "100" + SettingsScript.UIMoneyMark;
            _unitsPrice[(int)Units.Tank].text = "200" + SettingsScript.UIMoneyMark;
            _unitsPrice[(int)Units.EntityD].text = "350" + SettingsScript.UIMoneyMark;
            changed = false;
        }
        
        _unitsButtons[(int)Units.Astronaut].enabled = _playerScript.money >= 50;
        _unitsImages[(int)Units.Astronaut].sprite = _playerScript.money >= 50 ? astronautCanBuy : astronautCannotBuy;
        _unitsButtons[(int)Units.Rover].enabled = _playerScript.money >= 100;
        _unitsImages[(int)Units.Rover].sprite = _playerScript.money >= 100 ? roverCanBuy : roverCannotBuy;
        _unitsButtons[(int)Units.Tank].enabled = _playerScript.money >= 200;
        _unitsImages[(int)Units.Tank].sprite = _playerScript.money >= 200 ? canBuy : cannotBuy;
        _unitsButtons[(int)Units.EntityD].enabled = _playerScript.money >= 350;
        _unitsImages[(int)Units.EntityD].sprite = _playerScript.money >= 350 ? canBuy : cannotBuy;
        _unitsPrice[(int)Units.Astronaut].color = _playerScript.money >= 50 ? Color.green : Color.red;
        _unitsPrice[(int)Units.Rover].color = _playerScript.money >= 100 ? Color.green : Color.red;
        _unitsPrice[(int)Units.Tank].color = _playerScript.money >= 200 ? Color.green : Color.red;
        _unitsPrice[(int)Units.EntityD].color = _playerScript.money >= 350 ? Color.green : Color.red;
    }

    //##################################################################
    //################ Panels Buttons Section ##########################
    //##################################################################
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnBaseHealthChanged() => baseHealthValue.text = baseHealthSlider.value.ToString();
    public void UpdateMoney(int money) => budget.text = money + SettingsScript.UIMoneyMark;

    public void ChangeMusic()
    {
        musicValue.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        SettingsScript.Music = musicSlider.value;
        _backgroundMusic.volume = SettingsScript.Music;
    }
    public void ChangeEffects()
    {
        effectsValue.text = Mathf.RoundToInt(effectsSlider.value * 100) + "%";
        SettingsScript.Effects = effectsSlider.value;
        _sfxAudioSource.volume = SettingsScript.Effects;
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
