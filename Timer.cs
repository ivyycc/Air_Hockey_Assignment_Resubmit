using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour 
{
    public float start = 15;
    public TMP_Text textbox;
    public GameObject CanvasTimer;
    //private int howOften; 

    private void Start()
    {
      
      
      CanvasTimer.SetActive(false);

      StartCoroutine(Wait());

      CanvasTimer.SetActive(true);
      
      textbox.text = start.ToString();

    }

    public void Update()
    {
        
      start -= Time.deltaTime;

        //if(Mathf.Round(start) == 15)
       // {
           // start -= Time.deltaTime;
            textbox.text = Mathf.Round(start).ToString();

            if (start < 1)
            {
                textbox.text = "end!";
                CanvasTimer.SetActive(false);
                start = 0;
            }
       // }
        

    }

    public IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(3);
    }
}

