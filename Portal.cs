using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{

    [SerializeField] GameObject Portal1;
    [SerializeField] GameObject Portal2;

    [SerializeField] GameObject puck;


    float x1;
    float y1;

    float x2;
    float y2;



    void Start()
    {
        puck = GameObject.FindWithTag("Puck");

        Portal2 = GameObject.FindWithTag("PortalExit");
        Portal1 = GameObject.FindWithTag("PortalEnter");

      /*  GameObject newObj = Instantiate(Portal1, transform.position, Quaternion.identity);
        GameObject newObj2 = Instantiate(Portal2, transform.position, Quaternion.identity);
        newObj.transform.parent = transform;
        newObj2.transform.parent = transform;*/

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Puck")
        {
           if(Vector2.Distance(puck.transform.position, Portal1.transform.position)> 0.3f )
          
                {
                    Debug.Log("Puck has entered portal1");
                    puck.transform.position = Portal2.transform.position;
                }
           else if(Vector2.Distance(puck.transform.position, Portal2.transform.position) > 0.3f)
                {
                    Debug.Log("Puck has entered portal2");
                    puck.transform.position = Portal1.transform.position;
                }
   

        }

        

    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Puck")
        {
            StartCoroutine(Wait());
            Destroy(Portal1, 16);
            Destroy(Portal2, 16);

            for(int i = 0; i<3; i++)
            {
               
                StartCoroutine(Wait());
                ResetPortal();
                Instantiate(Portal1);
                Instantiate(Portal2);
                Destroy(Portal2, 16);
                Destroy(Portal1, 16);
                //Destroy(Portal1, 16);
            }
            
            
            
        }


    }


    private void Update()
    {
        

        StartCoroutine(Wait());

        x1 = Random.Range(-3.4f, 3.4f);
        y1 = Random.Range(-2.3f, 2.33f);

        y2 = Random.Range(-3.1f, 3.1f);
        x2 = Random.Range(-2.7f, 2.7f);

    }
    public IEnumerator ResetPortal()
    {

        yield return new WaitForSecondsRealtime(2);

        Portal1.transform.position = new Vector2(x1, y1);
        Portal2.transform.position = new Vector2(x2, y2);


    }

    public IEnumerator Wait()
    {

        yield return new WaitForSecondsRealtime(5);
    }



    /*if (Time.time > lastSpawnTime + frequency)
        {
            GameObject newObj = Instantiate(Portal1, transform.position, Quaternion.identity);
            GameObject newObj2 = Instantiate(Portal2, transform.position, Quaternion.identity);
            newObj.transform.parent = transform;
            newObj2.transform.parent = transform;
            lastSpawnTime = Time.time;
        }*/
}

