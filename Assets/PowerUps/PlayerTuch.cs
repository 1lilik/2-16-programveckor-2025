using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTuch : MonoBehaviour
{
    public float NormalSpeed = 5f;
    public float SpeedBost = 15f;
    public float SpeedDuration = 7f;

    private bool isBoosted;
    private float CurrentSpeed;
    private bool IsActivate;
    private Kontroll controll;
    private void Start()
    {
        CurrentSpeed = NormalSpeed;
        controll = GetComponent<Kontroll>();

    }

    void Update()
    {

    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            if (!IsActivate)
            {
                int RandomN = Random.Range(0, 100);
                if (RandomN < 50)
                {
                    StartCoroutine(SpeedBoost());
                }
                else
                {
                    StartCoroutine(DoubleDamage());
                }

               
            }
            Destroy(other.gameObject);
        }
    }

    private IEnumerator SpeedBoost()
    {
        isBoosted = true;
        controll.MoveSpeed = SpeedBost;

        yield return new WaitForSeconds(SpeedDuration);

        controll.MoveSpeed = NormalSpeed;
        isBoosted = false;

    }

    private IEnumerator DoubleDamage()
    {
        EnemySpawningWaves ESW = FindObjectOfType<EnemySpawningWaves>();
        ESW.Damage = 2;

        yield return new WaitForSeconds(SpeedDuration);

        ESW.Damage = 1;
    }
}