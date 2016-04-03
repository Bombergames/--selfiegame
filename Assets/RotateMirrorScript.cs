using UnityEngine;
using System.Collections;

public class RotateMirrorScript : MonoBehaviour {

	// Use this for initialization
	public Quaternion altRotation;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void flip ()
	{
		Quaternion tempRotation = this.transform.rotation;
		this.transform.rotation = altRotation;
		altRotation = tempRotation;

	}
}
