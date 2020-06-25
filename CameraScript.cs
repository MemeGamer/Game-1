﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float resetSpeed = 0.5f;
    public float cameraSpeed = 0.3f;

    public Bounds cameraBounds;
    private Transform target;
    private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;

    private bool followsPlayer; 
    // Start is called before the first frame update

    void Awake(){
        BoxCollider2D mycol = GetComponent<BoxCollider2D>();
        mycol.size = new Vector2(Camera.main.aspect * 2f *  Camera.main.orthographicSize, 5f);
        cameraBounds = mycol.bounds;
  }
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        lastTargetPosition =target.position;
        offsetZ =(transform.position - target.position).z;
        followsPlayer = true;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(followsPlayer)
        {
            Vector3 ahedTargetPos = target.position +Vector3.forward * offsetZ;

            if(ahedTargetPos.x >= transform.position.x)
            {
                Vector3 newCameraPosition = Vector3.SmoothDamp(transform.position,ahedTargetPos, ref currentVelocity, cameraSpeed);
                transform.position = new Vector3(newCameraPosition.x, transform.position.y,newCameraPosition.z);
                lastTargetPosition= target.position;
            }
        }
    }



}//class
