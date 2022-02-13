using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonController : MonoBehaviour
{
    
    //In this script, we can control the button in the claw machine.
   
    
    private Vector3 startPos;
    public static bool buttonPresed;

    private void Start()
    {
        startPos = transform.position;
        buttonPresed = false;
    }
    
    private void OnMouseDown()
    {
        buttonPresed = true;
        transform.position += new Vector3(0, -0.03f, 0);
        StartCoroutine(ButtonPress());
        gameObject.GetComponent<SoundEffectPlayer>().PlayEffect(0);
    }

    private IEnumerator ButtonPress()
    {        
        yield return new WaitForSeconds(1);
        transform.position = startPos;       
    }
}
