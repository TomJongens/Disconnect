using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool coinTakeable;
    public bool coinTaked;
    
    
    
    //This is the script that should be adjusted. I have a possible solution, we can create 3 coin script and give them a bool, when they become true then we can check from area entering script
    //but this may not be the best solution.
    void Awake()
    {
        coinTakeable = false;
        coinTaked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (coinTakeable == true && Input.GetKey(KeyCode.E) && coinTaked == false)
        {
            Debug.Log(coinTaked);
            coinTaked = true;
            this.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            coinTakeable = true;
            Debug.Log(coinTakeable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            coinTakeable = false;
            Debug.Log(coinTakeable);
        }
        
    }
}
