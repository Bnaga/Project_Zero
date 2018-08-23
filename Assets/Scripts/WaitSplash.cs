using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaitSplash : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	    Time.timeScale = 1;
        StartCoroutine("WaitandBleed");
	    Destroy(GameObject.Find("GameController"));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator WaitandBleed()
    {
        yield return new WaitForSeconds(5);
        float fadeTime = GameObject.Find("Fader").GetComponent<Fader>().BeginFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
