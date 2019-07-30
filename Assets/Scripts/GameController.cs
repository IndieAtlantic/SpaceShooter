using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text creatorText;
    public Text lifeText;
    public int life;

    private bool gameOver;
    private bool restart;
    public bool win;
    private int score;
    
    
    void Start()
    {
        StartCoroutine (SpawnWaves());
        score = 0;
        UpdateScore();
        gameOver = false;
        restart = false;
        win = false;
        creatorText.text = "";
        restartText.text = "";
        gameOverText.text = "";
        winText.text = "";
        life = 3;
        lifeText.text = "Lives left: " + life;

    }
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();

        if (restart)
        {
            if (Input.GetKeyDown (KeyCode.X))
            {
                SceneManager.LoadScene("Main");
            }
        }
    }
    IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range (0,hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'X' to Restart";
                restart = true;
                break;
            }
            if (win)
            {
                restartText.text = "Press 'X' to Restart";
                restart = true;
                break;
            }
        }
    }
    public void AddScore (int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
        if (score == 100)
        {
            win = true;
            winText.text = "You win!";
            creatorText.text = "Game made by Anna Alvarez";
        }
    }
    
    void UpdateScore()
    {
    scoreText.text = "Points: " + score;
    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        gameOver = true;
    }
    
}
