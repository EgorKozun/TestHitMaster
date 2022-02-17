using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float fullHealth;
    public float currentHealth;
    public bool enemyDied = false;

    public Canvas enemyCanvas;
    public Slider enemyHealthSlider;

    Animator animatorEnemy;
    public GameObject playerObj;

    
    void Start()
    {
        currentHealth = fullHealth;
        enemyHealthSlider.minValue = 0;
        enemyHealthSlider.maxValue = fullHealth;
        enemyHealthSlider.value = currentHealth;
        animatorEnemy = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        currentHealth -= damage;
        enemyHealthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            enemyDied = true;
            enemyCanvas.enabled = false;
            MakeDied();
            playerObj.GetComponent<HitMan>().Waypoint();
        }
    }
    public void MakeDied()
    {
        animatorEnemy.SetTrigger("Death");
        Destroy(gameObject, 3f);
    }
}
