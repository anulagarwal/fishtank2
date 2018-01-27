using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour
{
	public float speed;
	public float tilt;
	public Boundary boundary;
	public Rigidbody rb;

	void Start(){


		rb = GetComponent<Rigidbody> ();
	}
	void FixedUpdate ()
	{

		if (Input.GetKeyDown (KeyCode.Space)) {

			GetComponent<Transmitter> ().emitTransmission ();

		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = Vector3.forward;
		if(Input.GetKeyDown(KeyCode.W))
		rb.velocity = movement * speed;

		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax), 
				0.0f,
				Mathf.Clamp (rb.position.z, boundary.zMin, boundary.zMax)
			
			);

		rb.rotation = Quaternion.Euler (0,270f, rb.velocity.z * -tilt);
	}
}