using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject RedLight;
    bool isCompleted;

    int[] powers = {3,3,2,-1};
    int result;

    private void Start() {
        int[] temp = powers;
        int tempGO;

        for (int i = 0; i < temp.Length; i++) {
            int rnd = Random.Range(0, temp.Length);
            tempGO = temp[rnd];
            temp[rnd] = temp[i];
            temp[i] = tempGO;
        }

        powers = temp;
    }


    void Update()
    {
        if(!isCompleted){
            result = 0;

            if(!Switch1.sw1)
                result += powers[0];
            if(!Switch2.sw2)
                result += powers[1];
            if(!Switch3.sw3)
                result += powers[2];
            if(!Switch4.sw4)
                result += powers[3];

            if(result == 4){
                isCompleted = true;
                StartCoroutine(StartPower());
            }
        }
    }

    IEnumerator StartPower(){

        //RedLight.SetActive(true);
        SingletonObject.instance.PlayPowerOnSound();
        SingletonObject.instance.proposedPlayerPosition = new Vector3(16.2f,1.4f,-11.14f);
        SingletonObject.instance.proposedPlayerRotation = new Vector3(0,0,0);

        yield return new WaitForSeconds(1f);
        PlayerPrefs.SetInt("FreshStart",1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("PuzzleScene");
    }
}
