using System;
using Unity.VisualScripting;
using UnityEngine;

public class UIUnitButtonScript : MonoBehaviour
{
    private GameUIScript _uiScript;
    private GameLogic _gameLogic;
    [SerializeField] private GenericUnitScript unitUsa;
    [SerializeField] private GenericUnitScript unitRussian;

    // Start is called before the first frame update
    void Start()
    {
        _uiScript = FindObjectOfType<GameUIScript>();
        _gameLogic = FindObjectOfType<GameLogic>();
    }

    public void OnMouseEnter()
    {
        #warning Delete TryCatch when all units will be in game
        try
        {
            _uiScript.unitName.text = _gameLogic.playingAsRussian ? unitUsa.name : unitRussian.name;
            _uiScript.attack.value = _gameLogic.playingAsRussian ? unitUsa.attack : unitRussian.attack;
            _uiScript.fireRate.value = _gameLogic.playingAsRussian ? unitUsa.fireRate : unitRussian.fireRate;
            _uiScript.hp.value = _gameLogic.playingAsRussian ? unitUsa.maxHealth : unitRussian.maxHealth;
            _uiScript.speed.value = _gameLogic.playingAsRussian ? unitUsa.speed : unitRussian.speed;
            _uiScript.attackValue.text = _uiScript.attack.value.ToString();
            _uiScript.fireRateValue.text = _uiScript.fireRate.value.ToString();
            _uiScript.hpValue.text = _uiScript.hp.value.ToString();
            _uiScript.speedValue.text = _uiScript.speed.value.ToString();
        }
        catch (NullReferenceException e)
        {
            if (transform.gameObject.name == "Unit3Image" || transform.gameObject.name == "Unit4Image")
            {
                Debug.LogWarning("We don't have this unit in game currently. This error is to be expected.");
            }
            else
            {
                Debug.LogError(e.Message);
            }
        }
    }

    public void OnMouseExit()
    {
        _uiScript.attack.value = 0;
        _uiScript.attackValue.text = "-----";
        _uiScript.fireRate.value = 0;
        _uiScript.fireRateValue.text = "-----";
        _uiScript.hp.value = 0;
        _uiScript.hpValue.text = "-----";
        _uiScript.speed.value = 0;
        _uiScript.speedValue.text = "-----";
        _uiScript.unitName.text = "N/A";
    }
}
