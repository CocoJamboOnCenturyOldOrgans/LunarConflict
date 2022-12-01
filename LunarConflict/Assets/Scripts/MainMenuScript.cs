using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button easyDiff;
    public Button normalDiff;
    public Button hardDiff;
    public Button impossibleDiff;
    public Button usa;
    public Button soviet;

    public Text musicValue;
    public Slider musicSlider;
    public Text effectsValue;
    public Slider effectsSlider;

    public GameObject mainMenuPanel;
    public GameObject gamePanel;
    public GameObject settingsPanel;
    public GameObject creditsPanel;

    private void Start()
    {
        SettingsScript.Side = 1;
        usa.interactable = false;
        soviet.interactable = true;
        UnitsStatistics.StatsModifier = 1f;
        easyDiff.interactable = true;
        normalDiff.interactable = false;
        hardDiff.interactable = true;
        impossibleDiff.interactable = true;

        musicSlider.value = SettingsScript.Music;
        musicValue.text = musicSlider.value + "%";
        effectsSlider.value = SettingsScript.Effects;
        effectsValue.text = effectsSlider.value + "%";
    }

    public void StartGame_Function()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
}

    public void BeginGame()
    {
        SceneManager.LoadSceneAsync("PrototypeScene");
    }

    public void ChooseSovietSide()
    {
        SettingsScript.Side = 2;
        usa.interactable = true;
        soviet.interactable = false;
    }

    public void ChooseUsaSide()
    {
        SettingsScript.Side = 1;
        usa.interactable = false;
        soviet.interactable = true;
    }

    public void EasyDifficulty()
    {
        UnitsStatistics.StatsModifier = 0.7f;
        easyDiff.interactable = false;
        normalDiff.interactable = true;
        hardDiff.interactable = true;
        impossibleDiff.interactable = true;

    }

    public void NormalDifficulty()
    {
        UnitsStatistics.StatsModifier = 1f;
        easyDiff.interactable = true;
        normalDiff.interactable = false;
        hardDiff.interactable = true;
        impossibleDiff.interactable = true;
    }

    public void HardDifficulty()
    {
        UnitsStatistics.StatsModifier = 1.5f;
        easyDiff.interactable = true;
        normalDiff.interactable = true;
        hardDiff.interactable = false;
        impossibleDiff.interactable = true;
    }

    public void ImpossibleDifficulty()
    {
        UnitsStatistics.StatsModifier = 2f;
        easyDiff.interactable = true;
        normalDiff.interactable = true;
        hardDiff.interactable = true;
        impossibleDiff.interactable = false;
    }

    public void Settings_Function()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
    }

    public void ChangeMusic()
    {
        musicValue.text = musicSlider.value + "%";
        SettingsScript.Music = musicSlider.value;
    }

    public void ChangeEffects()
    {
        effectsValue.text = effectsSlider.value + "%";
        SettingsScript.Effects = effectsSlider.value;
    }

    public void Credits_Function()
    {
        mainMenuPanel.SetActive(false);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(true);
    }

    public void Back_Function()
    {
        mainMenuPanel.SetActive(true);
        gamePanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditsPanel.SetActive(false);
    }

    public void Exit_Function()
    {
        Application.Quit();
    }
}
