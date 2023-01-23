using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static SettingsScript;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject upgradePanel;

    public BottomPanelObjectScript bottomPanel;

    public Slider baseHealthSlider;
    public Text baseHealthValue;
    
    [SerializeField] private Dropdown resolutionSelector;
    [SerializeField] private Toggle fullscreen;
    [SerializeField] private Button defaultFocus;

    [SerializeField] private Image topPanelTheme;
    [SerializeField] private Image queuePanelTheme;
    [SerializeField] private Image downPanelTheme;
    [SerializeField] private Image mapPanelTheme;
    [SerializeField] private Image[] buttonTheme = new Image[3];
    [SerializeField] private Image entitiesPanelTheme;
    [SerializeField] private Image statsHeaderTheme;
    [SerializeField] private Image statsPanelTheme;
    [SerializeField] private Image descriptionHeaderTheme;
    [SerializeField] private Image descriptionPanelTheme;
    [SerializeField] private Image settingsPanelTheme;
    [SerializeField] private Image settingsInnerPanelTheme;
    [SerializeField] private Image upgradePanelTheme;
    [SerializeField] private Image upgradeInnerPanelTheme;

    public Slider musicSlider;
    public Text musicValue;
    public Slider effectsSlider;
    public Text effectsValue;

    private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;
    
    //private Button BaseButton1;
    //private Button BaseButton2;

    [SerializeField] private Text budget;

    void Start()
    {
        _backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);;
        musicValue.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);;
        effectsValue.text = Mathf.RoundToInt(effectsSlider.value * 100) + "%";
        
        bottomPanel = GetComponent<BottomPanelObjectScript>();

        ChangeGameTheme();

        // This is a safety mechanism to not throw ArgumentNullException
        // during testing inside Unity Editor
        if (!Application.isEditor)
        {
            resolutionSelector.AddOptions(
                Resolutions
                    .Select(res => res.width + " x " + res.height)
                    .ToList());
            var curRes = new Resolution
            {
                width = Screen.width,
                height = Screen.height,
                refreshRate = Resolutions[0].refreshRate
            };
            resolutionSelector.value = Resolutions.IndexOf(curRes);

            fullscreen.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;
        }

        // SET TIME SCALE TO NORMAL ON EACH SCENE CHANGE
        SceneManager.activeSceneChanged += (scene1, scene2) => Time.timeScale = 1.0f;;
        defaultFocus.Select();
    }
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShowUpgrade()
    {
        upgradePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ChangeGameTheme()
    {
        if(SettingsScript.Faction == PlayerFaction.USA)
        {
            topPanelTheme.color = new Color(1f, 1f, 1f);
            queuePanelTheme.color = new Color(1f, 1f, 1f);
            downPanelTheme.color = new Color(0.76f, 0.76f, 0.76f);
            mapPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
            buttonTheme[0].color = new Color(1f, 1f, 1f);
            buttonTheme[1].color = new Color(1f, 1f, 1f);
            buttonTheme[2].color = new Color(1f, 1f, 1f);
            entitiesPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
            statsHeaderTheme.color = new Color(1f, 1f, 1f);
            statsPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
            descriptionHeaderTheme.color = new Color(1f, 1f, 1f);
            descriptionPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
            settingsPanelTheme.color = new Color(0.76f, 0.76f, 0.76f);
            settingsInnerPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
            upgradePanelTheme.color = new Color(0.76f, 0.76f, 0.76f);
            upgradeInnerPanelTheme.color = new Color(0.91f, 0.91f, 0.91f);
        }
        else
        {
            topPanelTheme.color = new Color(0.68f, 0.13f, 0.2f);
            queuePanelTheme.color = new Color(1f, 0.62f, 0.13f);
            downPanelTheme.color = new Color(0.55f, 0.16f, 0.21f);
            mapPanelTheme.color = new Color(1f, 0.62f, 0.13f);
            buttonTheme[0].color = new Color(1f, 0.62f, 0.13f);
            buttonTheme[1].color = new Color(1f, 0.62f, 0.13f);
            buttonTheme[2].color = new Color(1f, 0.62f, 0.13f);
            entitiesPanelTheme.color = new Color(0.84f, 0.52f, 0.11f);
            statsHeaderTheme.color = new Color(1f, 0.62f, 0.13f);
            statsPanelTheme.color = new Color(0.84f, 0.52f, 0.11f);
            descriptionHeaderTheme.color = new Color(1f, 0.62f, 0.13f);
            descriptionPanelTheme.color = new Color(0.84f, 0.52f, 0.11f);
            settingsPanelTheme.color = new Color(0.55f, 0.16f, 0.21f);
            settingsInnerPanelTheme.color = new Color(0.84f, 0.52f, 0.11f);
            upgradePanelTheme.color = new Color(0.55f, 0.16f, 0.21f);
            upgradeInnerPanelTheme.color = new Color(0.84f, 0.52f, 0.11f);
        }
    }

    public void OnBaseHealthChanged() => baseHealthValue.text = baseHealthSlider.value.ToString();

    public void UpdateMoney(int money)
    {
        budget.text = money + UIMoneyMark;
    }

    public void ChangeMusic()
    {
        musicValue.text = Mathf.RoundToInt(musicSlider.value * 100) + "%";
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
        _backgroundMusic.volume = musicSlider.value;
    }
    public void ChangeEffects()
    {
        effectsValue.text = Mathf.RoundToInt(effectsSlider.value * 100) + "%";
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
        _sfxAudioSource.volume = effectsSlider.value;
    }
    
    public void ChangeResolution()
    {
        var chosenResolution = Resolutions[resolutionSelector.value];
        Screen.SetResolution(
            chosenResolution.width,
            chosenResolution.height,
            fullscreen.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void CloseUpgrade()
    {
        upgradePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void GoToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void ExitGame()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
