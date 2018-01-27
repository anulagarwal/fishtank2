using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public bool isPause;


	public Player player;

	[SerializeField]
	public GameObject rayObj;
	[SerializeField]
	public AudioClip planetClip;
	// Use this for initialization
	void Start () {

		isPause = false;
		player = FindObjectOfType<Player> ();
		player.gm = this;
		player.qm = GetComponent<QuestManager> ();
	}
	
	// Update is called once per frame
	void Update () {



	}

	public void pauseGame(){
		if (isPause) {

			isPause = false;
			Time.timeScale = 1f;
		} else {


			isPause = true;
			Time.timeScale = 0f;
		}

	}

	public void changeScene(string name){
		Application.LoadLevel (name);

	}

	public void exitGame(){


	}
}
