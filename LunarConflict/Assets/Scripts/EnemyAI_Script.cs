using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Script : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    [SerializeField] private GameObject spawner;
    void Start()
    {
        StartCoroutine("SpawnRussianAstronaut");
    }
    private IEnumerator SpawnRussianAstronaut()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(astronaut, spawner.transform.position, spawner.transform.rotation);
        }
    }
}
