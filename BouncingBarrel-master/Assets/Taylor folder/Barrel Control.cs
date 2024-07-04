using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour {
	private bool Alive = true;
	[SerializeField]
	float PLAYER_SPEED = 20;
	[SerializeField]
	float JUMP_POWER=5f;
	private Rigidbody2D rb2d;

	bool grounded = false;
	// Use this for initialization
	void Start () {
		rb2d = this.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Alive)
		{
			float movement = Input.GetAxis ("Horizontal") * Time.deltaTime * PLAYER_SPEED;
			transform.Translate (movement, 0, 0);

			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				rb2d.AddForce (transform.up * JUMP_POWER);
				Debug.Log ("jump");
			}
	}
}
	void OnCollisionStay2D(Collision2D col)
	{
		grounded = true;
	}
	void OnCollisionExit2D(Collision2D col)
	{
		grounded = false;
	}
}