using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    
    //There was a problem about car position, so I solved it like this. Maybe you can create better script.
    
    public static bool carExit;
    public GameObject carTakeText;
    public static bool carOnTheGround;
    public GameObject ground;
    

    private void Start()
    {        
        carOnTheGround = false;
        carExit = false;
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Hole")
        {
            carTakeText.SetActive(true);
            Debug.Log("exit");
            carExit = true;
            
        }       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            Debug.Log("on the ground");
            GetComponent<Rigidbody>().useGravity = false;
            transform.position += new Vector3(0, 0.5f, 0);
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}
