using System;
using System.Collections;
using UnityEngine;
using System.Linq;
using static GameRoundData;
using static SettingsScript;

public class PlayerScript : MonoBehaviour
{
    [Header("=====================================================")]
    
    [Header("USA Units Prefabs")]
    [SerializeField] private GameObject usaUnitAstronaut;
    [SerializeField] private GameObject usaUnitRover;
    [SerializeField] private GameObject usaUnitTank;
    [SerializeField] private GameObject usaUnitSpaceship;
    
    [Header("Soviet Units Prefabs")]
    [SerializeField] private GameObject sovietUnitAstronaut;
    [SerializeField] private GameObject sovietUnitRover;
    [SerializeField] private GameObject sovietUnitTank;
    [SerializeField] private GameObject sovietUnitSpaceship;
    
    [Header("-----------------------------------------------------")]
    
    [Header("General Unit Sounds")]
    [SerializeField] private AudioClip unitAstronautAudioClip;
    [SerializeField] private AudioClip unitRoverAudioClip;
    
    [Header("USA Unit Sounds")]
    [SerializeField] private AudioClip usaUnitTankAudioClip;
    
    [Header("Soviet Unit Sounds")]
    [SerializeField] private AudioClip sovietUnitTankAudioClip;

    [Header("-----------------------------------------------------")] 
    
    [Header("Background Music Queue")] 
    [SerializeField] private AudioClip usaTheme;
    [SerializeField] private AudioClip sovietTheme;
    
    [Header("=====================================================\n")]

    public int money;
    public int income = 10;

    private GenericBaseScript _base;
    private GameObject _spawner;
    private GameUIScript _uiScript;
    private UnitUpgradeScript _unitUpgradeScript;

    private GameObject _astronautUnit, _roverUnit, _tankUnit, _spaceshipUnit;
    private AudioClip _astronautSound, _roverSound, _tankSound, _spaceshipSound;
    
    private AudioSource _backgroundMusic;
    private AudioSource _sfxAudioSource;

    private void Awake()
    {
        _backgroundMusic = GameObject.Find("BackgroundMusic").GetComponent<AudioSource>();
        _sfxAudioSource = GameObject.Find("SFX").GetComponent<AudioSource>();
    }

    void Start()
    {
        AssignVariablesBasedOnFaction();
        
        StartCoroutine(RaiseBudget());
        StartCoroutine(CountTime());
        
        _base = FindObjectsOfType<GenericBaseScript>().First(x => x.BaseFaction == Faction);
        _spawner = _base.spawner;
        
        _uiScript = FindObjectOfType<GameUIScript>();
        _unitUpgradeScript = GetComponent<UnitUpgradeScript>();
        
        _backgroundMusic.volume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        _sfxAudioSource.volume = PlayerPrefs.GetFloat("EffectsVolume", 0.5f);
        
        _uiScript.UpdateMoney(money);
    }

    private void AssignVariablesBasedOnFaction()
    {
        _astronautUnit = Faction == PlayerFaction.USA ? usaUnitAstronaut : sovietUnitAstronaut;
        _roverUnit = Faction == PlayerFaction.USA ? usaUnitRover : sovietUnitRover;
        _tankUnit = Faction == PlayerFaction.USA ? usaUnitTank : sovietUnitTank;
        _spaceshipUnit = Faction == PlayerFaction.USA ? usaUnitSpaceship : sovietUnitSpaceship;
        
        _astronautSound = unitAstronautAudioClip;
        _roverSound = unitRoverAudioClip;
        _tankSound = Faction == PlayerFaction.USA ? usaUnitTankAudioClip : sovietUnitTankAudioClip;

        _backgroundMusic.clip = Faction == PlayerFaction.USA ? usaTheme : sovietTheme;
        _backgroundMusic.Play();
    }

    private IEnumerator RaiseBudget()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            money += income;
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

    public void BuyAstronaut() => BuyUnit(_astronautUnit, _astronautSound, 50);

    public void BuyRover() => BuyUnit(_roverUnit, _roverSound, 100);

    public void BuyTank() => BuyUnit(_tankUnit, _tankSound, 200);
    
    public void BuySpaceship() => BuyUnit(_spaceshipUnit, _spaceshipSound, 500);

    private void BuyUnit(GameObject unit, AudioClip unitClip, int cost)
    {
        UpgradeValues upgradeValues = AssignUpgradeValues(unit);
        if (money >= cost)
        {
            var unitSpawned = Instantiate(unit, _spawner.transform.position, _spawner.transform.rotation);
            var unitScript = unitSpawned.GetComponent<GenericUnitScript>();
            unitScript.maxHealth = (int)(unitScript.maxHealth * upgradeValues.healthModifier);
            unitScript.attack *= upgradeValues.damageModifier;
            unitScript.fireRate *= upgradeValues.fireRateModifier;
            unitScript.speed *= upgradeValues.speedModifier;
            unitScript.unitCost = (int)(unitScript.unitCost * upgradeValues.unitCostModifier);

            money -= cost;
            _uiScript.UpdateMoney(money);
            _sfxAudioSource.clip = unitClip;
            _sfxAudioSource.Play();
            unitsSpawned++;
        }
    }

    private UpgradeValues AssignUpgradeValues(GameObject unit)
    {
        if (unit == _astronautUnit)
        {
            return _unitUpgradeScript.AstronautUpgradeValues;
        }
        else if (unit == _roverUnit)
        {
            return _unitUpgradeScript.LunarUpgradeValues;
        }
        else if (unit == _tankUnit)
        {
            return _unitUpgradeScript.TankUpgradeValues;
        }
        else throw new Exception();
    }
}
