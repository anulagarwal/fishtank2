using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {


	public bool isDialogUp;

	public int dialoguesInSequence;


	public bool isInSequence;


	public int currentSequenceCount;

	private DialogueSequence curDs;
	[SerializeField]
	Text messageText;

	[SerializeField]

	GameObject textHolder;

	QuestManager qm;

	Planets curPlanet;
	// Use this for initialization
	void Start () {
		qm = GetComponent<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isInSequence && Input.GetMouseButtonDown(0)) {
			if (currentSequenceCount >= curDs.dialogues.Count) {
				currentSequenceCount = 0;
				isInSequence = false;
				textHolder.SetActive (false);
				disableDialogueBar ();
				if (curDs.questID != 0) {

					qm.displayQuest (curDs.questID,curPlanet);
				}

				curDs = null;
				curPlanet = null;
			} else {

				print(curDs.dialogues.Count);
			
				displayDialog (curDs.dialogues [currentSequenceCount].message);
				currentSequenceCount += 1;


			}

		}
	}
	public void enableDialogueBar(){
		textHolder.SetActive (true);

		Time.timeScale =0f;


	}
	public void disableDialogueBar(){
		textHolder.SetActive (false);


		Time.timeScale = 1f;
	}
	public void displaySequence(DialogueSequence ds,Planets plane){
		if (!isInSequence) {

			enableDialogueBar ();
			isInSequence = true;
			currentSequenceCount = 0;


			curDs = ds;
			displayDialog (ds.dialogues [currentSequenceCount].message);
			currentSequenceCount += 1;
			curPlanet = plane;
		}
	}

	public void displayDialog(string message){

		messageText.text = message;

	}


}

