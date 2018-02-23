using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private GameObject[] enemys;
    private EnemySpawning EnemySpawning;
    private int wave = 0;

    void Start ()
    {
        EnemySpawning = GetComponent<EnemySpawning>();
	}
	void Update ()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemys.Length == 0)
        {
            nextwave();
        }
    }
    void nextwave()//timer?
    {
        wave++;
        EnemySpawning.Spawn(1);
        print(wave);
    }
}

