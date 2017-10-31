using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameController : MonoBehaviour {
	public static Vector3 cubePosition;
	public static float xPosition;
	public static float yPosition;
	public static int numCubesX;
	public static int numCubesY;
	public static int numCubesXLine1;

	public static int maxX;
	public static int maxY;
	public static int [,] planeGrid = new int[maxX,maxY];

	public static GameObject myCube;
	public static GameObject firstCube;
	public GameObject cubePrefab;
	public static bool airplaneActivated;

	public static GameObject airplaneCube;

	// Use this for initialization
	void Start () {
		airplaneActivated = false;
		numCubesX = 16;
		numCubesY = 9;
		xPosition = -22f;
		yPosition = 8f;

		yPosition -= 2;
		xPosition = -22f;

		//makes the rows of cubes
		for (int y = 0; y < numCubesY; y++) {
			for (int x = 0; x < numCubesX; x++) {
				cubePosition = new Vector3 (xPosition, yPosition, 0);
				myCube = Instantiate (cubePrefab, cubePosition, Quaternion.identity);
				myCube.GetComponent<Renderer> ().material.color = Color.white;
				//gets the position of each cube
				myCube.GetComponent<cubeScript> ().X = x;
				myCube.GetComponent<cubeScript> ().Y = y;
				xPosition += 3;
				//makes first cube airplane cube initially
				if (x == 0 && y == 0) {
					myCube.GetComponent<Renderer> ().material.color = Color.red;
					airplaneCube = myCube;
				}
			}
			xPosition = -22f;
			yPosition -= 2;
		}
	}

	public static void processClick(GameObject clickedCube) {

		//checks if clickCube is the same as airPlane cube
		if (airplaneCube.GetComponent<cubeScript> ().X == clickedCube.GetComponent<cubeScript> ().X && airplaneCube.GetComponent<cubeScript> ().Y == clickedCube.GetComponent<cubeScript> ().Y) {
			//deactivates the airplane if activated airplane is clicked
			if (airplaneActivated == true) {
				airplaneActivated = false;
				airplaneCube.GetComponent<Renderer> ().material.color = Color.red;
			}
			//activates the airplane if deactivated airplane is clicked
			else if (airplaneActivated == false) {
				airplaneActivated = true;
				airplaneCube.GetComponent<Renderer> ().material.color = Color.yellow;
			}
		//moves the active airplane to a cloud cube if an airplane is active and a cloud cube is clicked, and turns the old cube back to white
		} else {
			if (airplaneActivated == true) {
				clickedCube.GetComponent<Renderer> ().material.color = Color.yellow;
				airplaneCube.GetComponent<Renderer> ().material.color = Color.white;
				airplaneCube = clickedCube;
			}
		}
			
	}
	

	// Update is called once per frame
	void Update (){
		
		}

}
