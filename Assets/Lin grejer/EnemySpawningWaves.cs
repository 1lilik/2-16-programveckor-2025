using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawningWaves : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int RandomAmountEnemies;
    public List<GameObject> Enemies;
    int RandomAmountWaves;
    int WaveNumber = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        //Gör så att en slumässig mängd fiender spawnar på samma gång 
        RandomAmountWaves = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {   //Om alla fiender är döda skrivs det ut ett meddelande i loggen (kommer ändras när vi fixar alla rummen ordentligt)

        if (WaveNumber <= RandomAmountWaves)
        {
 
            if (RandomAmountEnemies == 0)
            {
                RandomAmountEnemies = Random.Range(1, 6);
                Invoke("SpawnWave", 1);
                WaveNumber += 1;
            }
        }

        if (RandomAmountEnemies == 0 && RandomAmountWaves == WaveNumber)
        {
            Debug.Log("Alla fiender är döda och alla waves är avklarade");
        }
    }

    //Om en fiende blir träffad tas den bort från listan och förstörs och int:en för mängden fiender som spawnades sänks med 1
    public void OnEnemyHit(GameObject Enemy)
    {
        if (Enemies.Contains(Enemy))
        {
            Enemies.Remove(Enemy);
            Destroy(Enemy);
            RandomAmountEnemies -= 1;
        }
    }

    public void SpawnWave()
    {
        


        for (int i = 0; i < RandomAmountEnemies; i++)
        {
            //Gör så att varje fiende spawnar på olika ställen 
            int RandomY = Random.Range(-4, 4);
            int RandomX = Random.Range(-10, 10);
            Instantiate(EnemyPrefab, new Vector2(RandomX, RandomY), Quaternion.identity);

            //Lägger till alla fiender som instantíateades i en lista
            Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
}
