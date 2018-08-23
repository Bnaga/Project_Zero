using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

	public float moveSpeed;
	//public Rigidbody rigid;
	public float jumpForce;
	public CharacterController controller;

	private Vector3 moveDirection;

	private int jumpCount = 2;

	public float gravityScale;

	// Use this for initialization
	void Start ()
	{
		//rigid = GetComponent<Rigidbody>();
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		//rigid.velocity = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,rigid.velocity.y,Input.GetAxis("Vertical")*moveSpeed);

		/*
		if (Input.GetButtonDown("Jump"))
		{
			rigid.velocity = new Vector3(rigid.velocity.x,jumpForce,rigid.velocity.z);
		}
		*/
		
		//moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed, moveDirection.y,Input.GetAxis("Vertical")*moveSpeed)
		float yStore = moveDirection.y;
		moveDirection = (transform.forward * Input.GetAxis("Vertical")) + (transform.right * Input.GetAxis("Horizontal"));
		moveDirection = moveDirection.normalized * moveSpeed;
		moveDirection.y = yStore;
		
		if (jumpCount > 0)
		{
			//moveDirection = new Vector3(Input.GetAxis("Horizontal")*moveSpeed,0f,Input.GetAxis("Vertical")*moveSpeed);
			//moveDirection.y = 0f;
			
			if (Input.GetButtonDown("Jump"))
			{
				moveDirection.y = jumpForce;
				jumpCount--;
			}

			
		}

		if (!controller.isGrounded)
		{
			moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		}

		if (controller.isGrounded)
		{
			jumpCount = 2;
		}

		controller.Move(moveDirection * Time.deltaTime);
	}


}
