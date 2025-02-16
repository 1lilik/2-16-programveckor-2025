using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawningWaves : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject PowerUpPrefab;
    public int RandomAmountEnemies;
    public List<GameObject> Enemies;
    public int RandomAmountWaves;
    public int WaveNumber = 0;
    public TextMeshProUGUI EnemyCountText;
    public int Damage = 1;
    public GameObject Door;


    // Start is called before the first frame update
    void Start()
    {
        //G�r s� att en slum�ssig m�ngd fiender spawnar p� samma g�ng 
        RandomAmountWaves = Random.Range(3, 5);
        Invoke("DeactivateDoor", 1);
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
        //Om alla fiender �r d�da �ndras meddelandet och d�rren kan interageras med
        if (RandomAmountEnemies == 0 && RandomAmountWaves == WaveNumber -1)
        {
            EnemyCountText.text = "You killed all of the enemies!";
            Door.SetActive(true);
        }
        else
        {
            EnemyCountText.text = "Kill all of the enemies!";
        }

        LifeManagement lifeManagement = FindObjectOfType<LifeManagement>();
        if (lifeManagement.Lives == 0)
        {
            SceneManager.LoadScene("Game over");
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
                enemyControll.animator.Play("Enemy1_die");
                Enemies.Remove(Enemy);
                Destroy(Enemy, 1);
                RandomAmountEnemies -= 1;
                
                Vector2 SpawnPosistion = enemyControll.transform.position;
                Instantiate(PowerUpPrefab, SpawnPosistion, Quaternion.identity);
            }            
        }
    }

    

   

    public void SpawnWave()
    {
        for (int i = 0; i < RandomAmountEnemies; i++)
        {
            //G�r s� att varje fiende spawnar p� olika st�llen 
            int RandomY = Random.Range(-4, 4);
            int RandomX = Random.Range(-9, 9);
            Instantiate(EnemyPrefab, new Vector2(RandomX, RandomY), Quaternion.identity);

            //L�gger till alla fiender som instant�ateades i en lista
            Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
    void DeactivateDoor()
    {
        Door.SetActive(false);
    }
}
