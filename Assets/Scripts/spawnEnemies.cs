using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    private Vector3 position;
    private float spawn_timer;

    void Start()
    {
        spawn_timer = Time.time + 1.0f; //Wait a second before starting the spawning
        position = transform.position; //sets initial position of the enemy at the spawn blocks
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawn_timer)
        {
            Instantiate(enemy, position, enemy.transform.rotation);
            spawn_timer += 5.0f; //Every 5 seconds spawn
        }
    }
}
