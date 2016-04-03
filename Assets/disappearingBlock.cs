using UnityEngine;
using System.Collections;

public class disappearingBlock : MonoBehaviour {

	// Use this for initialization
	public bool startOn;
	void Start () {
		if(startOn)
		{
			Appear();
		}
		else
		{
			Disappear();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PositiveInput()
	{
		if(startOn)
		{
			Disappear();
		}
		else
		{
			Appear();
		}
	}

	public void NegativeInput()
	{
		if(startOn)
		{
			Appear();
		}
		else
		{
			Disappear();
		}
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
