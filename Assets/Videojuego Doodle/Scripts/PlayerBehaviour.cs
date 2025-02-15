﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerBehaviour : MonoBehaviour {

	Rigidbody2D rb;
	float movement = 0f;
	public float movementSpeed = 10f;

	private float minX = -9.46f; 
	private float maxX = 9.46f;

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		movement = Input.GetAxis("Horizontal") * movementSpeed;
	}

	void FixedUpdate()
	{
		rb.linearVelocity = new Vector2(movement, rb.linearVelocity.y);
		if (transform.position.x > maxX)
		{
			
			transform.position = new Vector3(minX, transform.position.y, transform.position.z);
		}
		else if (transform.position.x < minX)
		{
			
			transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
		}
	}
}
