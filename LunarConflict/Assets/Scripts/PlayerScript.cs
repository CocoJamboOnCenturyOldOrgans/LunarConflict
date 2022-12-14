using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject unitAstronaut;
    [SerializeField] private AudioClip unitAstronautAudioClip;
    [SerializeField] private GameObject unitRover;
    [SerializeField] private AudioClip unitRoverAudioClip;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private Text budget;

    public int money;
    
    private GameObject _base;
	
	private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;
    
    void Start()
    {
        StartCoroutine(RaiseBudget());
        _base = GameObject.Find("PlayerBase");
		
        _backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _backgroundMusic.volume = SettingsScript.Music;
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _sfxAudioSource.volume = SettingsScript.Effects;
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 10;
            budget.text = money + SettingsScript.UIMoneyMark;
        }
    }

    public void BuyAstronaut()
    {
        if (money >= 50)
        {
            Instantiate(unitAstronaut, spawner.transform.position, spawner.transform.rotation);
            money -= 50;
			budget.text = money + SettingsScript.UIMoneyMark;
            _sfxAudioSource.clip = unitAstronautAudioClip;
            _sfxAudioSource.Play();
        }
    }
    
    public void BuyRover()
    {
        if (money >= 100)
        {
            Instantiate(unitRover, spawner.transform.position, spawner.transform.rotation);
            money -= 100;
			budget.text = money + SettingsScript.UIMoneyMark;
            _sfxAudioSource.clip = unitRoverAudioClip;
            _sfxAudioSource.Play();
        }
    }
}
