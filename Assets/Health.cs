using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
	[SerializeField]
	public int health;

	[SerializeField]
	public bool canDrop;

	[SerializeField]
	public GameObject dropItem;

	// Use this for initialization
	void Start () {
		
	}
	public void takeDamage(int damage){

		health -= damage;
	}
	// Update is called once per frame
	void Update () {

		if (health < 1) {


			Destroy (gameObject);
			if(canDrop)
			Instantiate (dropItem, transform.position, transform.rotation);
		}
	}
}
