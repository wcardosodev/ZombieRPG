using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : CharacterAttack {
    [SerializeField] float attackRange = 1.5f;

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if(InRange(transform.position, player.transform.position))
        {
            Attack(player);
        }
    }

    bool InRange(Vector3 yourPos, Vector3 targetPos)
    {
        if(Vector3.Distance(yourPos, targetPos) <= attackRange)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    protected override void Attack(GameObject target)
    {
        print("target taking damage");
        target.GetComponent<Health>().TakeDamage(damage);
    }
}
