using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIScript : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    public BottomPanelObjectScript bottomPanel;

    public Slider baseHealthSlider;
    public Text baseHealthValue;
        
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

        // SET TIME SCALE TO NORMAL ON EACH SCENE CHANGE
        SceneManager.activeSceneChanged += (scene1, scene2) => Time.timeScale = 1.0f;;
    }
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnBaseHealthChanged() => baseHealthValue.text = baseHealthSlider.value.ToString();

    public void UpdateMoney(int money)
    {
        budget.text = money + SettingsScript.UIMoneyMark;
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

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
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
