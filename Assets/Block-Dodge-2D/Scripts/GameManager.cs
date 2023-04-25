using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float slowness = 10f;
    public bool hasGameEnded = false;
    public TMP_Text Text;
    public float score = 0f;
    public AudioSource Move;
    public AudioSource Lose;

    public void EndGame()
    {
        StartCoroutine(RestartLevel());
    }

    public void IncreaseScore(float newScore)
    {
        if (!hasGameEnded)
        {
            Move.Play();
            score += newScore;
            Text.text = score.ToString("0");
        }
    }

    IEnumerator RestartLevel()
    {
        hasGameEnded = true;
        Lose.Play();
        Time.timeScale = 1f / slowness;
        // For smoothness of the game we update the fixedDeltaTime
        Time.fixedDeltaTime = Time.fixedDeltaTime / slowness;
        // before 1 second

        // if we set the timeScale to 1f / 10f then the below 1f will become .1 * 10 => 10 seconds 
        // so dividing it by slowness so only have to wait for x/x -> 1second
        yield return new WaitForSeconds(1f / slowness);
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.fixedDeltaTime * slowness;

        // After 1 second
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
