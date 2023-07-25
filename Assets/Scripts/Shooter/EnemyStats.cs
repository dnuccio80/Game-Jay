using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;
public class EnemyStats : BulletTarget
{

    
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private GameObject enemyVisual;
    [SerializeField] private float timePerDessapear;
    [SerializeField] private float timePerDestroy;

    public event EventHandler OnEnemyDeath;

    public override void ProjectileStashed()
    {
        life--;
        animator.SetTrigger("Hit");
        if (life <= 0)
        {
            OnEnemyDeath?.Invoke(this, EventArgs.Empty);
            animator.SetTrigger("Die");
            particles.Play();
            Destroy(GetComponent<CapsuleCollider>());
            Destroy(GetComponent<NavMeshAgent>());
            Invoke("DessapearEnemy", timePerDessapear);
            Invoke("DestroyEnemy", timePerDestroy);
        }
    } 

    private void DessapearEnemy()
    {
        enemyVisual.SetActive(false);
        Destroy(GetComponent<NavMeshEnemies>());
        

    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

   
}
