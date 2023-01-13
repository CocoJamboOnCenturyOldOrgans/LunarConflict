using System.Collections;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    private GameObject _unitPrefab;
    private Transform _spawner;
    private float _secondsBetweenSpawns;
    
    void Start()
    {
        StartCoroutine(SpawnRussianAstronaut());
        Instantiate(_unitPrefab, _spawner.transform.position, _spawner.transform.rotation);
    }

    public void SetAI(GameObject unitPrefab, Transform spawner, float secondsBetweenSpawns)
    {
        _unitPrefab = unitPrefab;
        _spawner = spawner;
        _secondsBetweenSpawns = secondsBetweenSpawns;

    }
    
    private IEnumerator SpawnRussianAstronaut()
    {
        while (true)
        {
            yield return new WaitForSeconds(_secondsBetweenSpawns);
            Instantiate(_unitPrefab, _spawner.transform.position, _spawner.transform.rotation);
        }
    }
}
