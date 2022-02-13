using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SingletonObject : MonoBehaviour
{
    public static SingletonObject instance;

    public AudioSource audioSource;
    public AudioClip powerOnClip;

    public Vector3 proposedPlayerPosition;
    public Vector3 proposedPlayerRotation;

    public GameObject redLight;

    public Transform box;

    private void Awake() {
		if (instance != null) {
			Destroy(gameObject);
		}else{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}

    // Start is called before the first frame update
    void Start()
    {
        
    }

    internal void PlayPowerOnSound(){
        redLight.SetActive(true);
        audioSource.PlayOneShot(powerOnClip);
        StartCoroutine(GameEnd());
        MainMenu.instance.isGamePlaying = false;
    }

    IEnumerator GameEnd(){
        yield return new WaitForSeconds(3f);

        box.DOMoveY(40,10f);
    }
}
