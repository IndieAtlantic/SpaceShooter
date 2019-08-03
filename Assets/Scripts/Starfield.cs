using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Starfield : MonoBehaviour
{
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
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
            if (gameController.score >= 100)
            {
                var main1 = ps1.main;
                main1.simulationSpeed = 10.0f;
                var main2 = ps2.main;
                main2.simulationSpeed = 10.0f;
            }
        }
}
