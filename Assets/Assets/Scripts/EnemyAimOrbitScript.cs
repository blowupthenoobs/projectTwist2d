using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAimOrbitScript : MonoBehaviour
{
    private Transform target;
    private bool frozen = false;
    void Awake()
    {
        
    }

    void Update()
    {
        if(!frozen)
        {
            target=GameObject.FindWithTag("Player").transform;
            Vector2 directionToPlayer=(target.transform.position - transform.position).normalized;
            transform.up=directionToPlayer;
        }
        
    }

    public void Freeze()
    {
        frozen=true;
    }

    public void UnFreeze()
    {
        frozen=false;
    }
}
