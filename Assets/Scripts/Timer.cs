using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text ScoreText;
    public float SpeedBonus;
    private float startTime;
    private bool finish = false;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if(finish)
        {
            return;
        }
        ScoreCount();
        SpeedBonusCount();
    }

    public void Finish()
    {
        finish = true;
    }

    public void ScoreCount()
    {
        float t = Time.time - startTime;
        int scoreT = (int)t;
        string score = (scoreT * 100).ToString();
        ScoreText.text = score;
    }

    public void SpeedBonusCount()
    {
        float v = Time.time - startTime;

        if (v > 5)
        {
            SpeedBonus = 0.5f;
        }
        if (v > 10)
        {
            SpeedBonus = 1f;
        }
        if (v > 15)
        {
            SpeedBonus = 1.5f;
        }
    }
}
