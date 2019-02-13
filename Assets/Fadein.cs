using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadein : MonoBehaviour {

		private bool canFade;
   	private float alpha;
    private float timeToFade = 1.0f;
	SpriteRenderer sp;
	// Use this for initialization
	void Start () {


        sp=GetComponent<SpriteRenderer>();
		alpha = sp.color.a;
		Debug.Log(alpha);
	}
	
	// Update is called once per frame
	void Update () {

			alpha += -2.0f * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);
			GetComponent<SpriteRenderer>().color = new Color(sp.color.r,sp.color.b,sp.color.g,alpha);
			Debug.Log("alpha-1");
		if (alpha < 0.02f){
			GetComponent<Fadein>().enabled=false;
		}
	}

}
