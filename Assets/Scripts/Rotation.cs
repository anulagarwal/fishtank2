using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour {
	[SerializeField]
	public float multiplier;

	[SerializeField]
	Vector3 direction;

	[SerializeField]
	public bool setDirection;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!setDirection)
			transform.Rotate (Vector3.up * Time.deltaTime * multiplier, Space.World);
		else
			transform.Rotate (direction   * Time.deltaTime * multiplier, Space.World);


	}
}
