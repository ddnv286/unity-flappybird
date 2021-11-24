using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    private int score;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public Player player;

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameOver ()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
    
    private void Awake ()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString(); 
        gameOver.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        // destroy all the 'gameObject' pipes
        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void Pause ()
    {
        // make sure the bird isn't moving or anything
        // set timescale to 0 is an easy way since everything from the player to the obstacles are affected by deltatime
        Time.timeScale = 0;
        player.enabled = false;
    }
}
