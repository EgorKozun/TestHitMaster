using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyDamage : MonoBehaviour
{
    public float enemyDamageAmount;
    public DateTime nextDamage;
    public float damageAfterTime;
    public bool enemyInFightRange = false;

    public GameObject enemyObj;
    void Start()
    {
        nextDamage = DateTime.Now;
    }

    
    void Update()
    {
        if (enemyInFightRange == true)
        {
            DamageEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyObj = other.gameObject;
            enemyInFightRange = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemyInFightRange = false;
            Destroy(gameObject);
        }
    }
    public void DamageEnemy()
    {
        if (nextDamage <= DateTime.Now)
        {
            if (enemyObj.GetComponent<EnemyHealth>().enemyDied == false)
            {
                enemyObj.GetComponent<EnemyHealth>().AddDamage(enemyDamageAmount);
                nextDamage = DateTime.Now.AddSeconds(System.Convert.ToDouble(damageAfterTime));
            }
        }
    }
}
