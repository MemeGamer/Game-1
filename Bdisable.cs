using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bdisable : MonoBehaviour
{
    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "G1")
       {
           gameObject.SetActive(false);
        }
    }
}
