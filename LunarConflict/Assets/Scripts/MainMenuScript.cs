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
    public void ChangeDifficulty(int diff) => Debug.Log("Changed StatsModifer"); //UnitsStatistics.StatsModifier = _difficultyStatsModificators[diff];


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

    public void ExitFunction()
    {
        PlayerPrefs.Save();
        Application.Quit();
    }
}
