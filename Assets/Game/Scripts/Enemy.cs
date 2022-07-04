using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Transform player;
  public Vector3 playerLastLocation;
  public Animator animator;
  public NavMeshAgent navMeshAgent;
  public float time = 0;
  public bool isAttacking = false;
  public bool isPursuing = false;
  public int runRange = 7;
  public int attackRange = 2;

  void Start()
  {
    navMeshAgent = gameObject.GetComponent(typeof(NavMeshAgent)) as NavMeshAgent;
    animator = gameObject.GetComponent(typeof(Animator)) as Animator;
    player = GameObject.FindWithTag("Player").transform;
  }

  void Update()
  {
    float distance1 = Vector3.Distance(transform.position, player.transform.position);
    float distance2 = Vector3.Distance(playerLastLocation, transform.position);
    bool isRunning = animator.GetBool("Run");

    if (distance1 < attackRange && time > 2)
    {
      time = 0;
      animator.SetTrigger("Attack");
      isAttacking = true;
    }
    else if (distance1 < attackRange && isRunning == true && isAttacking == false)
    {
      time = 0;
      time += Time.deltaTime;
      isAttacking = true;
      animator.SetBool("Run", false);
    }
    else if (distance1 < attackRange && isRunning == false && isAttacking == true)
    {
      time += Time.deltaTime;
    }
    else if (distance1 > attackRange && isRunning == false && isAttacking == true)
    {
      isAttacking = false;
      animator.SetBool("Run", true);
    }
    else if (distance1 < runRange && isRunning == false && isAttacking == false)
    {
      isPursuing = true;
      animator.SetBool("Run", true);
      navMeshAgent.SetDestination(player.position);
    }
    else if (distance1 < runRange && isRunning == true && isAttacking == false)
    {
      navMeshAgent.SetDestination(player.position);
    }
    else if (distance1 > runRange && isRunning == true && isAttacking == false && isPursuing == true)
    {
      isPursuing = false;
      playerLastLocation = player.position;
      navMeshAgent.SetDestination(playerLastLocation);
    }
    else if (distance2 < 1.5 && isRunning == true && isPursuing == false)
    {
      animator.SetBool("Run", false);
    }
  }

  void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, runRange);
    }
}
