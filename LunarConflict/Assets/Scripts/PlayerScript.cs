using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject rover;
    [SerializeField] private GameObject spawner;
    
    [SerializeField] private Text Budget;

    public int money;
    
    private GameObject _base;
<<<<<<< Updated upstream
=======
    private AudioSource BackgroundMusic;
    private AudioSource _sfxAudioSource;
    
>>>>>>> Stashed changes
    void Start()
    {
        StartCoroutine("RaiseBudget");
        _base = GameObject.Find("PlayerBase");
<<<<<<< Updated upstream
=======
        BackgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        BackgroundMusic.volume = Settings_Script.music / 100;
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
        _sfxAudioSource.volume = Settings_Script.effects / 100;
>>>>>>> Stashed changes
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
<<<<<<< Updated upstream
            money += 5;
            Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
=======
            money += 10;
            budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
>>>>>>> Stashed changes
        }
    }

    public void BuyAstronaut()
    {
<<<<<<< Updated upstream
        Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
        money -= 50;
        Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
=======
        if (money >= 50)
        {
            Instantiate(unitAstronaut, spawner.transform.position, spawner.transform.rotation);
            money -= 50;
            budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
            _sfxAudioSource.clip = unitAstronautAudioClip;
            _sfxAudioSource.Play();
        }
>>>>>>> Stashed changes
    }

    public void BuyRover()
    {
<<<<<<< Updated upstream
        Instantiate(rover, spawner.transform.position, spawner.transform.rotation);
        money -= 100;
        Budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
=======
        if (money >= 100)
        {
            Instantiate(unitRover, spawner.transform.position, spawner.transform.rotation);
            money -= 100;
            budget.text = money.ToString() + Settings_Script.UI_Money_Mark;
            _sfxAudioSource.clip = unitRoverAudioClip;
            _sfxAudioSource.Play();
        }
>>>>>>> Stashed changes
    }
}
