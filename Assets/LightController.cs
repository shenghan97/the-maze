using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Camera PlayerCamera;
	public int Speed;
	// Use this for initialization
	public GameObject go;
	private GazePlotter gp;
	private Vector2 smoothified;



	

	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		gp = go.GetComponent<GazePlotter>();
		Vector2 smoothified = gp.Smoothified;
		Debug.Log(smoothified);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		smoothified = gp.Smoothified;

		var target = smoothified;
		//Debug.Log(smoothified);

	  	transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);
		/* float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2 (moveHorizontal,moveVertical);
		rb2d.AddForce(movement); */
	}
}
