using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizez;
    public GameController gameController;

    private Vector3 startPosition;

    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizez);
        transform.position = startPosition + Vector3.forward * newPosition;

        if (gameController.win == true)
        {
            // I don't like having the same lines of code here but idk how else to put it
            float newPosition = Mathf.Repeat ((Time.time * scrollSpeed)*20, tileSizez) ;
            transform.position = (startPosition + Vector3.forward * Position);
        }
    }
}
