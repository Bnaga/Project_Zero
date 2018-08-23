using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

	public float damage = 10;
	public Damageable target;
	public Rigidbody rbody;
	public float bulletSpeed;
	public Transform secretTarget;
	private Vector3 targetPos;

	void Start()
	{
		secretTarget = GameObject.FindGameObjectWithTag("Target").transform;
		rbody = gameObject.GetComponent<Rigidbody>();
		targetPos = secretTarget.position;
	}

	void Update()
	{
		rbody.velocity = (targetPos-transform.position).normalized * bulletSpeed ;

		if (Vector3.Distance(targetPos,transform.position) <= 1)
		{
			Kill();
		}
		
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Damageable"))
		{
			target = other.gameObject.GetComponent<Damageable>();
			target.TakeDamage(damage);
			Kill();
		}
		
		if (other.collider.CompareTag("Environment"))
		{;
			Kill();
		}
		//Kill();
		
	}

	void Kill()
	{
		Destroy(gameObject);
	}
}
