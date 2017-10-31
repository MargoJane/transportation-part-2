using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeScript : MonoBehaviour {

	public int X;
	public int Y;

	void OnMouseDown(){
		gameController.processClick(gameObject);

	}

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		
	}

}

