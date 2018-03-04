using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour {

	public Vector2 startForce;

	public GameObject nextBall;

	public Rigidbody2D rb;

	public string nextLevel;

	public AudioClip bounceSound;

	AudioSource audioSource;

	private Canvas CanvasObject;


	// Use this for initialization
	void Start () {
		CanvasObject = GameObject.Find("SuccPlay").GetComponent<Canvas>();
		CanvasObject.GetComponent<Canvas> ().enabled = false;
		audioSource = GetComponent<AudioSource>();
		rb.AddForce(startForce, ForceMode2D.Impulse);
	}
	void Update(){
		
	
	}

	public void Split ()
	{
		
		if (nextBall != null) {
			GameObject ball1 = Instantiate (nextBall, rb.position + Vector2.right / 4f, Quaternion.identity);
			GameObject ball2 = Instantiate (nextBall, rb.position + Vector2.left / 4f, Quaternion.identity);

			ball1.GetComponent<Ball> ().startForce = new Vector2 (2f, 5f);
			ball2.GetComponent<Ball> ().startForce = new Vector2 (-2f, 5f);
				
		}

		int ballNumber = GameObject.FindGameObjectsWithTag("Ball").Length;

		Destroy(gameObject);
		if (ballNumber == 1) {
			CanvasObject.GetComponent<Canvas> ().enabled = true;
		}

	}
	void OnCollisionEnter2D (Collision2D col)
	{

		if (col.collider.tag == "Wall")
		{
			
			audioSource.PlayOneShot(bounceSound, 0.7F);
		}

	}

}
