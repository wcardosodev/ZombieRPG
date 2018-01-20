using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 50;
    public int currentHealth;

    Animator anim;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        if(currentHealth <= 0)
        {
            //Disable capsule collider
            //Destroy(gameObject);
            anim.SetTrigger("Die");
        }
    }

    public float HealthAsPercentage
    {
        get { return (float)currentHealth / maximumHealth; }
    }
}
