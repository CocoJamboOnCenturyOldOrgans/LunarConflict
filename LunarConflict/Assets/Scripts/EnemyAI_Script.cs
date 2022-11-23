using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI_Script : MonoBehaviour
{
    [SerializeField] private GameObject astronaut;
    void Start()
    {
        StartCoroutine("SpawnRussianAstronaut");
    }
    private IEnumerator SpawnRussianAstronaut()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(astronaut, transform);
        }
    }
}
