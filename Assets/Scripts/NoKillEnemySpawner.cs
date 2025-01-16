using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class NoKillEnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    int RandomAmountEnemies;
    public List<GameObject> UnkillableEnemies;
    public TextMeshProUGUI Countdown;
    public float CountdownTime = 60;
    float CurrentTime;
    GameObject player;
    

    bool test = false;

    // Start is called before the first frame update
    void Start()
    {
        RandomAmountEnemies = Random.Range(3, 7);
        Invoke("SpawnEnemies", 1);
        CurrentTime = CountdownTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            Countdown.text = "Time left: " + Mathf.Ceil(CurrentTime).ToString();
        }

        if (CurrentTime <= 0 && test == false)
        {
            Countdown.text = "YOU SURVIVED!";
            test = true;
            for (int y = 0; y < UnkillableEnemies.Capacity; y++)
            {
                NoKillEnemyControll[] noKillEnemyControll = FindObjectsOfType<NoKillEnemyControll>();
                noKillEnemyControll[y].animator.Play("Enemy2_die");
                Destroy(UnkillableEnemies[y], 0.8f);
            }
        }
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < RandomAmountEnemies; i++)
        {
            //Gör så att varje fiende spawnar på olika ställen 
            int RandomY = Random.Range(-4, 4);
            int RandomX = Random.Range(-9, 10);
            Instantiate(EnemyPrefab, new Vector2(RandomX, RandomY), Quaternion.identity);

            //Lägger till alla fiender som instantíateades i en lista
            UnkillableEnemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("NoKillEnemy"));
        }
    }
}

