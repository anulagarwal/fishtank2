using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {

	[SerializeField]
	public int ammo;

	[SerializeField]
	public Rigidbody bullet;

	[SerializeField]
	public float speed;

	[SerializeField]
	public Text bulletCount;


	AudioSource gun;
	[SerializeField]
	AudioClip gunClip;
	void Awake(){

		gun = gameObject.AddComponent<AudioSource> ();
		gun.maxDistance = 20;
	
	}

	// Use this for initialization
	void Start () {
		gun.clip = gunClip;

	}


	public void shootBullet(){
		if (ammo > 0) {
			Rigidbody bulleta = Instantiate (bullet, transform.position, transform.rotation) as Rigidbody;
			bulleta.velocity  = transform.TransformDirection (new Vector3 (0, 0, -speed));
			ammo -= 1;
			gun.PlayOneShot (gunClip);
		}
	}
	// Update is called once per frame
	void Update () {
		bulletCount.text = "Bullet count: " + ammo;
		if (Input.GetMouseButtonDown (1)) {


			shootBullet ();
		}
	}
}
