using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    
    private void Start()
    {
        SettingsScript.SideIsSoviet = true;
        //UnitsStatistics.StatsModifier = _difficultyStatsModificators[1];

        musicSlider.value = SettingsScript.Music;
        musicValue.text = SliderHelperScript.ConvertToPercentageValue(musicSlider.value);
        effectsSlider.value = SettingsScript.Effects;
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
    public void ChangeSide(bool isSideSoviet) => SettingsScript.SideIsSoviet = isSideSoviet;

    //0 - Easy, 1 - Normal, 2 - Hard, 3 - Impossible
    public void ChangeDifficulty(int diff) => Debug.Log("Changed StatsModifer"); //UnitsStatistics.StatsModifier = _difficultyStatsModificators[diff];


        public void BeginGame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    
    public void ChangeMusic()
    {
        musicValue.text = SliderHelperScript.ConvertToPercentageValue(musicSlider.value);
        SettingsScript.Music = musicSlider.value;
    }

    public void ChangeEffects()
    {
        effectsValue.text = SliderHelperScript.ConvertToPercentageValue(effectsSlider.value);
        SettingsScript.Effects = effectsSlider.value;
    }

    public void ExitFunction()
    {
        Application.Quit();
    }
}
