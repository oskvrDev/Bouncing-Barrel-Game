using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private bool Alive = true;
	[SerializeField]
	float PLAYER_SPEED = 20;
	[SerializeField]
	float jumpPower=5f;
	private Rigidbody2D rb2d;
	private float movement;

	private bool isGrounded;
	public Transform groundcheck;
	public float checkRadius;
	public LayerMask whatisground;

	private bool facingright = true;

	Animator animator_;

	// Use this for initialization
	void Start () {
		rb2d=this.gameObject.GetComponent<Rigidbody2D> ();
		animator_ = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	



	}

	void Flip()
    {
		facingright = !facingright;
		Vector3 Scale = transform.localScale;
		Scale.x *= -1;
		transform.localScale = Scale;
    }

	void FixedUpdate()
	{
		if (Alive) {
			isGrounded = Physics2D.OverlapCircle (groundcheck.position, checkRadius, whatisground);


			movement = Input.GetAxis ("Horizontal");
			rb2d.velocity = new Vector2 (movement * PLAYER_SPEED, rb2d.velocity.y);

			if (Input.GetKey (KeyCode.Space) && isGrounded) {
				rb2d.velocity = Vector2.up * jumpPower;

				if (facingright == false && movement > 0) {
					Flip ();
				} else if (facingright == true && movement < 0) {
					Flip ();
				}
            
			
			

			}


		}
		else {
			if (!animator_.GetCurrentAnimatorStateInfo (0).IsName ("BarrelExplode")) {
				
				// Avoid any reload.
				Application.LoadLevel (Application.loadedLevel);
			}

		}
	}

	public void Died()
	{
		Alive = false;
		rb2d.simulated = false;
		try{
			this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
		}
		catch{}
		animator_.Play ("BarrelExplode");


	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.tag == "Floor") {
			isGrounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		isGrounded = false;
	}
}