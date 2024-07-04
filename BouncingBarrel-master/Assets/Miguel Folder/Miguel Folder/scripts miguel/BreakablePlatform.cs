using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakablePlatform : MonoBehaviour {
	Animator animatormanager;

	[SerializeField]
	string animname;
	// Use this for initialization
	void Start () {
		animatormanager = this.gameObject.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void BreakPlatform()
	{
		animatormanager.Play (animname);
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.transform.CompareTag("Player") || col.transform.GetChild(0).transform.tag=="Player") 
		{
			BreakPlatform ();
		}
	}
}
