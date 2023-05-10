using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Move : MonoBehaviour
{
    public float MaxMoveSpeed;
    private Rigidbody2D rb;
    private Vector2 startPoint;

    public Rigidbody2D Puckrb;

    [SerializeField]
    public Transform AIBounds;

    private BoundaryHolder AIB;


    [SerializeField]
    public Transform PuckBounds;

    private BoundaryHolder PuckBH;

    private Vector2 targetPos;
    Collider2D collision;

    private bool isFirstTime = true;
    private float offset;

    [SerializeField] Scoring minusscore;
    public int counter;
    //[SerializeField]
    GameObject puckObject;
    Countdown countdown;

    [SerializeField]
    GameManager gm;


    [SerializeField]
    Portal resetPortal1, resetPortal2;
    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPoint = new Vector2(4f, 0);
        puckObject = GameObject.FindWithTag("Puck");

        AIB = new BoundaryHolder(AIBounds.GetChild(0).position.y, AIBounds.GetChild(1).position.y, AIBounds.GetChild(2).position.x, AIBounds.GetChild(3).position.x);

        PuckBH = new BoundaryHolder(PuckBounds.GetChild(0).position.y, PuckBounds.GetChild(1).position.y, PuckBounds.GetChild(2).position.x, PuckBounds.GetChild(3).position.x);
        //countdown.Update();

    }

    private void FixedUpdate()
    {
        float moveSpeed;

            if (!Puck.checkGoal)
            {
                if (Puckrb.position.y < PuckBH.bottom)
                {
                    if (isFirstTime)
                    {
                        isFirstTime = false;
                        offset = Random.Range(-3f, 3f);
                    }
                    moveSpeed = MaxMoveSpeed * Random.Range(0.1f, 0.3f);
                    targetPos = new Vector2(Mathf.Clamp(Puckrb.position.x + offset, PuckBH.left, PuckBH.right), startPoint.y);

                }
                else
                {
                    isFirstTime = true;

                    moveSpeed = Random.Range(MaxMoveSpeed * 0.4f, MaxMoveSpeed);
                    targetPos = new Vector2(Mathf.Clamp(Puckrb.position.x, PuckBH.left, PuckBH.right), Mathf.Clamp(Puckrb.position.y, PuckBH.bottom, PuckBH.top));

                }



                StartCoroutine(Wait_AI());

                rb.MovePosition(Vector2.MoveTowards(rb.position, targetPos, moveSpeed * Time.deltaTime));
                
           
            

            }


           
        
    }

    public void ResetPosA()
    {
        rb.transform.position = startPoint;
        rb.velocity = Vector2.zero;

    }

    public IEnumerator Wait_AI()
    {

        yield return new WaitForSecondsRealtime(5);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == puckObject)
        {
            counter++;
            Debug.Log("Puck hit AI");
            if (counter > 1)
            {
                minus();
            }
        }
    }


    private void Update()
    {
        if (Input.GetKey("w"))
        {
            gm.RestartGame();
            resetPortal1.ResetPortal();
            resetPortal2.ResetPortal();
        }
    }

    private void minus()
    {

       minusscore.DecreaseScore(Scoring.Score.PlayerScore);

    }
}


