using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float TimeStart = 3;
    public TMP_Text textbox;
    public GameObject CanvasCount;
   // AI_Move reset;

    private void Start()
    {
        textbox.text = TimeStart.ToString();

    }

    public void Update()
    {
        
        TimeStart -= Time.deltaTime;
        textbox.text = Mathf.Round(TimeStart).ToString();
        

        if (TimeStart < 1)
        {
            TimeStart = 0;

            textbox.text = "START!";
            CanvasCount.SetActive(false);
            //reset.ResetPosA();
        }
    }

   

}
