using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncing : MonoBehaviour {

	// Use this for initialization

	public Rigidbody rb;
	public float maxRand, minRand;

	public Vector3 gravityAmount = new Vector3(0,-1,0);


	void Start () {

			rb = GetComponent<Rigidbody>();
			
			Physics.gravity = gravityAmount;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void onFocus()
	{

		rb.AddForce(Random.Range(0,5),Random.Range(minRand,maxRand),Random.Range(0,5), ForceMode.Impulse);
	}

	
}
