﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

    [SerializeField] float rcsThrust = 100f;
    [SerializeField] float mainThrust = 100f;

	Rigidbody rigidBody;
	AudioSource audioSource;

	// Use this for initialization
	void Start ()
	{
		rigidBody = GetComponent<Rigidbody>();
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	void Update ()
	{
        Thrust();
        Rotate();
	}

	private void OnCollisionEnter(Collision collision) 
	{
		switch (collision.gameObject.tag)
		{
			case "Friendly":
			{
				print("Okay");
				break;
			}
			default:
			{
				print("Dead");
				break;
			}
		}
	}

    private void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime;

		if (Input.GetKey(KeyCode.Space))
		{
			rigidBody.AddRelativeForce(Vector3.up * thrustThisFrame);
			if (!audioSource.isPlaying)
			{
				audioSource.Play();
			}
		}
		else
		{
			audioSource.Stop();
		}
    }

    private void Rotate()
    {
        rigidBody.freezeRotation = true;

        float rotationThisFrame = rcsThrust * Time.deltaTime;

		if (Input.GetKey(KeyCode.A))
		{
			transform.Rotate(Vector3.forward * rotationThisFrame);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			transform.Rotate(-Vector3.forward * rotationThisFrame);
		}
        
        rigidBody.freezeRotation = false;
    }
}
