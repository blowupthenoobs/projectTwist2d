using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHeal : MonoBehaviour
{
    Collider2D collider;
    private Player playerHP;

    void Start(){
        collider = GetComponent<Collider2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerHP = player.GetComponent<Player>();
    }

    public void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player" && playerHP.hp < playerHP.maxhp){
            Destroy(gameObject);
        }
    }
}
