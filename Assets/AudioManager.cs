using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	[SerializeField]
	List<AudioFile> ac;

	[SerializeField]
	AudioSource backgroundM;

	[SerializeField]
	AudioSource planteM;


	[SerializeField]
	AudioSource sfX;


	AudioSource aSource;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setBGM(float value){

		backgroundM.volume = value;

	}

	public void playSound(string name){

		foreach (AudioFile af in ac) {

			if (af.name == name) {

				AudioSource aso = new AudioSource ();

				aso.clip = af.ac;
				aso.Play ();

				Destroy (aso);

				break;
			}

		}

	}
}
