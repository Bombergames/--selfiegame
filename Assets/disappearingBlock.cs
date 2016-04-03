using UnityEngine;
using System.Collections;

public class disappearingBlock : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Appear()
	{
		GetComponent<Renderer>().material.SetColor("_Color", Color.white);
		GetComponent<BoxCollider>().enabled = true;
	}

	public void Disappear()
	{
		GetComponent<Renderer>().material.SetColor("_Color", new Color(1,1,1,0.3f));
		GetComponent<BoxCollider>().enabled = false;
	}
}
