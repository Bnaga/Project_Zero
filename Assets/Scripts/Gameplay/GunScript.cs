using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{

	//public float damage = 10f;
	public float range = 100f;

	public GameObject player;
	public Camera cam;
	public Transform barrel;
	RaycastHit hit;
	public Rigidbody bullet;
	public Vector3 targetPos;
	public float bulletSpeed = 10;
	public Transform secretTarget;
	public PauseMenu pausemenu;
	public AudioClip shotClip;
	private AudioSource shotsrc;
	
	void Awake()
	{
		shotsrc = GetComponent<AudioSource>();
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(secretTarget.transform.position);
		//Debug.Log(cam.transform.forward);
		if (Input.GetButtonDown("Fire1"))
		{
			//Shoot();
			shotsrc.PlayOneShot(shotClip, 1.0f);
			RealShoot();
			
		}

		if (Input.GetKeyDown(KeyCode.K))
		{
			Rigidbody clone;
			clone = Instantiate(bullet);
			clone.transform.position = barrel.transform.position;
			clone.velocity = new Vector3(-20,0,0);
			
		}
		
	}

	void Shoot()
	{
		Debug.DrawRay(cam.transform.position, cam.transform.forward);
		if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
		{
			Debug.Log(hit.transform.name);
			
			Damageable target = hit.transform.GetComponent<Damageable>();
			if (target != null)
			{
				//target.TakeDamage(damage);
				targetPos = hit.point;
				Rigidbody clone;
				clone = Instantiate(bullet, barrel.position, cam.transform.rotation);
				clone.velocity = cam.transform.forward * bulletSpeed;
			}

		}
	}

	void RealShoot()
	{
		Rigidbody clone;
		clone = Instantiate(bullet);
		clone.transform.position = barrel.transform.position;
		//clone.velocity = (secretTarget.position-clone.transform.position).normalized * bulletSpeed ;
		//Debug.Log(clone.velocity);
	}
	
}
