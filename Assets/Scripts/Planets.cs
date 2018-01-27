using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planets : MonoBehaviour {
	[SerializeField]
	GameManager gm;

		[SerializeField]
	DialogManager dm;



	[SerializeField]
	public Galaxies.Classes alliance;

	[SerializeField]
	public List<DialogueSequence> dialogues;


	[SerializeField]
	GameObject tempO;

	[SerializeField]
	int playerVisits;


	AudioSource asO;
	// Use this for initialization

	void Awake(){

		gm = FindObjectOfType<GameManager> ();
	
	}
	void Start () {
		asO = GetComponentInChildren<AudioSource>();

	//	asO.clip = gm.planetClip;
		asO.spatialBlend = 1.0f;
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up * Time.deltaTime *1.5f, Space.World);
	}

	void sendMessageToShip(){



	}
	public void receiveTransmission(){

	//	GameObject rayO = Instantiate (gm.rayObj, transform.position, Quaternion.identity);
	//	Debug.DrawLine (transform.position, gm.player.transform.position);
	
		GameObject go = Instantiate (tempO, transform.position,tempO.transform.rotation);
	
		go.GetComponent<RayObj> ().moveAndDestroy (gm.player.transform, 8);

		print ("receive");

	}
	void OnTriggerEnter(Collider col){


		if (col.gameObject.layer == 8) {
			if (playerVisits < dialogues.Count) {
				if (!dialogues [playerVisits].hasRead) {
					dm.displaySequence (dialogues [playerVisits], this);
					dialogues [playerVisits].hasRead = true;
				}
			
				playerVisits += 1;
			}
		}

	}
}
