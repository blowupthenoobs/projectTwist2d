using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public float moveSpeed;
    public float lifeTime;
    private float lifeCountdown=0;
    public GameObject Direction;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
