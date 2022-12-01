using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public Button EasyDiff;
    public Button NormalDiff;
    public Button HardDiff;
    public Button ImpossibleDiff;
    public Button USA;
    public Button Soviet;

    public Text MusicValue;
    public Slider MusicSlider;
    public Text EffectsValue;
    public Slider EffectsSlider;

    public GameObject MainMenuPanel;
    public GameObject GamePanel;
    public GameObject SettingsPanel;
    public GameObject CreditsPanel;

    private void Start()
    {
        Settings_Script.side = 1;
        USA.interactable = false;
        Soviet.interactable = true;
        Units_Statistics.stats_modifier = 1f;
        EasyDiff.interactable = true;
        NormalDiff.interactable = false;
        HardDiff.interactable = true;
        ImpossibleDiff.interactable = true;

        MusicSlider.value = Settings_Script.music;
        MusicValue.text = MusicSlider.value.ToString() + "%";
        EffectsSlider.value = Settings_Script.effects;
        EffectsValue.text = EffectsSlider.value.ToString() + "%";
    }

    public void StartGame_Function()
    {
        MainMenuPanel.SetActive(false);
        GamePanel.SetActive(true);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
}

    public void BeginGame()
    {
        SceneManager.LoadSceneAsync("PrototypeScene");
    }

    public void ChooseSovietSide()
    {
        Settings_Script.side = 2;
        USA.interactable = true;
        Soviet.interactable = false;
    }

    public void ChooseUSASide()
    {
        Settings_Script.side = 1;
        USA.interactable = false;
        Soviet.interactable = true;
    }

    public void EasyDifficulty()
    {
        Units_Statistics.stats_modifier = 0.7f;
        EasyDiff.interactable = false;
        NormalDiff.interactable = true;
        HardDiff.interactable = true;
        ImpossibleDiff.interactable = true;

    }

    public void NormalDifficulty()
    {
        Units_Statistics.stats_modifier = 1f;
        EasyDiff.interactable = true;
        NormalDiff.interactable = false;
        HardDiff.interactable = true;
        ImpossibleDiff.interactable = true;
    }

    public void HardDifficulty()
    {
        Units_Statistics.stats_modifier = 1.5f;
        EasyDiff.interactable = true;
        NormalDiff.interactable = true;
        HardDiff.interactable = false;
        ImpossibleDiff.interactable = true;
    }

    public void ImpossibleDifficulty()
    {
        Units_Statistics.stats_modifier = 2f;
        EasyDiff.interactable = true;
        NormalDiff.interactable = true;
        HardDiff.interactable = true;
        ImpossibleDiff.interactable = false;
    }

    public void Settings_Function()
    {
        MainMenuPanel.SetActive(false);
        GamePanel.SetActive(false);
        SettingsPanel.SetActive(true);
        CreditsPanel.SetActive(false);
    }

    public void ChangeMusic()
    {
        MusicValue.text = MusicSlider.value.ToString() + "%";
        Settings_Script.music = MusicSlider.value;
    }

    public void ChangeEffects()
    {
        EffectsValue.text = EffectsSlider.value.ToString() + "%";
        Settings_Script.effects = EffectsSlider.value;
    }

    public void Credits_Function()
    {
        MainMenuPanel.SetActive(false);
        GamePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(true);
    }

    public void Back_Function()
    {
        MainMenuPanel.SetActive(true);
        GamePanel.SetActive(false);
        SettingsPanel.SetActive(false);
        CreditsPanel.SetActive(false);
    }

    public void Exit_Function()
    {
        Application.Quit();
    }
}
