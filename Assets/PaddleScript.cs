using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleScript : MonoBehaviour
{
    public LogicScript logic;
    public float Speed = 1.5f;
    private Vector3 PaddleVector;
    public KeyCode UpButton;
    public KeyCode DownButton;
    public int GetSmallerInterval = 10;
    private bool AwaitingTransform = true;

    // Start is called before the first frame update
    void Start()
    {
        SetPaddleVector(Speed);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(UpButton))
        {
            GoUp();
        }

        if (Input.GetKey(DownButton))
        {
            GoDown();
        }

        if (logic.Rally % GetSmallerInterval == 0 && logic.Rally < GetSmallerInterval * 6)
        {
            if (AwaitingTransform)
            {
                gameObject.transform.localScale -= new Vector3(0, 0.5f, 0);
                AwaitingTransform = false;
            }
        }
        else
        {
            AwaitingTransform = true;
        }

    }

    void SetPaddleVector(float speed)
    {
        PaddleVector = new Vector3(0, 1, 0) * speed * Time.deltaTime;
    }

    void GoUp()
    {
        gameObject.transform.position += PaddleVector;
    }

    void GoDown()
    {
        gameObject.transform.position -= PaddleVector;
    }



}
