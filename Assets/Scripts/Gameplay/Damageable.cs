using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Damageable : MonoBehaviour
{

	public float health = 10f;
	public int min = 4;
	public int max = 20;

	public GameObject crystal;
	//public GameController cntrl;

	void Start()
	{
		//cntrl = GameObject.Find("GameController").GetComponent<GameController>();
	}
	public void TakeDamage(float amount)
	{
		health -= amount;
		if (health <= 0f)
		{
			Die();
		}
	}

	public void Die()
	{
		SpawnCrystals();
		Destroy(gameObject);
	}

	public void SpawnCrystals()
	{
		int crystals = Random.Range(min, max);
		
		GameObject clone;
		for (int i = 0; i < crystals; i++)
		{
			Vector3 randPos = new Vector3(Random.Range(gameObject.transform.position.x-1,gameObject.transform.position.x+1),gameObject.transform.position.y +1,Random.Range(gameObject.transform.position.z-1,gameObject.transform.position.z+1));
			clone = Instantiate(crystal, randPos, gameObject.transform.rotation);
		} 
	}
}
