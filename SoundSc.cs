using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSc : MonoBehaviour
{
    private AudioSource audioManager;
     void Awake()
    {
        audioManager = GetComponent<AudioSource>();
    }
    void Update()
    {

        Playerjump();
    }
   void  Playerjump()
    {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                audioManager.Play();
            }
        }
}
