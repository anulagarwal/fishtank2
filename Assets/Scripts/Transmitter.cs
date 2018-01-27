using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transmitter : MonoBehaviour {
	[SerializeField]
	public float radius;

	[SerializeField]
	List<Planets> planetsInRange;

	[SerializeField]
	AudioClip transmitterSound;

	[SerializeField]
	float startAngle;

	private float startTime;
	public float duration;
	private bool isEmit;
	// Use this for initialization
	void Start () {

		startAngle = -Mathf.FloorToInt((12-1)/2)*30;

		duration = 7f;
	}
	
	// Update is called once per frame
	void Update () {
	//	emitTransmission ();
		if (startTime + duration < Time.time && isEmit) {

			GetComponentInChildren<ParticleSystem> (true).gameObject.SetActive( false);



			isEmit = false;
		}
	}

	public void emitTransmission(){
		GetComponentInChildren<ParticleSystem> (true).gameObject.SetActive( true);
		startTime = Time.time;
		isEmit = true;
		GetComponent<Player> ().hasReceivedTransmission = false;
			RaycastHit hit;

			Collider[] col = Physics.OverlapSphere (transform.position, radius);
			int i = 0;
			planetsInRange.Clear ();
			while (i < col.Length) {
				if (col [i].gameObject.layer == 9) {

					planetsInRange.Add (col [i].gameObject.GetComponent <Planets> ());
				}

				i++;
			}

		if (planetsInRange.Count > 0) {
			GetComponent<AudioSource> ().PlayOneShot (transmitterSound);


		}
			foreach (Planets pla in planetsInRange) {
			GameObject tempO = GetComponent<Player> ().gm.rayObj;
			GameObject go = Instantiate (tempO, transform.position, tempO.transform.rotation);
				go.GetComponent<RayObj> ().moveAndDestroy (pla.transform, 9);
			}


	}


	public void receiveTransmission(){


	}

}
