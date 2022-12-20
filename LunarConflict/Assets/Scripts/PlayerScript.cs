using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static GameRoundData;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject unitAstronaut;
    [SerializeField] private AudioClip unitAstronautAudioClip;
    [SerializeField] private GameObject unitRover;
    [SerializeField] private AudioClip unitRoverAudioClip;
    [SerializeField] private GameObject unitTank;
    [SerializeField] private AudioClip unitTankAudioClip;
    [SerializeField] private GameObject spawner;

    public int money;
    
    private GameObject _base;
    private GameUIScript _uiScript;

    private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;
    
    void Start()
    {
        StartCoroutine(RaiseBudget());
        StartCoroutine(CountTime());
        _base = GameObject.Find("PlayerBase");
        _uiScript = FindObjectOfType<GameUIScript>();
        
        _backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _backgroundMusic.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _sfxAudioSource.volume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        
        _uiScript.UpdateMoney(money);
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += 10;
            _uiScript.UpdateMoney(money);
        }
    }

    private IEnumerator CountTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    public void BuyAstronaut() => BuyUnit(unitAstronaut, unitAstronautAudioClip, 50);

    public void BuyRover() => BuyUnit(unitRover, unitRoverAudioClip, 100);

    public void BuyTank() => BuyUnit(unitTank, unitTankAudioClip, 200);

    private void BuyUnit(GameObject unit, AudioClip unitClip, int cost)
    {
        if (money >= cost)
        {
            Instantiate(unit, spawner.transform.position, spawner.transform.rotation);
            money -= cost;
            _uiScript.UpdateMoney(money);
            _sfxAudioSource.clip = unitClip;
            _sfxAudioSource.Play();
            unitsSpawned++;
        }
    }
}
