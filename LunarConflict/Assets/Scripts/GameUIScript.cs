using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameUIScript : MonoBehaviour
{
    [SerializeField]private Button buyCosmonautButton;
    [SerializeField] private Button UnitsButton;
    [SerializeField] private Button BaseButton;
    [SerializeField] private Button SpecialButton;

    //UI SECTIONS
    [SerializeField] private GameObject UnitsPanel;
    [SerializeField] private GameObject BasePanel;
    [SerializeField] private GameObject SpecialPanel;
    [SerializeField] private GameObject StatsPanel;
    [SerializeField] private GameObject DescriptionPanel;

    //UI CERTAIN ELEMENTS
    public Slider Attack;
    public Slider FireRate;
    public Slider HP;
    public Slider Speed;
    public Text AttackValue;
    public Text FireRateValue;
    public Text HPValue;
    public Text SpeedValue;
    public Text UnitName;
    public Text BuildingName;
    public Text Description;

    public Sprite CanBuy;
    public Sprite CannotBuy;

    private PlayerScript _playerScript;
    private Button UnitsButton1;
    private Button UnitsButton2;
    private Button UnitsButton3;
    private Button UnitsButton4;
    private Image UnitsImage1;
    private Image UnitsImage2;
    private Image UnitsImage3;
    private Image UnitsImage4;
    //private Button BaseButton1;
    //private Button BaseButton2;

    [SerializeField] private Text Budget;

    void Start()
    {
        _playerScript = GameObject.Find("GameLogic").GetComponent<PlayerScript>();
        UnitsButton1 = GameObject.Find("Unit1Image").GetComponent<Button>();
        UnitsButton2 = GameObject.Find("Unit2Image").GetComponent<Button>();
        UnitsButton3 = GameObject.Find("Unit3Image").GetComponent<Button>();
        UnitsButton4 = GameObject.Find("Unit4Image").GetComponent<Button>();

        UnitsImage1 = GameObject.Find("Unit1Image").GetComponent<Image>();
        UnitsImage2 = GameObject.Find("Unit2Image").GetComponent<Image>();
        UnitsImage3 = GameObject.Find("Unit3Image").GetComponent<Image>();
        UnitsImage4 = GameObject.Find("Unit4Image").GetComponent<Image>();

        //Those Making Problems!
        //BaseButton1 = GameObject.Find("Unit1BaseImage").GetComponent<Button>();
        //BaseButton2 = GameObject.Find("Unit2BaseImage").GetComponent<Button>();
    }
    
    void Update()
    {
        //Testing of locking feature - fix in next version/final release
        if (_playerScript.money < 50)
        {
            UnitsButton1.enabled = false;
            UnitsImage1.sprite = CannotBuy;
            UnitsButton2.enabled = false;
            UnitsImage2.sprite = CannotBuy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 50 && _playerScript.money < 100)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = CanBuy;
            UnitsButton2.enabled = false;
            UnitsImage2.sprite = CannotBuy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;
            //Those Making Problems!
            //BaseButton1.enabled = false;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 100 && _playerScript.money < 200)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = CanBuy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = CanBuy;
            UnitsButton3.enabled = false;
            UnitsImage3.sprite = CannotBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CannotBuy;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else if (_playerScript.money >= 200 && _playerScript.money < 350)
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = CanBuy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = CanBuy;
            UnitsButton3.enabled = true;
            UnitsImage3.sprite = CanBuy;
            UnitsButton4.enabled = false;
            UnitsImage4.sprite = CanBuy;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = false;
        }
        else
        {
            UnitsButton1.enabled = true;
            UnitsImage1.sprite = CanBuy;
            UnitsButton2.enabled = true;
            UnitsImage2.sprite = CanBuy;
            UnitsButton3.enabled = true;
            UnitsImage3.sprite = CanBuy;
            UnitsButton4.enabled = true;
            UnitsImage4.sprite = CanBuy;
            //Those Making Problems!
            //BaseButton1.enabled = true;
            //BaseButton2.enabled = true;
        }
    }

    //##################################################################
    //################ Panels Buttons Section ##########################
    //##################################################################
    public void ChooseUnitsPanel()
    {
        UnitsPanel.gameObject.SetActive(true);
        BasePanel.gameObject.SetActive(false);
        SpecialPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(true);
        DescriptionPanel.gameObject.SetActive(false);
    }

    public void ChooseBasePanel()
    {
        UnitsPanel.gameObject.SetActive(false);
        BasePanel.gameObject.SetActive(true);
        SpecialPanel.gameObject.SetActive(false);
        StatsPanel.gameObject.SetActive(false);
        DescriptionPanel.gameObject.SetActive(true);
    }

    public void ChooseSpecialPanel()
    {
        UnitsPanel.gameObject.SetActive(false);
        BasePanel.gameObject.SetActive(false);
        SpecialPanel.gameObject.SetActive(true);
        StatsPanel.gameObject.SetActive(false);
        DescriptionPanel.gameObject.SetActive(false);
    }

    //##################################################################
    //########### Entities Spawns Buttons Section ######################
    //##################################################################
    public void SpawnEntityA()
    {
        Debug.Log("Created Entity A");
        _playerScript.money -= 50;
        Budget.text = _playerScript.money.ToString() + "$";
    }

    public void SpawnEntityB()
    {
        Debug.Log("Created Entity B");
        _playerScript.money -= 100;
        Budget.text = _playerScript.money.ToString() + "$";
    }

    public void SpawnEntityC()
    {
        Debug.Log("Created Entity C");
        _playerScript.money -= 200;
        Budget.text = _playerScript.money.ToString() + "$";
    }

    public void SpawnEntityD()
    {
        Debug.Log("Created Entity D");
        _playerScript.money -= 350;
        Budget.text = _playerScript.money.ToString() + "$";
    }

    //public void DoBaseA()
    //{
    //    Debug.Log("Base Upgraded by Module A");
    //    _playerScript.money -= 100;
    //}

    //public void DoBaseB()
    //{
    //    Debug.Log("Base Upgraded by Module B");
    //    _playerScript.money -= 350;
    //}
}
