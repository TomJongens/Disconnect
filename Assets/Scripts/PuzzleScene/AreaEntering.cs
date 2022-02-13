using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEntering : MonoBehaviour
{
    public GameObject Coin;
    
    
    public static bool clawAreaEntering = false;
    public static bool puzzleTwoArea = false;
    public static bool puzzleThreeArea = false;

    public GameObject clawText;
    public GameObject puzzle2Text;
    public GameObject puzzle3Text;
    public GameObject inCompletePuzzle2;
    public GameObject inCompletePuzzle3;


    private void Start()
    {
      
    }
    
    //These are the conditions that you can enter the scenes. For now, collecting money algorithm did not finish. Probably, I will change the "coin" script and apply to the project.

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("clawArea")&&Coin.GetComponent<Coin>().coinTaked  ==true )
        {
            Debug.Log("Entered claw machine area");
            clawAreaEntering = true;
            Debug.Log(clawAreaEntering);
            clawText.SetActive(true);
        }

        if (other.CompareTag("PuzzleArea") && Car.carExit)
        {
            puzzle2Text.SetActive(true);
            puzzleTwoArea = true;
        }
        if (other.CompareTag("PuzzleArea") && Car.carExit == false)
        {
            Debug.Log("you can not enter puzzle2 area");
            inCompletePuzzle2.SetActive(true);
        }
        if (other.CompareTag("Puzzle3") && CarMovement.puzzleTwoSuccessfull )
        {
            Debug.Log("you can enter puzzle3");
            puzzleThreeArea = true;
            puzzleTwoArea = false;
            clawAreaEntering = false;
            puzzle3Text.SetActive(true);
        }
        if (other.CompareTag("Puzzle3") && CarMovement.puzzleTwoSuccessfull == false )
        {
            inCompletePuzzle3.SetActive(true);
            puzzleThreeArea = false;
        }
    }

   

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("clawArea"))
        {
            Debug.Log("Exited claw machine area");
            clawAreaEntering = false;
            clawText.SetActive(false);
            Debug.Log(clawAreaEntering);
        }
        if (other.CompareTag("PuzzleArea") && Car.carExit == true)
        {
            puzzle2Text.SetActive(false);
            puzzleTwoArea = false;
            Debug.Log("puzzle2area =" + puzzleTwoArea);
        }
        if (other.CompareTag("PuzzleArea") && Car.carExit == false)
        {         
            inCompletePuzzle2.SetActive(false);
        }
        if (other.CompareTag("Puzzle3") && CarMovement.puzzleTwoSuccessfull )
        {
            puzzle3Text.SetActive(false);
        }
        if (other.CompareTag("Puzzle3") && CarMovement.puzzleTwoSuccessfull == false )
        {
            inCompletePuzzle3.SetActive(false);
        }
    }
}
