using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parentClaw : MonoBehaviour
{
    //This is the script that listens the information comes from ClawController1 and ClawController2
    
    private int speed = 5;
    public GameObject Button;
    
    [Space(10)]
    public AudioSource audioSource;

    bool isSoundPlaying;

    private void Start() {
        audioSource.loop = true;
        audioSource.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonController.buttonPresed)
        {
            if(!ClawMovement.CarTouched){
                speed = 0;
                StartCoroutine(SpacePress());
            }
        }
        
        if (ClawController.isRotating)
        {
            if(!isSoundPlaying){
                isSoundPlaying = true;
                audioSource.Play();
            }
            Vector3 Movement = new Vector3(-Input.GetAxis("Mouse Y")* speed, 0, Input.GetAxis("Mouse X")* speed);
            transform.position += Movement * speed * Time.deltaTime;
        }
        // else if (CkawController2.isRotating)
        // {
        //     if(!isSoundPlaying){
        //         isSoundPlaying = true;
        //         audioSource.Play();
        //     }
        //     Vector3 Movement = new Vector3(-Input.GetAxis("Mouse Y")* speed, 0, 0);
        //     transform.position += Movement * speed * Time.deltaTime;
        // }
        else{
            audioSource.Stop();
            isSoundPlaying = false;
        }
    }
    private IEnumerator SpacePress()
    {
        yield return new WaitForSeconds(2);
        speed = 5;
        buttonController.buttonPresed = false;
    }
}
