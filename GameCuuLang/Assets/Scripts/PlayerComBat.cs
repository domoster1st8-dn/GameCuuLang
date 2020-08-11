using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComBat : MonoBehaviour
{
    public Animator animator;
    public Transform attackpoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 10;

    public float attackRate = 2f;
    float nextAttackTime = 0f;

    bool attacking = false;
    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Z) && !attacking)
        {
            attacking = true;
            nextAttackTime = 0.3f;
        }
        if (attacking)
        {
            if(nextAttackTime > 0)
            {
                nextAttackTime -= Time.deltaTime;
            }
            else
            {
                attacking = false;
            }
        }
        
        animator.SetBool("Attack",attacking);
    }
    void Attack()
    {
        
        Collider2D[] colliders = Physics2D.OverlapCircleAll(attackpoint.position, attackRange, enemyLayers);
        foreach(Collider2D enemy in colliders)
        {
            enemy.SendMessageUpwards("TakeDamage", attackDamage);
            //enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }
    //ve duong tron cho diem point attack
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return;
        
        Gizmos.DrawWireSphere(attackpoint.position, attackRange);
    }
}
