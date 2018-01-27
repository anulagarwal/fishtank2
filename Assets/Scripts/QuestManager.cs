using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

	[SerializeField]
	public List<Quest> quests;


	[SerializeField]
	public GameObject textHolder;

	DialogManager dm;

	GameManager gm;


	[SerializeField]
	public Text textMessage;


	public bool isQuestPopupOpen;
	public int curOpenQuestID;
	public bool isCompletionMessageOpen;
	public GameObject buttons;
	// Use this for initialization
	void Start () {

		dm = GetComponent<DialogManager> ();
		gm = GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isCompletionMessageOpen && Input.GetMouseButtonDown (0)) {

			buttons.SetActive (true);
			disableQuestPopup ();
			isCompletionMessageOpen = false;
		}
	}
	void enableQuestPopup(){

		textHolder.SetActive (true);
		isQuestPopupOpen = true;
		Time.timeScale = 0f;

	}


	void disableQuestPopup(){

		textHolder.SetActive (false);
		isQuestPopupOpen = false;
		Time.timeScale = 1f;
	}


	public void completeQuest(Quest questa){

		questa.isCompleted = true;
		questa.isActive = false;
		enableQuestPopup ();
		buttons.SetActive (false);
		textMessage.text = questa.questCompletionMessage;
		isCompletionMessageOpen = true;
		gm.player.quests.Remove (questa);
	}


	public	void displayQuest(int id, Planets plane){
		if (!isQuestPopupOpen) {
			curOpenQuestID = id;
			enableQuestPopup ();
			foreach (Quest q in quests) {

				if (q.questID == id) {
					textMessage.text =q.questMessage;

					q.questGivenBy = plane;
					break;
				}

			}
		}


	}

	public void acceptQuest(){
		foreach (Quest q in quests) {

			if (q.questID == curOpenQuestID) {
				gm.player.quests.Add (q);


				break;
			}

		}



		

		disableQuestPopup ();
	}
	public void declineQuest(){

		disableQuestPopup ();

	}
}
