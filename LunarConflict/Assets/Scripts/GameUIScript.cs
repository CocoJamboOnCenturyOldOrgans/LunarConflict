using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIScript : MonoBehaviour
{
    //UI SECTION SHOP BUTTONS
    [SerializeField] private Button UnitsButton;
    [SerializeField] private Button BaseButton;
    [SerializeField] private Button SpecialButton;
    [SerializeField] private Button SettingsButton;

    //UI SECTIONS
    [SerializeField] private GameObject UnitsPanel;
    [SerializeField] private GameObject BasePanel;
    [SerializeField] private GameObject SpecialPanel;
    [SerializeField] private GameObject StatsPanel;
    [SerializeField] private GameObject DescriptionPanel;
    [SerializeField] private GameObject SettingsPanel;

    //UI CERTAIN ELEMENTS
    public Slider Attack;
    public Slider FireRate;
    public Slider HP;
    public Slider Speed;
    public Text AttackValue;
    public Text FireRateValue;
    public Text HPValue;
    public Text SpeedValue;
    public Text UnitName;
    public Text BuildingName;
    public Text Description;

<<<<<<< Updated upstream
    public Slider VolumeSlider;
    public Text VolumeValue;
=======
    public Slider MusicSlider;
    public Text MusicValue;
    public Slider EffectsSlider;
    public Text EffectsValue;
>>>>>>> Stashed changes

    public Sprite Astronaut_Can_Buy;
    public Sprite Astronaut_Cannot_Buy;
    public Sprite Rover_Can_Buy;
    public Sprite Rover_Cannot_Buy;
    public Sprite CanBuy;
    public Sprite CannotBuy;

    private PlayerScript _playerScript;
    private Button UnitsButton1;
    private Button UnitsButton2;
    private Button UnitsButton3;
    private Button UnitsButton4;
    private Image UnitsImage1;
    private Image UnitsImage2;
    private Image UnitsImage3;
    private Image UnitsImage4;

<<<<<<< Updated upstream
=======
    private AudioSource BackgroundMusic;
    private AudioSource _sfxAudioSource;

>>>>>>> Stashed changes
    [SerializeField] private Text Astronaut_Price;
    [SerializeField] private Text Rover_Price;
    [SerializeField] private Text EntityC_Price;
    [SerializeField] private Text EntityD_Price;
    //private Button BaseButton1;
    //private Button BaseButton2;

    //TEMP
    public bool changed = false;

    [SerializeField] private Text Budget;

    void Start()
    {
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();

        _playerScript = GameObject.Find("GameLogic").GetComponent<PlayerScript>();
        UnitsButton1 = GameObject.Find("Unit1Image").GetComponent<Button>();
        UnitsButton2 = GameObject.Find("Unit2Image").GetComponent<Button>();
        UnitsButton3 = GameObject.Find("Unit3Image").GetComponent<Button>();
        UnitsButton4 = GameObject.Find("Unit4Image").GetComponent<Button>();

        UnitsImage1 = GameObject.Find("Unit1Image").GetComponent<Image>();
        UnitsImage2 = GameObject.Find("Unit2Image").GetComponent<Image>();
        UnitsImage3 = GameObject.Find("Unit3Image").GetComponent<Image>();
        UnitsImage4 = GameObject.Find("Unit4Image").GetComponent<Image>();

        Astronaut_Price = GameObject.Find("Unit1Price").GetComponent<Text>();
        Rover_Price = GameObject.Find("Unit2Price").GetComponent<Text>();
        EntityC_Price = GameObject.Find("Unit3Price").GetComponent<Text>();
        EntityD_Price = GameObject.Find("Unit4Price").GetComponent<Text>();

        Astronaut_Can_Buy = Settings_Script.Astronaut_Shop_Positive;
        Astronaut_Cannot_Buy = Settings_Script.Astronaut_Shop_Negative;
        Rover_Can_Buy = Settings_Script.Rover_Shop_Positive;
        Rover_Cannot_Buy = Settings_Script.Rover_Shop_Negative;

    //Those Making Problems!
    //BaseButton1 = GameObject.Find("Unit1BaseImage").GetComponent<Button>();
    //BaseButton2 = GameObject.Find("Unit2BaseImage").GetComponent<Button>();
}
    
    void Update()
    {
        if(changed == true)
        {
            Astronaut_Can_Buy = Settings_Script.Astronaut_Shop_Positive;
            Astronaut_Cannot_Buy = Settings_Script.Astronaut_Shop_Negative;
            Rover_Can_Buy = Settings_Script.Rover_Shop_Positive;
            Rover_Cannot_Buy = Settings_Script.Rover_Shop_Negative;
            Astronaut_Price.text = "50" + Settings_Script.UI_Money_Mark;
            Rover_Price.text = "100" + Settings_Script.UI_Money_Mark;
            EntityC_Price.text = "200" + Settings_Script.UI_Money_Mark;
            EntityD_Price.text = "350" + Settings_Script.UI_Money_Mark;
            changed = false;
        }

        //Testing of locking feature - fix in next version/final release
        if (_playerScript.money < 50)
        {
            UnitsButton1.enabled = false;
            UnitsImage1.sprite = Astronaut_Cannot_Buy;
            UnitsButton2.enabled = false;
            UnitsImage2.sprite = Rover_Cannot_Buy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;

            Astronaut_Price.color = Color.red;
            Rover_Price.color = Color.red;
            EntityC_Price.color = Color.red;
            EntityD_Price.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 50 && _playerScript.money < 100)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = Astronaut_Can_Buy;
            UnitsButton2.enabled = false;
            UnitsImage2.sprite = Rover_Cannot_Buy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;

            Astronaut_Price.color = Color.green;
            Rover_Price.color = Color.red;
            EntityC_Price.color = Color.red;
            EntityD_Price.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 100 && _playerScript.money < 200)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = Astronaut_Can_Buy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = Rover_Can_Buy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;

            Astronaut_Price.color = Color.green;
            Rover_Price.color = Color.green;
            EntityC_Price.color = Color.red;
            EntityD_Price.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 200 && _playerScript.money < 350)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = Astronaut_Can_Buy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = Rover_Can_Buy;
            UnitsButton3.enabled = true;
            UnitsImage3.sprite = CanBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;

            Astronaut_Price.color = Color.green;
            Rover_Price.color = Color.green;
            EntityC_Price.color = Color.green;
            EntityD_Price.color = Color.red;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = Astronaut_Can_Buy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = Rover_Can_Buy;
            UnitsButton3.enabled = true;
            UnitsImage3.sprite = CanBuy;
            UnitsButton4.enabled = true;
            UnitsImage4.sprite = CanBuy;

            Astronaut_Price.color = Color.green;
            Rover_Price.color = Color.green;
            EntityC_Price.color = Color.green;
            EntityD_Price.color = Color.green;
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
        UnitsPanel.gameObject.SetActive(true);
        BasePanel.gameObject.SetActive(false);
        SpecialPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(true);
        DescriptionPanel.gameObject.SetActive(false);
    }

    public void ChooseBasePanel()
    {
        UnitsPanel.gameObject.SetActive(false);
        BasePanel.gameObject.SetActive(true);
        SpecialPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(false);
        DescriptionPanel.gameObject.SetActive(true);
    }

    public void ChooseSpecialPanel()
    {
        UnitsPanel.gameObject.SetActive(false);
        BasePanel.gameObject.SetActive(false);
        SpecialPanel.gameObject.SetActive(true);
        StatsPanel.gameObject.SetActive(false);
        DescriptionPanel.gameObject.SetActive(false);
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
        SettingsPanel.SetActive(true);
<<<<<<< Updated upstream
        VolumeSlider.value = Settings_Script.volume;
        VolumeValue.text = VolumeSlider.value.ToString() + "%";
    }

    public void ChangeVolume()
    {
        VolumeValue.text = VolumeSlider.value.ToString() + "%";
        Settings_Script.volume = (int)VolumeSlider.value;
=======
        MusicSlider.value = Settings_Script.music;
        MusicValue.text = MusicSlider.value.ToString() + "%";
        EffectsSlider.value = Settings_Script.effects;
        EffectsValue.text = EffectsSlider.value.ToString() + "%";
    }

    public void ChangeMusic()
    {
        MusicValue.text = MusicSlider.value.ToString() + "%";
        Settings_Script.music = MusicSlider.value;
        BackgroundMusic.volume = Settings_Script.music / 100;
    }
    public void ChangeEffects()
    {
        EffectsValue.text = EffectsSlider.value.ToString() + "%";
        Settings_Script.effects = EffectsSlider.value;
        _sfxAudioSource.volume = Settings_Script.effects / 100;
>>>>>>> Stashed changes
    }

    public void CloseSettings()
    {
        SettingsPanel.SetActive(false);
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
