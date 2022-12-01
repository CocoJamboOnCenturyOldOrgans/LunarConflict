using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
	
	private AudioSource BackgroundMusic;
    private AudioSource _sfxAudioSource;
    
    void Start()
    {
        StartCoroutine(RaiseBudget());
        _base = GameObject.Find("PlayerBase");
		
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        BackgroundMusic.volume = Settings_Script.music / 100;
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _sfxAudioSource.volume = Settings_Script.effects / 100;
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 10;
            budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
        }
    }

    public void BuyAstronaut()
    {
        if (money >= 50)
        {
            Instantiate(unitAstronaut, spawner.transform.position, spawner.transform.rotation);
            money -= 50;
			budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
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
			budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
            _sfxAudioSource.clip = unitRoverAudioClip;
            _sfxAudioSource.Play();
        }
    }
}
