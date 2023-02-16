using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private BallSpawnerScript Spawner;
    public Rigidbody2D body;
    public float speed = 3;
    private LogicScript logic;
    public int SpeedUpInterval = 5;
    public float AccelerateBy = 1.5f;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        Spawner = GameObject.FindGameObjectWithTag("Spawner").GetComponent<BallSpawnerScript>();

        body.velocity = (direction + Vector3.up) * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.GameIsOver)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            logic.IncrementRally();
            Debug.Log(logic.Rally);

            if (logic.Rally % Spawner.SpawnInterval == 0)
            {
                body.velocity /= Mathf.Pow(AccelerateBy, Spawner.SpawnInterval / SpeedUpInterval);
            }

            if (logic.Rally % SpeedUpInterval == 0)
            {
                body.velocity *= AccelerateBy;
            }
        }

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RedWins")
        {
            Debug.Log("Red wins!");
            logic.GameOver("RED WINS");
        }

        if (collision.tag == "BlueWins")
        { 
            Debug.Log("Blue wins!");
            logic.GameOver("BLUE WINS");
        }
    }
}
