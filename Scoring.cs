using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class Scoring : MonoBehaviour
{
    public enum Score
    {
        AiScore, PlayerScore
    }

    public TMP_Text AiScoreTxt, PlayerScoreTxt;
    private int aiScore, playerScore;
    private int maxPoints = 5;

    public GameManager gM;



    public void IncreaseScore(Score whichScore)
    {
        if (whichScore == Score.AiScore)
        {
            AiScore++;
            AiScoreTxt.text = AiScore.ToString();
        }
            
        else if (whichScore == Score.PlayerScore)
        {
            PlayerScore++;
            PlayerScoreTxt.text = PlayerScore.ToString();
        }
            
    }

    private int AiScore
    {
        get { return aiScore; }
        set
        {
            aiScore = value;
            if (value == maxPoints)
            {
                gM.ShowCanvasRestart(true);
            }

        }
    }

    private int PlayerScore
    {
        get { return playerScore; }
        set
        {
            playerScore = value;
            if (value == maxPoints)
            {
                gM.ShowCanvasRestart(false);
            }

        }
    }

    public void ResetScores()
    {
        AiScore = 0;
        PlayerScore = 0;
        AiScoreTxt.text = PlayerScoreTxt.text = "0";
    }

    public void DecreaseScore(Score whichOne)
    {
        if (whichOne == Score.AiScore)
        {
            if(AiScore >2)
            {
                AiScore--;
                AiScoreTxt.text = AiScore.ToString();
            }
            
        }

        else if (whichOne == Score.PlayerScore)
        {
            if(PlayerScore >2)
            {
                PlayerScore--;
                PlayerScoreTxt.text = PlayerScore.ToString();
            }
           
        }

    }






}
