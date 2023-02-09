using UnityEngine;
using System;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    private Spawner spawner;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int score { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;

        player = FindObjectOfType<Player>();
        spawner = FindObjectOfType<Spawner>();
        
        Pause();
    }

    public void Play()
    {
        Console.WriteLine("Play??"); 
        score = 0;
        scoreText.text = score.ToString();

        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;
        spawner.enabled = true;


        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++) {
            Destroy(pipes[i].gameObject);
        } 
    }

    public void GameOver()
    {
        Console.WriteLine("Game Over ");

        playButton.SetActive(true);
        gameOver.SetActive(true);

       Pause();
       /*
        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }*/
    }

    public void Pause()
    {
       

        Time.timeScale = 0f;
        player.enabled = false;
       // spawner.enabled = false; 
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}
