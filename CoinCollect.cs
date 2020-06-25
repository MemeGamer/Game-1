using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    // Start is called before the first frame update
void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.tag == "Player")
       {
           gameObject.SetActive(false);
        }
    }
}
