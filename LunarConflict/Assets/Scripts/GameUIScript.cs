using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIScript : MonoBehaviour
{
    //UI SECTION SHOP BUTTONS
    [SerializeField] private Button unitsButton;
    [SerializeField] private Button baseButton;
    [SerializeField] private Button specialButton;
    [SerializeField] private Button settingsButton;

    //UI SECTIONS
    [SerializeField] private GameObject unitsPanel;
    [SerializeField] private GameObject basePanel;
    [SerializeField] private GameObject specialPanel;
    [SerializeField] private GameObject statsPanel;
    [SerializeField] private GameObject descriptionPanel;
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
    private Button _unitsButton1;
    private Button _unitsButton2;
    private Button _unitsButton3;
    private Button _unitsButton4;
    private Image _unitsImage1;
    private Image _unitsImage2;
    private Image _unitsImage3;
    private Image _unitsImage4;

    private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;

    [SerializeField] private Text astronautPrice;
    [SerializeField] private Text roverPrice;
    [SerializeField] private Text entityCPrice;
    [SerializeField] private Text entityDPrice;
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
        _unitsButton1 = GameObject.Find("Unit1Image").GetComponent<Button>();
        _unitsButton2 = GameObject.Find("Unit2Image").GetComponent<Button>();
        _unitsButton3 = GameObject.Find("Unit3Image").GetComponent<Button>();
        _unitsButton4 = GameObject.Find("Unit4Image").GetComponent<Button>();

        _unitsImage1 = GameObject.Find("Unit1Image").GetComponent<Image>();
        _unitsImage2 = GameObject.Find("Unit2Image").GetComponent<Image>();
        _unitsImage3 = GameObject.Find("Unit3Image").GetComponent<Image>();
        _unitsImage4 = GameObject.Find("Unit4Image").GetComponent<Image>();

        astronautPrice = GameObject.Find("Unit1Price").GetComponent<Text>();
        roverPrice = GameObject.Find("Unit2Price").GetComponent<Text>();
        entityCPrice = GameObject.Find("Unit3Price").GetComponent<Text>();
        entityDPrice = GameObject.Find("Unit4Price").GetComponent<Text>();

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
        if(changed)
        {
            astronautCanBuy = SettingsScript.AstronautShopPositive;
            astronautCannotBuy = SettingsScript.AstronautShopNegative;
            roverCanBuy = SettingsScript.RoverShopPositive;
            roverCannotBuy = SettingsScript.RoverShopNegative;
            astronautPrice.text = "50" + SettingsScript.UIMoneyMark;
            roverPrice.text = "100" + SettingsScript.UIMoneyMark;
            entityCPrice.text = "200" + SettingsScript.UIMoneyMark;
            entityDPrice.text = "350" + SettingsScript.UIMoneyMark;
            changed = false;
        }

        //Testing of locking feature - fix in next version/final release
        if (_playerScript.money < 50)
        {
            _unitsButton1.enabled = false;
            _unitsImage1.sprite = astronautCannotBuy;
            _unitsButton2.enabled = false;
            _unitsImage2.sprite = roverCannotBuy;
            _unitsButton3.enabled = false;
            _unitsImage3.sprite = cannotBuy;
            _unitsButton4.enabled = false;
            _unitsImage4.sprite = cannotBuy;

            astronautPrice.color = Color.red;
            roverPrice.color = Color.red;
            entityCPrice.color = Color.red;
            entityDPrice.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 50 && _playerScript.money < 100)
        {
            _unitsButton1.enabled = true;
            _unitsImage1.sprite = astronautCanBuy;
            _unitsButton2.enabled = false;
            _unitsImage2.sprite = roverCannotBuy;
            _unitsButton3.enabled = false;
            _unitsImage3.sprite = cannotBuy;
            _unitsButton4.enabled = false;
            _unitsImage4.sprite = cannotBuy;

            astronautPrice.color = Color.green;
            roverPrice.color = Color.red;
            entityCPrice.color = Color.red;
            entityDPrice.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money is >= 100 and < 200)
        {
            _unitsButton1.enabled = true;
            _unitsImage1.sprite = astronautCanBuy;
            _unitsButton2.enabled = true;
            _unitsImage2.sprite = roverCanBuy;
            _unitsButton3.enabled = false;
            _unitsImage3.sprite = cannotBuy;
            _unitsButton4.enabled = false;
            _unitsImage4.sprite = cannotBuy;

            astronautPrice.color = Color.green;
            roverPrice.color = Color.green;
            entityCPrice.color = Color.red;
            entityDPrice.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money is >= 200 and < 350)
        {
            _unitsButton1.enabled = true;
            _unitsImage1.sprite = astronautCanBuy;
            _unitsButton2.enabled = true;
            _unitsImage2.sprite = roverCanBuy;
            _unitsButton3.enabled = true;
            _unitsImage3.sprite = canBuy;
            _unitsButton4.enabled = false;
            _unitsImage4.sprite = cannotBuy;

            astronautPrice.color = Color.green;
            roverPrice.color = Color.green;
            entityCPrice.color = Color.green;
            entityDPrice.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else
        {
            _unitsButton1.enabled = true;
            _unitsImage1.sprite = astronautCanBuy;
            _unitsButton2.enabled = true;
            _unitsImage2.sprite = roverCanBuy;
            _unitsButton3.enabled = true;
            _unitsImage3.sprite = canBuy;
            _unitsButton4.enabled = true;
            _unitsImage4.sprite = canBuy;

            astronautPrice.color = Color.green;
            roverPrice.color = Color.green;
            entityCPrice.color = Color.green;
            entityDPrice.color = Color.green;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = true;
        }
    }

    //##################################################################
    //################ Panels Buttons Section ##########################
    //##################################################################
    public void ChooseUnitsPanel()
    {
        unitsPanel.gameObject.SetActive(true);
        basePanel.gameObject.SetActive(false);
        specialPanel.gameObject.SetActive(false);
        statsPanel.gameObject.SetActive(true);
        descriptionPanel.gameObject.SetActive(false);
    }

    public void ChooseBasePanel()
    {
        unitsPanel.gameObject.SetActive(false);
        basePanel.gameObject.SetActive(true);
        specialPanel.gameObject.SetActive(false);
        statsPanel.gameObject.SetActive(false);
        descriptionPanel.gameObject.SetActive(true);
    }

    public void ChooseSpecialPanel()
    {
        unitsPanel.gameObject.SetActive(false);
        basePanel.gameObject.SetActive(false);
        specialPanel.gameObject.SetActive(true);
        statsPanel.gameObject.SetActive(false);
        descriptionPanel.gameObject.SetActive(false);
    }

    //##################################################################
    //########### Entities Spawns Buttons Section ######################
    //##################################################################

    //public void SpawnEntityC()
    //{
    //    Debug.Log("Created Entity C");
    //    _playerScript.money -= 200;
    //    Budget.text = _playerScript.money.ToString() + "$";
    //}

    //public void SpawnEntityD()
    //{
    //    Debug.Log("Created Entity D");
    //    _playerScript.money -= 350;
    //    Budget.text = _playerScript.money.ToString() + "$";
    //}

    //public void DoBaseA()
    //{
    //    Debug.Log("Base Upgraded by Module A");
    //    _playerScript.money -= 100;
    //}

    //public void DoBaseB()
    //{
    //    Debug.Log("Base Upgraded by Module B");
    //    _playerScript.money -= 350;
    //}

    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void OnBaseHealthChanged() => baseHealthValue.text = baseHealthSlider.value.ToString();

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
    }

    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
