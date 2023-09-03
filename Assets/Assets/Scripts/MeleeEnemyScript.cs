using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float hp;
    public float moveSpeed;


    //Targeting variables
    public float attackRange;
    public float visionDistance;
    public float closingDistance;
    private bool targetNearby;
    private Transform target;
    public LayerMask playerLayer;

    //Attack Variables
    public float cooldown;
    private float currentCooldown;
    public float attackCooldown;
    public int damage;
    public float attackLength;
    public float attackSpeed;
    public GameObject firingPosition;
    public GameObject Aimer;
    public GameObject bullet;


    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        CheckforPlayer();
        AttackCooldown();
        CheckforDay();
    }

    private void Hurt(int takenDamage)
    {
        hp-=takenDamage;
    }

    // Update is called once per frame
    void Update()
    {
        target=GameObject.FindWithTag("Player").transform;

        if(hp<=0)
        {
            int i=Random.Range(0, 4);

            if(i==3)
                GameManager.Instance.seeds++;
            Destroy(gameObject);
        }

    }

    //Move Script
    private void Move()
    {
        if(targetNearby)
        {
            if(Vector2.Distance(transform.position, target.position) > closingDistance)
            {
                transform.position=Vector2.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
            }
            if(Vector2.Distance(transform.position, target.position) < attackRange)
            {
                Attack();
            }
        }
        
        
    }

    private void Attack()
    {
        if(currentCooldown>=cooldown)
        {
            GameObject projectile = Instantiate(bullet, firingPosition.transform.position, Aimer.transform.rotation);
            projectile.GetComponent<EnemyMeleeProjectileScript>().SetStats(damage, attackLength, attackSpeed);
            currentCooldown=0;
        }
    }

    private void AttackCooldown()
    {
        if(currentCooldown<cooldown)
            currentCooldown+=Time.fixedDeltaTime;
    }

    public void Flip()
    {
        transform.Rotate(0f, 180f, 0f);
    }

    private void CheckforPlayer()
    {
        targetNearby=Physics2D.OverlapCircle(transform.position, visionDistance, playerLayer);
    }

    private void CheckforDay()
    {
        if(MoonTimer.Instance.isday)
        {
            Destroy(gameObject);
        }
    }
}
