using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshEnemies : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] private Transform hitPoint;
    [SerializeField] private AudioClip soundIdle;
    [SerializeField] private AudioClip soundRun;
    [SerializeField] private AudioClip soundAttack;
    [SerializeField] private AudioClip soundDie;


    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private bool canFollow = false;
    private bool playerAlive = true;
    private bool enemyAlive = true;
    private AudioSource audioSource;
    private EnemyStats enemyStats;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
        enemyStats = GetComponent<EnemyStats>();
    }


    private void Start()
    {
        PlayerStats.Instance.OnPlayerDeath += PlayerStats_OnPlayerDeath;
        PlayerStats.Instance.OnPlayerRevive += PlayerStats_OnPlayerRevive;
        enemyStats.OnEnemyDeath += EnemyStats_OnEnemyDeath;
    }

    private void PlayerStats_OnPlayerRevive(object sender, System.EventArgs e)
    {
        playerAlive = true;
    }

    private void EnemyStats_OnEnemyDeath(object sender, System.EventArgs e)
    {
        enemyAlive = false;
    }

    private void PlayerStats_OnPlayerDeath(object sender, System.EventArgs e)
    {
        playerAlive = false;
    }

    void Update()
    {

        if(Vector3.Distance(transform.position, player.position) <= 10f && playerAlive && enemyAlive)
        { 
            canFollow = true;
        } else
        {
            canFollow = false;
            animator.SetBool("Run", false);
        }

        if (canFollow)
        {
            navMeshAgent.destination = player.position;

            if (Vector3.Distance(transform.position, player.position) <= navMeshAgent.stoppingDistance && playerAlive)
            {
                animator.SetBool("Run", false);
                animator.SetTrigger("Attack");

            } else if(Vector3.Distance(transform.position, player.position) > navMeshAgent.stoppingDistance)
            {
                animator.SetBool("Run", true);
            }

        }
    }


    public void EnableHitPoint()
    {
        hitPoint.gameObject.SetActive(true);
    }

    private void DisableHitPoint()
    {

        hitPoint.gameObject.SetActive(false);
    }

    private void PlaySoundIdle()
    {
        if(playerAlive) audioSource.PlayOneShot(soundIdle);
    }

    private void PlaySoundRun()
    {
        audioSource.PlayOneShot(soundRun);
    }

    private void PlaySoundAttack()
    {
        audioSource.PlayOneShot(soundAttack);
    }

    private void PlaySoundDie()
    {
        audioSource.PlayOneShot(soundDie);
    }


}
