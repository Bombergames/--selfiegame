using UnityEngine;
using System.Collections;

public class DisappearingWallScript : MonoBehaviour {

	// Use this for initialization
	public Color wallColor;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void newActiveCharacter(Color newColor)
	{
		newColor.a = 1f;
		if(wallColor == newColor)
		{
			this.GetComponent<Renderer>().enabled = false;
			this.GetComponent<BoxCollider>().enabled = false;
			Debug.Log("new color is wall color");
		}
		else
		{
			this.GetComponent<Renderer>().enabled = true;
			this.GetComponent<BoxCollider>().enabled = true;
			Debug.Log("new color is not wall color");
		}
	}
}
