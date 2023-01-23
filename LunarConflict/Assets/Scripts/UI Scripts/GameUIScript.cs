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

    [Header("-----------------------------------------------------")]
    [Header("Theme Section")]

    [SerializeField] private Image topPanelTheme;
    [SerializeField] private Image queuePanelTheme;
    [SerializeField] private Image downPanelTheme;
    [SerializeField] private Image mapPanelTheme;
    [SerializeField] private Image[] buttonTheme = new Image[8];
    [SerializeField] private Image entitiesPanelTheme;
    [SerializeField] private Image statsHeaderTheme;
    [SerializeField] private Image statsPanelTheme;
    [SerializeField] private Image descriptionHeaderTheme;
    [SerializeField] private Image descriptionPanelTheme;
    [SerializeField] private Image settingsPanelTheme;
    [SerializeField] private Image settingsInnerPanelTheme;
    [SerializeField] private Image upgradePanelTheme;
    [SerializeField] private Image upgradeInnerPanelTheme;

    private Color[] colorsUSA = { new Color(1f, 1f, 1f),
                                  new Color(0.76f, 0.76f, 0.76f),
                                  new Color(0.91f, 0.91f, 0.91f)};

    private Color[] colorsSoviet = { new Color(0.68f, 0.13f, 0.2f),
                                     new Color(1f, 0.62f, 0.13f),
                                     new Color(0.55f, 0.16f, 0.21f),
                                     new Color(0.84f, 0.52f, 0.11f)};

    [Header("-----------------------------------------------------")]

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
            topPanelTheme.color = colorsUSA[0];
            queuePanelTheme.color = colorsUSA[0];
            downPanelTheme.color = colorsUSA[1];
            mapPanelTheme.color = colorsUSA[2];
            for(int i = 0; i < 8; i++)
                buttonTheme[i].color = colorsUSA[0];
            entitiesPanelTheme.color = colorsUSA[2];
            statsHeaderTheme.color = colorsUSA[0];
            statsPanelTheme.color = colorsUSA[2];
            descriptionHeaderTheme.color = colorsUSA[0];
            descriptionPanelTheme.color = colorsUSA[2];
            settingsPanelTheme.color = colorsUSA[1];
            settingsInnerPanelTheme.color = colorsUSA[2];
            upgradePanelTheme.color = colorsUSA[1];
            upgradeInnerPanelTheme.color = colorsUSA[2];
        }
        else
        {
            topPanelTheme.color = colorsSoviet[0];
            queuePanelTheme.color = colorsSoviet[1];
            downPanelTheme.color = colorsSoviet[2];
            mapPanelTheme.color = colorsSoviet[1];
            for(int i = 0; i < 8; i++)
                buttonTheme[i].color = colorsSoviet[1];
            entitiesPanelTheme.color = colorsSoviet[3];;
            statsHeaderTheme.color = colorsSoviet[1];
            statsPanelTheme.color = colorsSoviet[3];;
            descriptionHeaderTheme.color = colorsSoviet[1];
            descriptionPanelTheme.color = colorsSoviet[3];;
            settingsPanelTheme.color = colorsSoviet[2];
            settingsInnerPanelTheme.color = colorsSoviet[3];;
            upgradePanelTheme.color = colorsSoviet[2];
            upgradeInnerPanelTheme.color = colorsSoviet[3];;
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
