using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : CharacterAttack {
    [SerializeField] GameObject firepoint;
    [SerializeField] GameObject projectile;

    public float projSpeed, projDamage;

    [SerializeField] float weaponCooldown = .3f;
    float fireTimer;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        fireTimer = weaponCooldown;
    }

    private void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("IsAttacking", true);
            if (fireTimer < 0)
            {
                Attack();
                fireTimer = weaponCooldown;
            }
        }
        else
        {
            anim.SetBool("IsAttacking", false);
        }
    }

    protected override void Attack(GameObject target = null)
    {
        GameObject proj = Instantiate(projectile, firepoint.transform.position, firepoint.transform.rotation);
        proj.tag = gameObject.tag;
    }
}
