using UnityEngine;
using System.Collections;

public class GrabbableItemScript : MonoBehaviour {

	Quaternion originalRot;
	bool beingGrabbed;
	Transform grabber;
	// Use this for initialization
	void Start () {
		originalRot = this.transform.rotation;
		beingGrabbed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(beingGrabbed)
		{
			this.transform.position = grabber.position + grabber.rotation * Vector3.forward * 1.5f;
		}
	}

	public void Grab(Transform t)
	{
		grabber = t;
		this.transform.SetParent(t);
		//this.transform.localPosition = new Vector3(0, -0.2f, 0);
		this.transform.position = t.position + t.rotation * Vector3.forward * 1.5f;
		GetComponentInChildren<Rigidbody>().useGravity = false;
		GetComponentInChildren<BoxCollider>().enabled = false;
		beingGrabbed = true;
		//this.transform.Translate(new Vector3(0, 0, 0));
	}

	public void UnGrab()
	{
		//this.transform.position = this.transform.TransformPoint(this.transform.position);
		this.transform.SetParent(null);
		this.transform.rotation = originalRot;
		GetComponentInChildren<Rigidbody>().useGravity = true;
		GetComponentInChildren<BoxCollider>().enabled = true;
		beingGrabbed = false;
	}
}
