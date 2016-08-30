﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    public Vector3 xCon;
    public Vector3 yCon;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xCon.x, xCon.y), Mathf.Clamp(transform.position.y, yCon.x, yCon.y), transform.position.z);
	}
}
