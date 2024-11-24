using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScriptHUD : MonoBehaviour
{

    [SerializeField]
    private Text timerTxt;
    [SerializeField]
    private Text scoreTxt;
    [SerializeField]
    private GameObject gameOverPanel;

    public void ShowGameOverPanel(bool value)
    {
        gameOverPanel.SetActive(value);
    }
    public void UpdateTimer(float timer)
    {
        timerTxt.text = ((Mathf.CeilToInt(timer)).ToString());

    }

    public void UpdateScore(int score)
    {
        scoreTxt.text = score.ToString();
    }

}