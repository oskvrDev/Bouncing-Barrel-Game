using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField]
	GameObject Player;

	float oldYPosition;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		oldYPosition = this.transform.position.y;
		if (oldYPosition < Player.transform.position.y) {

			this.transform.position = new Vector3 (0, Player.transform.position.y, -10);
		}
	}
}
