using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControllerMouse : MonoBehaviour {

	private Rigidbody2D rb2d;
	public Camera PlayerCamera;
	public int Speed;
	// Use this for initialization


	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector2 target = PlayerCamera.ScreenToWorldPoint(Input.mousePosition);

		transform.position = Vector2.MoveTowards(transform.position, target, Speed * Time.deltaTime);

	}
}
