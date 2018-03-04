using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ChainCollision : MonoBehaviour {
	public AudioClip impactBall;
	public AudioClip impactWall;
	AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}
		

	void OnTriggerEnter2D (Collider2D col)
	{
		Chain.IsFired = false;

		if (col.tag == "Ball") {
			col.GetComponent<Ball> ().Split ();
			audioSource.PlayOneShot (impactBall, 0.7F);
		}

		if (col.tag == "Wall") {
			
			audioSource.PlayOneShot (impactWall, 0.4F);
		}

	}



}
