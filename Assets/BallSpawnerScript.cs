using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawnerScript : MonoBehaviour
{

    public LogicScript Logic;
    public GameObject Ball;
    public bool AwaitingSpawn = true;
    public int SpawnInterval = 15;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Ball);
    }

    // Update is called once per frame
    void Update()
    {
        if (Logic.Rally % SpawnInterval == 0)
        {
            if (AwaitingSpawn)
            {
                Instantiate(Ball);
                AwaitingSpawn = false;
            }
        }
        else
        {
            AwaitingSpawn = true;
        }
    }

    
}
