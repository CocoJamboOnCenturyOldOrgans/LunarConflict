using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static SettingsScript;

public class MainMenuScript : MonoBehaviour
{
    private enum Panels
    {
        MainMenu,
        Game,
        Settings,
        Credits,
    }

    private readonly float[] _difficultyStatsModificators = { 0.7f, 1.0f, 1.5f, 2.0f };
    private List<Resolution> _resolutions;
    [SerializeField] private Dropdown resolutionSelector;
    [SerializeField] private Toggle fullscreen;

    public Text musicValue;
    public Slider musicSlider;
    public Text effectsValue;
    public Slider effectsSlider;

    [Header("Panels")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    [Header("Sound")]
    [SerializeField] private AudioSource mainMenuThemeAudioSource;
    
    private void Start()
    {
        _resolutions = Screen.resolutions.ToList();
        
        resolutionSelector.AddOptions(
            _resolutions
                .Select(res => res.width + " x " + res.height)
                .ToList());
        var curRes = new Resolution
        {
            width = Screen.width,
            height = Screen.height,
            refreshRate = _resolutions[0].refreshRate
        };
        Debug.Log(curRes.ToString());
        resolutionSelector.value = _resolutions.IndexOf(curRes);
        
        // You may ask, why I don't use Screen.currentResolution?
        // Because it's stupid.
        // Instead of giving you resolution of the game it gives you resolution of the screen
        // And also, I don't know why but Unity has a big problem with multi-monitor setup with different refresh rates
        // So, don't change this to Screen.currentResolution, or the game will set the lowest resolution possible.
        
        fullscreen.isOn = Screen.fullScreenMode == FullScreenMode.FullScreenWindow;

        Faction = PlayerFaction.None;
        //UnitsStatistics.StatsModifier = _difficultyStatsModificators[1];

        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);;
        musicValue.text = SliderHelperScript.ConvertToPercentageValue(musicSlider.value);
        effectsSlider.value = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);;
        effectsValue.text = SliderHelperScript.ConvertToPercentageValue(effectsSlider.value);
    }

    public void StartGameFunction() => ChangePanel(Panels.Game);
    public void SettingsFunction() => ChangePanel(Panels.Settings);
    public void CreditsFunction() => ChangePanel(Panels.Credits);
    public void BackFunction() => ChangePanel(Panels.MainMenu);

    private void ChangePanel(Panels panel)
    {
        mainMenuPanel.SetActive(Panels.MainMenu == panel);
        gamePanel.SetActive(Panels.Game == panel);
        settingsPanel.SetActive(Panels.Settings == panel);
        creditsPanel.SetActive(Panels.Credits == panel);
    }
    public void ChangeSide(int factionID) => Faction = (PlayerFaction)factionID;

    //0 - Easy, 1 - Normal, 2 - Hard, 3 - Impossible
    public void ChangeDifficulty(int diff) => Debug.Log("Changed StatsModifer"); 
    //UnitsStatistics.StatsModifier = _difficultyStatsModificators[diff];


    public void BeginGame()
    {
        if (Faction == PlayerFaction.None)
        {
            Debug.LogWarning("You haven't yet chosen a fraction or difficulty!");
            return;
        }
        
        SceneManager.LoadSceneAsync(1);
    }

    public void TempFunction()
    {
        SceneManager.LoadSceneAsync("EndGameScreen");
    }

    public void ChangeMusic()
    {
        musicValue.text = SliderHelperScript.ConvertToPercentageValue(musicSlider.value);
        mainMenuThemeAudioSource.volume = musicSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", musicSlider.value);
    }

    public void ChangeEffects()
    {
        effectsValue.text = SliderHelperScript.ConvertToPercentageValue(effectsSlider.value);
        PlayerPrefs.SetFloat("EffectsVolume", effectsSlider.value);
    }

    public void ChangeResolution()
    {
        var chosenResolution = _resolutions[resolutionSelector.value];
        Screen.SetResolution(
            chosenResolution.width,
            chosenResolution.height,
            fullscreen.isOn ? FullScreenMode.FullScreenWindow : FullScreenMode.Windowed);
    }

    public void ExitFunction()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
