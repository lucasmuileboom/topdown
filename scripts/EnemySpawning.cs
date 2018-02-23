using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    [SerializeField]private GameObject[] spawnpoints;
    [SerializeField]private GameObject[] enemys;

    public void Spawn(int spawnamount)
    {
        for (int i = 0; i < spawnamount; i++)//spawn een random enemy op een random spawnpoint
        {
            Instantiate(enemys[Random.Range(0, enemys.Length)], spawnpoints[Random.Range(0, spawnpoints.Length)].transform.position, Quaternion.Euler(0,0,0));
        }
    }
}
