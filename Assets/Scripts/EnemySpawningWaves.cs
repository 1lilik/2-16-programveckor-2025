using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        //Gör så att en slumässig mängd fiender spawnar på samma gång 
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
        //Om alla fiender är döda ändras meddelandet och dörren kan interageras med
        if (RandomAmountEnemies == 0 && RandomAmountWaves == WaveNumber -1)
        {
            EnemyCountText.text = "You killed all of the enemies!";
            Door.SetActive(true);
        }
        else
        {
            EnemyCountText.text = "Kill all of the enemies!";
        }
    }

    //Om en fiende blir träffad tas den bort från listan och förstörs och int:en för mängden fiender som spawnades sänks med 1
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
            //Gör så att varje fiende spawnar på olika ställen 
            int RandomY = Random.Range(-4, 4);
            int RandomX = Random.Range(-9, 9);
            Instantiate(EnemyPrefab, new Vector2(RandomX, RandomY), Quaternion.identity);

            //Lägger till alla fiender som instantíateades i en lista
            Enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        }
    }
    void DeactivateDoor()
    {
        Door.SetActive(false);
    }
}
