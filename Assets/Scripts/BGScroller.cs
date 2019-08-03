﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizez;
    public GameController gameController;
    public float newPosition;
    

    private Vector3 startPosition;

    void Start()
    {

        startPosition = transform.position;
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void Update()
    {
        if (gameController.win == true)
        {

            newPosition = Mathf.Repeat((Time.time * scrollSpeed) * 30, tileSizez);
            transform.position = (startPosition + Vector3.forward * newPosition);
        }
        else
        {
            newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizez);
            transform.position = startPosition + Vector3.forward * newPosition;
        }
    }
    
}

