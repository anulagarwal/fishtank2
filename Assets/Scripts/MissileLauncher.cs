using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissileLauncher : MonoBehaviour {

	public float heatBar;

	[SerializeField]
	public float heatReleasePerBullet;

	[SerializeField]
	public float cooldownPeriod;

	[SerializeField]
	public float cooldownPercentage;

	[SerializeField]
	public float damage;

	private float startTime;

	public bool canShoot;
	[SerializeField]
	public float speed;
	[SerializeField]
	Rigidbody missile;
	[SerializeField]
	public Slider normalSlider;

	[SerializeField]
	public Slider overHeatSlider;

	AudioSource missileSource;
	[SerializeField]
	AudioClip missileClip;

	void Awake(){

		missileSource = gameObject.AddComponent<AudioSource> ();
		missileSource.maxDistance = 20;


	}
	// Use this for initialization
	void Start () {
		missileSource.clip = missileClip;
		normalSlider.maxValue = 100;
		overHeatSlider.maxValue = 20;
	}


	public void shootMissile(){

		if (canShoot) {
			heatBar  += heatReleasePerBullet + (heatReleasePerBullet/100 * heatBar) ;
			Rigidbody mis = Instantiate (missile, transform.position, transform.rotation) as Rigidbody;

			mis.velocity = transform.TransformDirection (new Vector3 (0, 0, -speed));
			missileSource.PlayOneShot (missileClip);
		}
	}

	public void reloadLauncher(){


	}


	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			shootMissile ();
		}

		if (heatBar > 0) {

			canShoot = true;

			normalSlider.value = heatBar;

			overHeatSlider.value = 0;

		}
		if (heatBar > 0 && startTime + cooldownPeriod < Time.time) {

			heatBar = heatBar - (cooldownPercentage);

			startTime = Time.time;

		}
		if (heatBar > 95f) {
			
			canShoot = false;

		}
	}


}
