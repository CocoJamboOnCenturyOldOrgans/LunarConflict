using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private enum Difficulties
    {
        Easy,
        Normal,
        Hard,
        Impossible,
    }

    private enum Sides
    {
        Usa,
        Soviet,
    }

    private enum Panels
    {
        MainMenu,
        Game,
        Settings,
        Credits,
    }

    private readonly float[] _difficultyStatsModificators = { 0.7f, 1.0f, 1.5f, 2.0f };

    private List<Button> _diffButtons;
    private List<Button> _sideButtons;

    [SerializeField] private Transform difficultiesSection;
    [SerializeField] private Transform sidesSection;

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
        _diffButtons = new List<Button>();
        _sideButtons = new List<Button>();
        foreach (Transform child in difficultiesSection)
        {
            if(child.TryGetComponent<Button>(out var button))
                _diffButtons.Add(button);
        }
        foreach (Transform child in sidesSection)
        {
            if(child.TryGetComponent<Button>(out var button))
                _sideButtons.Add(button);
        }
        
        SettingsScript.SideIsSoviet = true;
        UnitsStatistics.StatsModifier = _difficultyStatsModificators[1];

        musicSlider.value = SettingsScript.Music;
        musicValue.text = SliderHelperScript.ConvertToPercentageValue(musicSlider.value);
        effectsSlider.value = SettingsScript.Effects;
        effectsValue.text = SliderHelperScript.ConvertToPercentageValue(effectsSlider.value);
    }

    public void StartGame_Function() => ChangePanel(Panels.Game);
    public void Settings_Function() => ChangePanel(Panels.Settings);
    public void Credits_Function() => ChangePanel(Panels.Credits);
    public void Back_Function() => ChangePanel(Panels.MainMenu);

    private void ChangePanel(Panels panel)
    {
        mainMenuPanel.SetActive(Panels.MainMenu == panel);
        gamePanel.SetActive(Panels.Game == panel);
        settingsPanel.SetActive(Panels.Settings == panel);
        creditsPanel.SetActive(Panels.Credits == panel);
    }

    public void ChooseSovietSide() => ChangeSide(Sides.Soviet);
    public void ChooseUsaSide() => ChangeSide(Sides.Usa);

    private void ChangeSide(Sides side)
    {
        SettingsScript.SideIsSoviet = (int)side == 1;
        foreach (var btn in _sideButtons)
        {
            btn.interactable = !btn.name.Contains(side.ToString());
        }
    }

    public void EasyDifficulty() => ChangeDifficulty(Difficulties.Easy);
    public void NormalDifficulty() => ChangeDifficulty(Difficulties.Normal);
    public void HardDifficulty() => ChangeDifficulty(Difficulties.Hard);
    public void ImpossibleDifficulty() => ChangeDifficulty(Difficulties.Impossible);

    private void ChangeDifficulty(Difficulties diff)
    {
        UnitsStatistics.StatsModifier = _difficultyStatsModificators[(byte)diff];
        foreach (var btn in _diffButtons)
        {
            btn.interactable = !btn.name.Contains(diff.ToString());
        }
    }
    
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

    public void Exit_Function()
    {
        Application.Quit();
    }
}
