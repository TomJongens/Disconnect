using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleTwoManager : MonoBehaviour
{
    public GameObject puzzleTwoSuccessfulTxt;
    public GameObject puzzleTwoFailTxt;

    bool iscompleted,exiting;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            if(CarMovement.puzzleTwoFail){
                PlayerPrefs.SetInt("FreshStart",1);
                PlayerPrefs.Save();
                SceneManager.LoadScene("PuzzleScene");
            }
        }

        if (CarMovement.puzzleTwoSuccessfull && !exiting && !iscompleted)
        {
            iscompleted = true;
            Invoke("GoBack",1.5f);
            exiting = true;
        }
        if (CarMovement.puzzleTwoFail)
        {
            puzzleTwoFailTxt.SetActive(true);
        }
    }

    void GoBack(){
        PlayerPrefs.SetInt("FreshStart",1);
        PlayerPrefs.Save();
        // puzzleTwoSuccessfulTxt.SetActive(true);
        SceneManager.LoadScene("PuzzleScene");
    }
}
