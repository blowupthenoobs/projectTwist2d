using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    private bool isNight;
    public Transform[] spawnLocations;
    public GameObject[] monster;
    public Transform player;
    public float minDistanceFromPlayer;
    public int Index;

    public float spawnTime;
    public float cooldown;
    public int maxMonsterSpawn;

    void Awake()
    {
        player=GameObject.FindWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if(cooldown>spawnTime)
            cooldown+=Time.fixedDeltaTime;
        else
        {
            cooldown=0;
            SpawnMonsters(Random.Range(1, maxMonsterSpawn));
        }
    }

    private void SpawnMonsters(int x)
    {
        for(int i=0; i<=x; i++)
        {
            Index=Random.Range(0,spawnLocations.Length);

            while(Vector2.Distance(spawnLocations[Index].position, player.position)<minDistanceFromPlayer)
                Index=Random.Range(0,spawnLocations.Length);

            Instantiate(monster[Random.Range(0, monster.Length)], spawnLocations[Index].position, transform.rotation);
        }
        
    }
}
