using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnBecameInvisible(){

		Destroy (gameObject);
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == 9) {

			Destroy (gameObject);

		}
		if (col.gameObject.layer == 11 ) {

			col.gameObject.GetComponent<Health> ().takeDamage (3);
			Destroy (gameObject);

		}

	}
}
