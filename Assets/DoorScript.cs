using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour {

	Animator anim;
	int openHash = Animator.StringToHash("Open");
	int closeHash = Animator.StringToHash("Close");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void Open()
	{
		anim.SetTrigger(openHash);
		this.GetComponent<BoxCollider>().enabled = false;
	}

	public void Close()
	{
		anim.SetTrigger(closeHash);
		this.GetComponent<BoxCollider>().enabled = true;
	}
}
