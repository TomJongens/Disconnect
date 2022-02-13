using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ClawCapture : MonoBehaviour
{

    public Transform clawDown,clawLeft,clawRight,clawUp;

    float timeDuration = 0.5f;



    public void CaptureClaw(){
        clawDown.DOLocalRotate(new Vector3(-128f,0,-47.753f),timeDuration);
        clawLeft.DOLocalRotate(new Vector3(-129.01f,78.309f,-130.82f),timeDuration);
        clawRight.DOLocalRotate(new Vector3(-128.13f,-97.231f,51.768f),timeDuration);
        clawUp.DOLocalRotate(new Vector3(-49.4f,0,-47.758f),timeDuration);
    }

    public void OpenClaw(){
        clawDown.DOLocalRotate(new Vector3(-89.96f,0,-47.753f),timeDuration);
        clawLeft.DOLocalRotate(new Vector3(-89.98f,0,-47.758f),timeDuration);
        clawRight.DOLocalRotate(new Vector3(-89.98f,0,-47.758f),timeDuration);
        clawUp.DOLocalRotate(new Vector3(-89.98f,0,-47.758f),timeDuration);
    }
}
