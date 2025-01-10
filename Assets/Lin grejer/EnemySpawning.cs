using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour
{
    public GameObject EnemyPrefab;
    


    // Start is called before the first frame update
    void Start()
    {
        int RandomY = Random.Range(-4, 4);
        int RandomX = Random.Range(-10, 10);
        


        int RandomAmountEnemies = Random.Range(1, 6);
        for (int i = 0; i < RandomAmountEnemies; i++)
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
