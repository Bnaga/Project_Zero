using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public bool isPaused;
	public GameObject pauseMenuCanvas;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isPaused)
		{
			pauseMenuCanvas.SetActive(true);
			Time.timeScale = 0;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			pauseMenuCanvas.SetActive(false);
			Time.timeScale = 1f;
			Cursor.lockState = CursorLockMode.Locked;
		}
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			isPaused = !isPaused;
		}
	}

	public void Resume()
	{
		isPaused = false;
	}

	public void MainMenu()
	{
		Time.timeScale = 1;
		SceneManager.LoadScene(0);
		
	}
}
