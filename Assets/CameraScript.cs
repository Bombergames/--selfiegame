using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Show()
	{
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.enabled = true;
		}
	}

	public void Hide()
	{
		foreach(Renderer r in GetComponentsInChildren<Renderer>())
		{
			r.enabled = false;
		}
	}
}
