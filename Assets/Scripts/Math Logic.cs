using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class MathLogic : MonoBehaviour
{
    [SerializeField]
    private Text TestTxt;
    private int X, Op1, Y;
    private int Step1;
    private int Answer, FalseAnswer1, FalseAnswer2;
    private int FalseAnswerLogic1, FalseAnswerLogic2;
    private string OperatorString1;
    public List<MathAnswerBlocks> AnswerBlockList;
    private List<int> PossibleAnswer;
    void Start()
    {
        foreach (var block in AnswerBlockList)
        {
            if (block == null) continue;
            block.onclick += CheckAnswer;
            block.Setup();
        }
        Generate();
        UpdateTest();
    }

    private void CheckAnswer(object sender, System.EventArgs e)
    {
        if (!ScriptHUDManager.Instance.RoundActive) return;
        int answer = (int)sender;
        if (answer == Answer)
        {
            ScriptHUDManager.Instance.AddScore();
            ScriptHUDManager.Instance.ResetTimer();
        } else
        {
            ScriptHUDManager.Instance.FalseAnswer();
        }
        Generate();
        UpdateTest();
    }

    void Update()
    {
    }
    public void Generate()
    {
        PossibleAnswer = new List<int>();
        int Rep1, Rep2;
        X = Random.Range(1, 21);
        Y = Random.Range(1, 21);
        Op1 = Random.Range(0, 4);
        FalseAnswerLogic1 = Random.Range(0, 3);
        FalseAnswerLogic2 = Random.Range(0, 3);
        if (Op1 == 0)
        {
            Step1 = X + Y;
            OperatorString1 = "+";
        }
        if (Op1 == 1)
        {
            if (Y > X)
            {
                Rep1 = X + Y;
                X = Rep1;
            }
            Step1 = X - Y;
            OperatorString1 = "-";
        }
        if (Op1 == 2)
        {
            Step1 = X * Y;
            OperatorString1 = "*";
        }
        if (Op1 == 3)
        {
            if (X % Y != 0)
            {
                Rep1 = X * Y;
                X = Rep1;
            }
            Step1 = X / Y;
            OperatorString1 = "/";
        }
        Answer = Step1;
        PossibleAnswer.Add(Answer);
        if (FalseAnswerLogic1 == 0)
        {
            FalseAnswer1 = Answer + 1;
        }
        if (FalseAnswerLogic1 == 1)
        {
            FalseAnswer1 = Answer + 10;
        }
        if (FalseAnswerLogic1 ==2)
        {
            FalseAnswer1 = Answer + 11;
        }
        if (FalseAnswerLogic2 == 0)
        {
            FalseAnswer2 = Answer - 1;
            if (FalseAnswer2 <=0)
            {
                Rep1= (Answer + FalseAnswer2) - (Answer - FalseAnswer2) + 1;
                FalseAnswer2 = Rep1;
            }
        }
        if (FalseAnswerLogic2 == 1)
        {
            FalseAnswer2 = Answer / 2;
            if (Answer % 2 !=0)
            {
                Rep1 = Random.Range(1, 6);
                Rep2 = (Answer * Rep1 * 2) / 2;
                FalseAnswer2 = Rep2;
            }
        }
        if (FalseAnswerLogic2 == 2)
        {
            FalseAnswer2 = Answer - 13;
            if (FalseAnswer2 <= 0)
            {
                Rep1= (Answer + FalseAnswer2) - (Answer - FalseAnswer2);
                FalseAnswer2 = Rep1;
            }
        }
        PossibleAnswer.Add(FalseAnswer1);
        PossibleAnswer.Add(FalseAnswer2);
        PossibleAnswer.Shuffle(); //ngecall ListExtension
        for (int i=0; i<AnswerBlockList.Count; i++)
        {
            AnswerBlockList[i].Set(PossibleAnswer[i]);
        }
    }
    public void UpdateTest()
    {
        TestTxt.text = string.Format("{0}{1}{2}=", X, OperatorString1, Y);

    }
    public void TestLogic()
    {
        int AnswerRNG;
        AnswerRNG = Random.Range(0, 2);
    }
}
