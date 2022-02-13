using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

   public static MainMenu instance;

   public PlayerController playerController;

   internal bool isGamePlaying;

   private void Start() {
      instance = this;
      playerController.enabled = false;

      int isFreshStart = PlayerPrefs.GetInt("FreshStart",0);
      if(isFreshStart == 0){
         playerController.enabled = false;
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;
      }
      else{
         playerController.enabled = true;
         PlayerPrefs.SetInt("FreshStart",0);
         PlayerPrefs.Save();
         gameObject.SetActive(false);
      }
   }

   public void StartGame()
   {
      playerController.enabled = true;
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      gameObject.SetActive(false);
   }

   public void QuitGame()
   {
      Application.Quit();
   }
}
