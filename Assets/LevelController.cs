using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LevelController : MonoBehaviour {

	private bool canFade;
   	private float alpha;
    private float timeToFade = 1.0f;
	public GameObject vp;
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
		canFade = false;
        alpha = vp.GetComponent<VideoPlayer>().targetCameraAlpha;
		Debug.Log(alpha);
	}
	
	// Update is called once per frame
	void Update () {
		if (canFade){
			alpha += -2.0f * Time.deltaTime;
			alpha = Mathf.Clamp01(alpha);
			vp.GetComponent<VideoPlayer>().targetCameraAlpha=alpha;
			Debug.Log("alpha-1");
		}
		if (alpha < 0.02f){
			SceneManager.LoadScene("SampleScene");
		}
	}
	IEnumerator Wait()
    {
        Debug.Log(Time.time);
        yield return new WaitForSeconds(4);
        Debug.Log(Time.time);
		canFade = true;
		
    }
}
