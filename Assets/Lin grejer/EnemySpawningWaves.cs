using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawningWaves : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public int RandomAmountEnemies;
    public List<GameObject> Enemies;
    public int RandomAmountWaves;
    public int WaveNumber = 0;
    public TextMeshProUGUI EnemyCountText;
    public int Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        //G�r s� att en slum�ssig m�ngd fiender spawnar p� samma g�ng 
        RandomAmountWaves = Random.Range(3, 5);
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (WaveNumber <= RandomAmountWaves)
        {
            if (RandomAmountEnemies == 0)
            {
                RandomAmountEnemies = Random.Range(3, 7);
                Invoke("SpawnWave", 1);
                WaveNumber += 1;
            }
        }
        //Om alla fiender �r d�da skrivs det ut ett meddelande i loggen (kommer �ndras n�r vi fixar alla rummen ordentligt)
        if (RandomAmountEnemies == 0 && RandomAmountWaves == WaveNumber)
        {
            EnemyCountText.text = "You killed all of the enemies!";
        }
        else
        {
            EnemyCountText.text = "Kill all of the enemies!";
        }
    }

    //Om en fiende blir tr�ffad tas den bort fr�n listan och f�rst�rs och int:en f�r m�ngden fiender som spawnades s�nks med 1
    public void OnEnemyHit(GameObject Enemy)
    {
        if (Enemies.Contains(Enemy))
        {
            EnemyControll enemyControll = Enemy.GetComponent<EnemyControll>();
            enemyControll.lives -= Damage;

            if (enemyControll.lives <= 0)
            {
                enemyControll.AllowWalk = false;
                enemyControll.Animator.Play("Enemy1_die");
                Enemies.Remove(Enemy);
                Destroy(Enemy, 1);
                RandomAmountEnemies -= 1;
            }
        }
    }

    public void SpawnWave()
    {
        for (int i = 0; i < RandomAmountEnemies; i++)
        {
            //G�r s� att varje fiende spawnar p� olika st�llen 
            int RandomY = Random.Range(-4, 4);
            int RandomX = Random.Range(-10, 10);
            Instantiate(EnemyPrefab, new Vector2(RandomX, RandomY), Quaternion.identity);

            //L�gger till alla fiender som instant�ateades i en lista
            Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
}
