using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {
	public int questID;
	public string questMessage;
	public GameObject questObject;
	public bool isRetrievable;
	public bool hasPlayerRetrievedObject;
	public bool hasRetrieved;
	public bool isActive;
	public string questCompletionMessage;
	public Planets questGivenBy;
	public bool isCompleted;
}
