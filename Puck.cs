using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    private Rigidbody2D rbpuck;
    public Scoring ScorescriptInstance;

    private PlayerMove resetp;
    private AI_Move resetai;

    public float maxs;

    public static bool checkGoal { get; private set; }



    private void Start()
    {
        rbpuck = GetComponent<Rigidbody2D>();
        checkGoal = false;
  
    }



  

    public IEnumerator ResetPuck(bool did_Ai_Score)
    {

        yield return new WaitForSecondsRealtime(1);
        checkGoal = false;
        rbpuck.transform.position = Vector2.zero;
        rbpuck.velocity = Vector2.zero;

        if(did_Ai_Score)
        {
            rbpuck.transform.position = new Vector2(-4, 0f);
        }
        else
        {
            rbpuck.transform.position = new Vector2(4, 0f);
        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!checkGoal)
        {
            if(collision.tag == "AiGoal")
            {
                ScorescriptInstance.IncreaseScore(Scoring.Score.AiScore);
                checkGoal = false;
                StartCoroutine(ResetPuck(true));
                //resetai.ResetPosA();
                //resetp.ResetPosP();
            }
            else if(collision.tag == "PlayerGoal")
            {
                ScorescriptInstance.IncreaseScore(Scoring.Score.PlayerScore);
                checkGoal = true;
                StartCoroutine(ResetPuck(false));
                //resetp.ResetPosP();
                //resetai.ResetPosA();

            }
        }
        
    }

    public void CenterPuck()
    {
        rbpuck.position = new Vector2(0, 0);
    }


    private void FixedUpdate()
    {
        rbpuck.velocity = Vector2.ClampMagnitude(rbpuck.velocity, maxs);
    }
}
