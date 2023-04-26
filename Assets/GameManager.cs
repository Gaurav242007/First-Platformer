using UnityEngine;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text Text;
    public int score = 0;
    public AudioSource Music;

    public void Start()
    {
        Music.Play();
        Text.text = score.ToString("0");
    }

    public void IncreaseScore(int newScore)
    {
            score += newScore;
            Text.text = score.ToString("0");
    }
    

}
