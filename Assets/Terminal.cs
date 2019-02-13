using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class Terminal : MonoBehaviour {

	BoxCollider2D bc2;
	//public Text text;
	public VideoPlayer vp;
	// Use this for initialization
	bool _t;
	void Start () {
		bc2 = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey("escape"))
		SceneManager.LoadScene("Menu");
	}
	void OnTriggerEnter2D(Collider2D other) {

		 if (other.gameObject.CompareTag("Player"))
		 {
			//text.gameObject.SetActive(true);
			vp.Play();
			vp.loopPointReached += ChangeScene;
			Debug.Log("ENd");
		 }
	}
	void ChangeScene(VideoPlayer player){
		SceneManager.LoadScene("Menu");
	}
}
