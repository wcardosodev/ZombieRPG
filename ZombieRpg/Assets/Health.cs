using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField] int maximumHealth = 50;
    int currentHealth;

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
        print(gameObject.name + " took " + damage);
        currentHealth -= damage;
        print(currentHealth);
        if(currentHealth <= 0)
        {
            //Destroy(gameObject);
            anim.SetTrigger("Die");
        }
    }
}
