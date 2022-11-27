using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject spawner;
    [SerializeField] private float spawnEverySeconds;
    void Start()
    {
        StartCoroutine(SpawnRussianAstronaut());
        Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
    }
    private IEnumerator SpawnRussianAstronaut()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnEverySeconds);
            Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
