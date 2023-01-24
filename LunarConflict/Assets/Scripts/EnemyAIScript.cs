using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static SettingsScript;

public class EnemyAIScript : MonoBehaviour
{
    private List<GameObject> _unitPrefab;
    private Transform _spawner;
    private float _secondsBetweenSpawns;
    private UpgradeValues _unitStatsModifiers;
    
    void Start()
    {
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
            
            if (cooldown <= 0)
            {
                // CHECK IF THERE IS ENOUGH SPACE TO SPAWN THE UNIT
                var boxPoint = new Vector2(_spawner.transform.position.x, _spawner.transform.position.y);
                var boxSize = _spawner.transform.localScale * 3;
                if (Physics2D.OverlapBoxAll(boxPoint, boxSize, 0, LayerMask.GetMask("Unit")).Any(x => !IsPlayer(x.GetComponent<GenericUnitScript>().unitFaction)))
                    continue;
                int unitRandom = Random.Range(0, _unitPrefab.Count);
                var unitPrefab = _unitPrefab[unitRandom];
                var unitSpawned = Instantiate
                    (
                        unitPrefab, 
                        //I don't have any clue why AI is spawning ships lower
                        //_spawner.transform.position + (unitPrefab.GetComponent<GenericSpaceshipScript>() != null ? new Vector3(0, 1.85f) : Vector3.zero),
                        _spawner.transform.position + (unitPrefab.GetComponent<GenericSpaceshipScript>() != null ? new Vector3(0, 2.10f) : Vector3.zero),
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
