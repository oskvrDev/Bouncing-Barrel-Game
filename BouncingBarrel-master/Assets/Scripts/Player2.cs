using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour {

	private bool Alive = true;
	[SerializeField]
	float PLAYER_SPEED = 20;
	[SerializeField]
	float jumpPower=5f;
	private Rigidbody2D rb2d;

	bool grounded = false;
	// Use this for initialization
	void Start () {
		rb2d=this.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	



	}

	void FixedUpdate()
	{
		if (Alive) 
		{
			float movement = Input.GetAxis ("Horizontal") * Time.deltaTime * PLAYER_SPEED;
			transform.Translate (movement, 0, 0);


			if (Input.GetKey (KeyCode.Space) && grounded) {
				rb2d.AddForce (transform.up * jumpPower);

			}


		}
	}

	public void Died()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	void OnCollisionStay2D(Collision2D col)
	{
		if (col.transform.tag == "Floor") {
			grounded = true;
		}
	}
	void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}
}