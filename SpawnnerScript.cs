using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnnerScript : MonoBehaviour
{
    public GameObject bombPrefab2;
    private float minX=-2.23f;
    private float maxX=2.85f;
    void Start()
    {
        StartCoroutine (SpawnBoombs());
    }

    IEnumerator SpawnBoombs(){
         yield return new WaitForSeconds (Random.Range(0f,1.5f));
        Instantiate (bombPrefab2, new Vector2(Random.Range(minX, maxX), transform.position.y),Quaternion.identity);
        StartCoroutine (SpawnBoombs());
    }

}
