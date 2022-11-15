using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField]private Text moneyText;
    [SerializeField]private Button buyCosmonautButton;
    private PlayerScript _playerScript;

    void Start()
    {
        _playerScript = GameObject.Find("Game").GetComponent<PlayerScript>();
    }
    
    void Update()
    {
        moneyText.text = _playerScript.money.ToString();
    }
}
