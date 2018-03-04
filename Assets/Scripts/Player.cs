using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.CrossPlatformInput;

using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	public float speed = 4f;

	public Rigidbody2D rb;

	private Animator myAnimator;

	private float movement = 0f;

	private bool facingRight;

	Ball ball;
	// Update is called once per frame
	void Start(){
		ball = gameObject.GetComponent<Ball>();
		facingRight = true;
		myAnimator = GetComponent<Animator> ();
	}

	void Update () {

		movement = Input.GetAxisRaw("Horizontal") * speed;
	}

	void FixedUpdate ()
	{
		float horizontal = Input.GetAxisRaw ("Horizontal");

		HandleMovement (horizontal);
		Flip (horizontal);
	}
	private void HandleMovement(float horizontal){
		rb.MovePosition(rb.position + new Vector2 (movement * Time.fixedDeltaTime, 0f));

		myAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}
	private void Flip(float horizontal){
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}



	void OnCollisionEnter2D (Collision2D col)
	{
		if (col.collider.tag == "Ball")
		{
			
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}
		
}
