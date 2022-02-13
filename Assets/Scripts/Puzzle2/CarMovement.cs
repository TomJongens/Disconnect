using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    
    //In this script, I used empty game objects and gave them colliders and set them as a trigger. When the car enters the triggers, it changes its rotation or getting destroyed. 
    public static bool puzzleTwoSuccessfull;
    public static bool puzzleTwoFail;
    private float SpeedX;
    private float SpeedY;
    private float SpeedZ;

    private float RotateX;
    private float RotateY;
    private float RotateZ;

    [Space(10)]
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioClip carPassed, carFailed;

    bool canMove;


    private void Start()
    {
        puzzleTwoSuccessfull = false;
        puzzleTwoFail = false;
        SpeedZ = -0.005f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        canMove = true;
    }
    void Update()
    {
        MovementCar();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Corner1")
        {
            SpeedZ = 0;
            SpeedX = 0.005f;
            RotateY = -90;
            RotateCar();
        }
        
        if(other.tag == "Corner2")
        {
            SpeedX = 0;
            SpeedZ = 0.005f;
            RotateY = -90;
            RotateCar();
        }
        if(other.tag == "Corner3")
        {
            SpeedZ = 0;
            SpeedX = 0.005f;
            RotateY = 90;
            RotateCar();
        }
        if (other.tag == "Corner4")
        {
            SpeedX = 0;
            SpeedZ = -0.005f;
            RotateY = 90;
            RotateCar();
        }
        if (other.tag == "Corner5")
        {
            SpeedZ = 0;
            SpeedX = 0.005f;
            RotateY = -90;
            RotateCar();
        }
        if (other.tag == "Corner6")
        {
            SpeedX = 0;
            SpeedZ = 0.005f;
            RotateY = -90;
            RotateCar();
        }
        if (other.tag == "Corner7")
        {
            SpeedZ = 0;
            SpeedX = 0.005f;
            RotateY = 90;
            RotateCar();
        }
        if (other.tag == "Corner8")
        {
            SpeedX = 0;
            SpeedZ = -0.005f;
            RotateY = 90;
            RotateCar();
        }
        if (other.tag == "Obstacle")
        {
            audioSource1.Stop();
            audioSource2.PlayOneShot(carFailed);
            puzzleTwoFail = true;
            canMove = false;
            Invoke("DestroyCar",2f);
            ClawMovement.CarTouched = false;
            Car.carExit = false;
            AreaEntering.puzzleTwoArea = false;
            AreaEntering.clawAreaEntering = false;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PuzzleTwoFinish")
        {
            puzzleTwoSuccessfull = true;
            canMove = false;
            audioSource1.Stop();
            audioSource2.PlayOneShot(carPassed);
            Debug.Log("puzzle two accamplished successfully");
            Invoke("DestroyCar",2f);
        }
    }

    void DestroyCar(){
        Destroy(this.gameObject);
    }

    void MovementCar()
    {
        if(canMove)
            transform.position += new Vector3(SpeedX, SpeedY, SpeedZ) * 2f;
    } 
    void RotateCar()
    {
        if(canMove)
            this.transform.Rotate(RotateX, RotateY, RotateZ, Space.World);
    }
    
}
