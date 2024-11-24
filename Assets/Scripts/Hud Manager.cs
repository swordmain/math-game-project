using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ScriptHUDManager : MonoBehaviour
{
    public static ScriptHUDManager Instance;
    public ScriptHUD hud;
    private int Score;
    private float timer;
    public bool RoundActive;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timer = 30;
        Score = 0;
        RoundActive = true;
        hud.UpdateScore(Score);
        hud.ShowGameOverPanel(false);
    }
    private void Update()
    {
        if (!RoundActive)
        {
            return;
        }
        timer -= Time.deltaTime;
        if (timer <0)
        {
            timer = 0;
            RoundActive = false;
            hud.ShowGameOverPanel(true);
        }
        hud.UpdateTimer(timer);
    }

    public void AddScore(int _score=1)
    {
        Score += _score;
        hud.UpdateScore(Score);
    }
    public void ResetTimer()
    {
        timer = 30;
    }
    public void FalseAnswer()
    {
        RoundActive = false;
        hud.ShowGameOverPanel(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene("MathGame");
        RoundActive = true;
    }
}
