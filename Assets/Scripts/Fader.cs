using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour {

    public Texture2D fadeOutTexture;
    public float fadeSpeed = .8f;

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDIr = -1;

    private void OnGUI()
    {
        alpha += fadeDIr * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    public float BeginFade(int direction)
    {
        fadeDIr = direction;
        return (fadeSpeed);
    }

    private void OnLevelWasLoaded(int level)
    {
        //alpha = 1;
        BeginFade(-1);
    }
}
