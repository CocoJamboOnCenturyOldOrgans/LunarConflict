using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SettingsScript;

public class EnemyAIScript : MonoBehaviour
{
    private List<GameObject> _unitPrefab;
    private List<GameObject> _availablePrefabs;
    private Transform _spawner;
    private float _secondsBetweenSpawns, _secondsToNextPhase = 60;
    private int _currentPhase;
    private float _currentSecondsToNextPhase;
    private UpgradeValues _unitStatsModifiers;
    
    void Start()
    {
        _availablePrefabs = _unitPrefab.Where(x => !x.name.Contains("Tank") && !x.name.Contains("Spaceship")).ToList();
        
        StartCoroutine(SpawnRussianAstronaut());
        float statModifier = 1f;
        switch (AIDiff)
        {
            case AIDifficulty.Easy:
                statModifier = 0.75f;
                break;
            //case AIDifficulty.Medium already covered
            case AIDifficulty.Hard:
                statModifier = 1.25f;
                break;
            case AIDifficulty.Impossible:
                statModifier = 1.5f;
                break;
        }

        _unitStatsModifiers = new UpgradeValues(
            statModifier,
            statModifier,
            statModifier,
            statModifier,
            statModifier); //This looks brilliant
        
        _secondsToNextPhase *= (2 - statModifier);
        Debug.Log(_secondsToNextPhase);
        _currentSecondsToNextPhase = _secondsToNextPhase;
    }

    public void SetAI(List<GameObject> unitPrefab, Transform spawner, float secondsBetweenSpawns)
    {
        _unitPrefab = unitPrefab;
        _spawner = spawner;
        _secondsBetweenSpawns = secondsBetweenSpawns;
    }
    
    private IEnumerator SpawnRussianAstronaut() //SpawnUnit
    {
        float cooldown = Random.Range(_secondsBetweenSpawns-2, _secondsBetweenSpawns+2);
        
        while (true)
        {
            yield return null;

            if (_currentSecondsToNextPhase <= 0 && _currentPhase == 0)
            {
                _availablePrefabs = _unitPrefab.Where(x => !x.name.Contains("Spaceship")).ToList();
                _currentPhase++;
                _currentSecondsToNextPhase = _secondsToNextPhase;
            }
            else if (_currentSecondsToNextPhase <= 0 && _currentPhase == 1)
            {
                _availablePrefabs = _unitPrefab;
                _currentPhase++;
            }
            else if (_currentSecondsToNextPhase >= 0)
            {
                _currentSecondsToNextPhase -= Time.deltaTime;
            }
            
            if (cooldown <= 0)
            {
                // CHECK IF THERE IS ENOUGH SPACE TO SPAWN THE UNIT
                var boxPoint = new Vector2(_spawner.transform.position.x, _spawner.transform.position.y);
                var boxSize = _spawner.transform.localScale * 3;
                if (Physics2D.OverlapBoxAll(boxPoint, boxSize, 0, LayerMask.GetMask("Unit")).Any(x => !IsPlayer(x.GetComponent<GenericUnitScript>().unitFaction)))
                    continue;
                int unitRandom = Random.Range(0, _availablePrefabs.Count);
                var unitPrefab = _availablePrefabs[unitRandom];
                var unitSpawned = Instantiate
                    (
                        unitPrefab, 
                        _spawner.transform.position + (unitPrefab.GetComponent<GenericSpaceshipScript>() != null ? new Vector3(0, 1.75f) : Vector3.zero),
                        _spawner.transform.rotation
                    );
                
                var unitScript = unitSpawned.GetComponent<GenericUnitScript>();
                unitScript.maxHealth = (int) (unitScript.maxHealth * _unitStatsModifiers.healthModifier);
                unitScript.attack *= (int) _unitStatsModifiers.damageModifier;
                unitScript.fireRate *= _unitStatsModifiers.fireRateModifier;
                unitScript.speed *= _unitStatsModifiers.speedModifier;
                unitScript.unitCost = (int) (unitScript.unitCost * _unitStatsModifiers.unitCostModifier);
                cooldown = _secondsBetweenSpawns;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
