using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject Direction;
    public float moveSpeed;
    public float lifeTime;
    private float lifeCountdown=0;
    public int damage;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SetStats(int damageStat, float lifeTimeStat, float moveSpeedStat)
    {
        damage=damageStat;
        lifeTime=lifeTimeStat;
        moveSpeed=moveSpeedStat;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, Direction.transform.position, moveSpeed);

        if(lifeCountdown<lifeTime)
            lifeCountdown+=Time.fixedDeltaTime;
        else
            Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.SendMessage("Hurt", damage);
        }

        Destroy(gameObject);
    }
}
