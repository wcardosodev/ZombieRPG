using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    PlayerAttack player;
    NavMeshAgent agent;
    Animator anim;

    [SerializeField] float sightRange = 5;

    // Use this for initialization
    void Start()
    {
        player = FindObjectOfType<PlayerAttack>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (CanSeePlayer())
        {
            //agent.SetDestination(player.transform.position);
            //anim.SetBool("IsMoving", true);
        }
    }

    bool CanSeePlayer()
    {
        if (true)
        {
            return true;
        }
        return false;
    }
}
