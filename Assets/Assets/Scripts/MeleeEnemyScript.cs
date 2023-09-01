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
    public bool targetNearby;
    private Transform target;
    public LayerMask playerLayer;

    //Attack Variables
    private float currentCooldown;
    public float attackCooldown;
    private bool isAttacking;
    public int damage;


    void Awake()
    {
        rb=GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        Move();
        CheckforPlayer();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target=GameObject.FindWithTag("Player").transform;

        if(hp<=0)
        {
            Destroy(gameObject);
        }
    }

    //Move Script
    private void Move()
    {
        if(targetNearby)
        {
            if(Vector2.Distance(transform.position, target.position) > attackRange)
            {
                isAttacking=false;
                transform.position=Vector2.MoveTowards(transform.position, target.position, moveSpeed*Time.deltaTime);
            }
            else
            {
                isAttacking=true;
            }
        }
        else
        {

        }
    }

    public void Hurt(int recievedDamage)
    {
        hp-=recievedDamage;
    }

    public void Flip()
        {
            transform.Rotate(0f, 180f, 0f);
        }

    private void CheckforPlayer()
    {
        targetNearby=Physics2D.OverlapCircle(transform.position, visionDistance, playerLayer);
    }
}
