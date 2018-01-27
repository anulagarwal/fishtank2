using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float fuel;

	public float health;


	public List<Quest> quests;

	public bool hasReceivedTransmission;
	public enum States
	{
Idle,
Moving,
Reverse,
Upward,
Shooting,
	Dash}

	;

	float currentSpeed = 0.0f;
	float maxSpeed = 1.0f;
	float maxReverseSpeed = -2f;
	public List<Galaxies.Classes> alliances;


	public Planets currentPlanet;


	public Sector currentSector;
	Player.States state;
	public GameManager gm;
	public QuestManager qm;
	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
			//Input phase split out - I like to do this but it's optional
			switch(state) {
		case Player.States.Idle:
				if(Input.GetKeyDown(KeyCode.W)) { 
				state = Player.States.Moving;
				}
				if(Input.GetKeyDown(KeyCode.S)) {
				state = Player.States.Reverse;
				}
				break;
		case Player.States.Moving:

				if(Input.GetKeyDown(KeyCode.S)) {
				state = Player.States.Idle;
				}
				break;
		case Player.States.Reverse:
				if(!Input.GetKey(KeyCode.S)) {
				state = Player.States.Idle;
				}
				break;
			}
			//Movement phase 
			switch(state) {
		case Player.States.Idle:
				currentSpeed = Mathf.Lerp(currentSpeed, 0, Time.deltaTime); //Or MoveTowards
				break;
		case Player.States.Moving:
				currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime); //Or MoveTowards
				break;
		case Player.States.Reverse:
				currentSpeed = Mathf.Lerp(currentSpeed, maxReverseSpeed, Time.deltaTime); //Or MoveTowards
				break;
			}
			//Actually move
		transform.position += Vector3.right * currentSpeed * Time.deltaTime;

		transform.LookAt (new Vector3( Camera.main.ScreenToWorldPoint( Input.mousePosition).x  ,0f, transform.rotation.z));
		print (Camera.main.ScreenToWorldPoint (Input.mousePosition));
	}


	void movePlayer(){


	}

	void shoot(){


	}

	void interactWithPlanet(){

	}
	void checkForRetrieveQuests(Planets plane){

		foreach (Quest q in quests) {

			if (q.questGivenBy == plane && q.isRetrievable && q.hasRetrieved) {

				qm.completeQuest (q);
				quests.Remove (q);
			}
		}

	}


	public void receiveTransmissionBack(){


		hasReceivedTransmission = true;
	
	}
	void checkForQuestForObject(GameObject go){
		
		foreach (Quest q in quests) {

			if (q.questObject == go) {
				//for no ret
				if (!q.isRetrievable) {

					qm.completeQuest (q);
					quests.Remove (q);
					Destroy (go);
				} else {

					q.hasRetrieved = true;
					Destroy (go);


				}


				break;
			}

		}

	}
	//WASD Control scheme
	void checkForControls(){

		if(Input.GetKey(KeyCode.W)){



		}
	
		if(Input.GetKey(KeyCode.A)){



		}
		if(Input.GetKey(KeyCode.S)){



		}
		if(Input.GetKey(KeyCode.D)){



		}


	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.layer == 9) {
			currentPlanet = col.gameObject.GetComponent<Planets> ();
			checkForRetrieveQuests ( col.gameObject.GetComponent<Planets> ());
		}

		if (col.gameObject.layer == 10) {

			checkForQuestForObject (col.gameObject);
		}
		if (col.gameObject.layer == 12) {
			GetComponentInChildren<Gun> ().ammo += 5;
			Destroy (col.gameObject);
		}

	}
	void OnTriggerExit(Collider col){

		if (col.gameObject.layer == 9) {
			currentPlanet =null;

		}


	}
}
