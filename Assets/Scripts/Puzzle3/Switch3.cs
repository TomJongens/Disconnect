using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch3 : MonoBehaviour
{
   public  int clickTime = 0;

    public GameObject rightDegree;
    public GameObject leftDegree;
    public static bool sw3  = true;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    private void OnMouseDown()
    {
        clickTime++;
        gameObject.GetComponent<SoundEffectPlayer>().PlayEffect(0);
        
        if(clickTime % 2 == 0 )
        {    
            rightDegree.transform.Rotate(0,0,15f, Space.World);
            leftDegree.transform.Rotate(0,0, 30f, Space.World);
            this.transform.Rotate(45.0f, 0, 0.0f, Space.World);
            sw3 = true;
        }
        if(clickTime%2 == 1 )
        {
            rightDegree.transform.Rotate(0,0, -15f, Space.World);
            leftDegree.transform.Rotate(0,0, -30f, Space.World);
            this.transform.Rotate(-45.0f, 0, 0.0f, Space.World);
            sw3 = false;
        }
    }
}

