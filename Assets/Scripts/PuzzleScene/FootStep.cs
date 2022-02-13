using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    
    //this is the script that we are generating food steps. 
    private CharacterController cc;
    
    private AudioSource source;

    public AudioClip[] Sounds;
    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (cc.velocity.magnitude > 1 && GetComponent<AudioSource>().isPlaying == false)
        {
            source.clip = Sounds[Random.Range(0, Sounds.Length)];
            source.volume = Random.Range(0.6f, 0.9f);
            source.pitch = Random.Range(0.7f, 0.9f);
            source.Play();
        }
    }
}
