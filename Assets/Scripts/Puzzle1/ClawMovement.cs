using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClawMovement : MonoBehaviour
{
    
    //In this script we are controlling the child claw. We are playing the claw animation when the button is pressed. If it touches the car, the car is sticking to claw. If e pressed, we releases the car.
    //we don't use go left, right, up or down commands in this script. We are using them in the parentClaw script.

    
    
    
    private int speed = 1;

    public GameObject Claw;   
    public GameObject FollowPoint;
    public GameObject car;
    public GameObject carDropText;
    
    public Transform parentClaw;
    
    public static bool CarTouched;

    [Space(10)]
    public AudioSource audioSource1;
    public AudioSource audioSource2;

    public AudioClip pickCarClip;

    [Space(10)]
    public ClawCapture clawCapture;

    bool isSoundPlaying, carCaught;

    private void Start()
    {
        CarTouched = false;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        audioSource1.playOnAwake = false;
        audioSource2.playOnAwake = false;
        audioSource1.loop = true;
        audioSource2.loop = false;
    }

    void Update()
    {
        //Vector3 Movement = new Vector3(-Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        //transform.position += Movement * speed * Time.deltaTime;

        if (CarTouched == false && buttonController.buttonPresed && !carCaught)
        {          
            Claw.GetComponent<Animator>().Play("ClawMachineDown");
            buttonController.buttonPresed = false;
            if(!isSoundPlaying){
                isSoundPlaying = true;
                audioSource1.Play();
                StartCoroutine(StopSound());
            }
        }
        if (CarTouched)
        {
            car.transform.position = FollowPoint.transform.position;
            //carDropText.SetActive(true);
            car.GetComponent<Rigidbody>().isKinematic = false;
            if(buttonController.buttonPresed){
                clawCapture.OpenClaw();
                carDropText.SetActive(false);
                CarTouched = false;
                car.GetComponent<Rigidbody>().useGravity = true;   
            }
            // if (Input.GetKey("e"))
            // {
            //     clawCapture.OpenClaw();
            //     carDropText.SetActive(false);
            //     CarTouched = false;
            //     car.GetComponent<Rigidbody>().useGravity = true;          
            // }

        }

        if(Car.carExit && Input.GetKey("f"))
        {
            PlayerPrefs.SetInt("FreshStart",1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("PuzzleScene");
        }
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Car")
        {
            Debug.Log("Car");
            //if(!CarTouched){
                changeParent(); 
            //}                      
        }
        if (other.tag == "pineaplle" || other.tag == "Star" || other.tag == "Robot")
        {            
            Destroy(other.gameObject);
        }
    }
    
    public void changeParent()
    {
        CarTouched = true;
        carCaught = true;
        audioSource2.PlayOneShot(pickCarClip);
        //Claw.GetComponent<Animator>().Play("ClawCaptureAnimation");
        clawCapture.CaptureClaw();
    }

    IEnumerator StopSound(){
        yield return new WaitForSeconds(2f);
        isSoundPlaying = false;
        audioSource1.Stop();
    }
}