using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public GameObject highlighter;

    private void Start() {
        highlighter.SetActive(false);
    }

    private void OnMouseEnter() {
        highlighter.SetActive(true);
    }

    private void OnMouseExit() {
        highlighter.SetActive(false);
    }

    private void OnMouseDown()
    {
        this.transform.Rotate(0, 90.0f, 0.0f, Space.World);
        gameObject.GetComponent<SoundEffectPlayer>().PlayEffect(1);
    }
}
