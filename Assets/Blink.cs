using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
	SpriteRenderer myRenderer;
	Color newColor;
	float timeForColorBlink;
    // Use this for initialization
    void Start()
    {
        SpriteRenderer myRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
		float blinkingAlpha = (0.5f + 0.5f * Mathf.Cos(timeForColorBlink)) ;
		newColor.a = blinkingAlpha;  // this turns the alpha to transparent
        myRenderer.color = newColor;
		timeForColorBlink+=0.25f;
    }
}
