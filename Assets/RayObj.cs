using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayObj : MonoBehaviour {
	int layer;
	Vector3 targetPos;
	bool canMove;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {

			transform.position = Vector3.MoveTowards (transform.position, targetPos, 0.05f);

			if (Vector3.Distance (transform.position, targetPos) < 0.2f) {
				Destroy (gameObject);
			}
		}
	}


	public void moveAndDestroy(Transform target, int layerID){
		layer = layerID;

		targetPos = target.position;
		canMove = true;

	}

	public void move(Transform target, int layerID){
		layer = layerID;

		targetPos = target.position;
		canMove = true;

	}

	void OnTriggerEnter(Collider col){

		if (col.gameObject.layer == layer) {
			if (layer == 9) {

				col.gameObject.GetComponent <Planets> ().receiveTransmission ();

			}
			if (layer == 8) {

				col.gameObject.GetComponent<Player> ().receiveTransmissionBack ();
			}


			Destroy (gameObject);
		}

	}
}
