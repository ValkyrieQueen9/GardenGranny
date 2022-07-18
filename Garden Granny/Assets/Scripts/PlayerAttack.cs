using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public int attackDamage = 40;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
           Attack();
        }
    }

    void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Health>().TakeDamage(attackDamage);
            
            if (!FindObjectOfType<AudioManager>().IsThisSoundPlaying(1) & enemy.GetComponent<Health>().currentHealth >= 0)
            {
                FindObjectOfType<AudioManager>().Play("HitFly");
            }
            
        }
    }

 void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
   
}


