using UnityEngine;
using System.Collections;

public abstract class CharacterAttack : MonoBehaviour
{
    [SerializeField]protected float attackCooldown;
    protected float attackTimer;

    [SerializeField] protected int damage;

    protected abstract void Attack(GameObject target = null);
}
