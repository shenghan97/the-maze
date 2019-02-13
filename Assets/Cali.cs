using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cali : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void cali(){
				 System.Diagnostics.Process.Start("C:/Users/Han/source/repos/ConsoleApp1/ConsoleApp1/bin/Debug/ConsoleApp1.exe");

		Application.Quit();
	}
}
