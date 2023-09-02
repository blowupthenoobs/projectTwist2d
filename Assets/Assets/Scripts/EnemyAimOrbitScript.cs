using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimOrbitScript : MonoBehaviour
{
    private Transform target;
    void Awake()
    {
        
    }

    void Update()
    {
        target=GameObject.FindWithTag("Player").transform;
        Vector2 directionToPlayer=(target.transform.position - transform.position).normalized;
        transform.up=directionToPlayer;
    }
}
