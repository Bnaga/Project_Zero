using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalScript : MonoBehaviour 
{

	public GameController cntrl;
	public GameObject player;

	public int PointAmount = 1;
	// Use this for initialization
	void Start () 
	{
		cntrl = GameObject.Find("GameController").GetComponent<GameController>();
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		cntrl = GameObject.Find("GameController").GetComponent<GameController>();
		player = GameObject.FindWithTag("Player");
		if (Vector3.Distance(player.transform.position, gameObject.transform.position) <= 2)
		{
			cntrl.AddPoints(PointAmount);
			Kill();
		}
		
	}

	private void OnCollisionEnter(Collision other)
	{
		if (other.collider.CompareTag("Player"))
		{
			//Debug.Log("test");
			cntrl.AddPoints(PointAmount);
			cntrl.UpdatePoints();
			Kill();
		}

	}

	void Kill()
	{
		Destroy(gameObject);
	}
}
