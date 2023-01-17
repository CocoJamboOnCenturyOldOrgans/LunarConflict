using System.Collections;
using System.Linq;
using UnityEngine;
using static SettingsScript;

public class EnemyAIScript : MonoBehaviour
{
    private GameObject _unitPrefab;
    private Transform _spawner;
    private float _secondsBetweenSpawns;
    
    void Start()
    {
        StartCoroutine(SpawnRussianAstronaut());
    }

    public void SetAI(GameObject unitPrefab, Transform spawner, float secondsBetweenSpawns)
    {
        _unitPrefab = unitPrefab;
        _spawner = spawner;
        _secondsBetweenSpawns = secondsBetweenSpawns;

    }
    
    private IEnumerator SpawnRussianAstronaut()
    {
        float cooldown = _secondsBetweenSpawns;
        
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
                
                Instantiate(_unitPrefab, _spawner.transform.position, _spawner.transform.rotation);
                cooldown = _secondsBetweenSpawns;
            }
            else
            {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
