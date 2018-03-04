using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class Chain : MonoBehaviour {

	public Transform player;

	public float speed = 2f;

	public static bool IsFired;
	public AudioClip shootSound;

	AudioSource audioSource;
	// Use this for initialization
	void Start () {
		
		audioSource = GetComponent<AudioSource>();
		IsFired = false;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Fire1"))
		{
			
			audioSource.PlayOneShot(shootSound, 0.7F);
			IsFired = true;
		}
		
		if (IsFired)
		{
			transform.localScale = transform.localScale + Vector3.up * Time.deltaTime * speed;
		} else
		{
			transform.position = player.position;
			transform.localScale = new Vector3(1f, 0f, 1f);
		}

	}
}
