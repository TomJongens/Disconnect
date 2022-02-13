using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject light1;
    public GameObject light2;
    
    private void Update()
    {
        
        
        if(AreaEntering.clawAreaEntering == true && Input.GetKeyDown("f"))
        {
           
            SceneManager.LoadScene("Puzzle1");
        }

        if (AreaEntering.puzzleTwoArea == true && Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene("Puzzle2");
        }
        if (AreaEntering.puzzleThreeArea == true && Input.GetKeyDown("f"))
        {
            SceneManager.LoadScene("Puzzle3");
        }
        
        
        if (Car.carExit)
        {
                light1.SetActive(true);
        }

        if (CarMovement.puzzleTwoSuccessfull)
        {
                light2.SetActive(true);
        }
        

    }
}
