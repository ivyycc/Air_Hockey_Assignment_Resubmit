using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    [Header("Canvas")]
    public GameObject CanvasGame;
    public GameObject CanvasRestart;
    public GameObject CanvasCount;
    public GameObject CanvasPortalTimer;

    [Header("CanvasRestart")]
    public GameObject WinTxt;
    public GameObject LooseTxt;

    [Header("Other")]
   
    public Scoring scoreScript;
   // public Timer TimerScript;

    public Puck puckScript;
    public PlayerMove playerMovement;
    public AI_Move aiScript;

    public void ShowCanvasRestart(bool didAiWin)
    {
        Time.timeScale = 0;

        CanvasGame.SetActive(false);
        CanvasRestart.SetActive(true);

        if (didAiWin)
        {
           
            WinTxt.SetActive(false);
            LooseTxt.SetActive(true);
        }
        else
        {
            
            WinTxt.SetActive(true);
            LooseTxt.SetActive(false);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        CanvasGame.SetActive(true);
        CanvasCount.SetActive(true);
        CanvasPortalTimer.SetActive(true);
        CanvasRestart.SetActive(false);

        //countdown.Update();
        scoreScript.ResetScores();
        puckScript.CenterPuck();
        playerMovement.ResetPosP();
        aiScript.ResetPosA();

    }

    public void PortalTimer()
    {
        CanvasPortalTimer.SetActive(true);
        //TimerScript.CanvasTimer
        //CanvasPortalTimer.SetActive(false);
    }


    /*public int playerScore { get; private set; }
    public Text playerScoreText;

    public Paddle computerPaddle;
    public int computerScore { get; private set; }
   

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            NewGame();
        }
    }

    public void NewGame()
    {
        SetPlayerScore(0);
        SetComputerScore(0);
        StartRound();
    }

    public void StartRound()
    {
        playerPaddle.ResetPosition();
        computerPaddle.ResetPosition();
        ball.ResetPosition();
        ball.AddStartingForce();
    }

    public void PlayerScores()
    {
        SetPlayerScore(playerScore + 1);
        StartRound();
    }

    public void ComputerScores()
    {
        SetComputerScore(computerScore + 1);
        StartRound();
    }

    private void SetPlayerScore(int score)
    {
        playerScore = score;
        playerScoreText.text = score.ToString();
    }

    private void SetComputerScore(int score)
    {
        computerScore = score;
        computerScoreText.text = score.ToString();
    }
    */

}
