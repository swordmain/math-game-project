using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathAnswerBlocks : MonoBehaviour
{
    public EventHandler onclick;
    public int answer;
    public Button AnswerButton;
    public Text AnswerText;

    public void Setup()
    {
        AnswerButton.onClick.RemoveAllListeners();
        AnswerButton.onClick.AddListener(() =>
        {
            onclick?.Invoke(answer, EventArgs.Empty);
        });
    }
    public void Set(int _answer)
    {
        answer = _answer;
        AnswerText.text = answer.ToString();
    }
}
