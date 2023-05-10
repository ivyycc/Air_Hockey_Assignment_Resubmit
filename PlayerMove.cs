using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extension
{
    public static Vector2 AsVector2(this Vector3 _v)
    {
        return new Vector2(_v.x, _v.y);
    }
}

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D prb;
    GameObject puckObj;
    bool wasJustClicked = true;
    bool canMove;

    public Transform Boundary;
    BoundaryHolder playerB;

    public Rigidbody2D obj;

    //Vector2 offset;
    //Vector2 mousePos;
    //Vector2 newMousePos;

    Collider2D collider;
    Vector2 startPos;

    [SerializeField] Scoring minuspoints;
    int counter = 0 ;

   
    

    // Start is called before the first frame update
    void Start()
    {
        prb = GetComponent<Rigidbody2D>();
        startPos = prb.position;
        collider = GetComponent<Collider2D>();
        puckObj = GameObject.FindWithTag("Puck");

        playerB = new BoundaryHolder(Boundary.GetChild(0).position.y, Boundary.GetChild(1).position.y, Boundary.GetChild(2).position.x, Boundary.GetChild(3).position.x);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (wasJustClicked)
            {
                wasJustClicked = false;

                if (collider.OverlapPoint(mousePos))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
            }

            if (canMove)
            {
                Vector2 clampedMousePos = new Vector2(Mathf.Clamp(mousePos.x, playerB.left,
                                                                  playerB.right),
                                                      Mathf.Clamp(mousePos.y, playerB.bottom,
                                                                  playerB.top));
                
                prb.MovePosition(clampedMousePos);

               
              
            }
        }
        else
        {
            wasJustClicked = true;
        }
      
    }

  

    private void minusScore()
    {

       minuspoints.DecreaseScore(Scoring.Score.PlayerScore);

    }

    public void ResetPosP()
    {
        prb.transform.position = startPos;
        prb.velocity = Vector2.zero;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == puckObj)
        {
            counter++;
            Debug.Log("Puck hit Player");
            if (counter > 1)
            {
                minusScore();
            }
        }

    }

}
