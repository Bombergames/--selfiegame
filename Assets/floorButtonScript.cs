using UnityEngine;
using System.Collections.Generic;

public class floorButtonScript : MonoBehaviour {
	Animator anim;
	int idleHash = Animator.StringToHash("idle");
	int pressHash = Animator.StringToHash("press");
	public List<disappearingBlock> dBList;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log("colliding");
		anim.SetBool("pressed", true);

		foreach(disappearingBlock dB in dBList)
		{
			dB.Appear();
		}
	}

	void OnTriggerExit(Collider coll)
	{
		anim.SetBool("pressed", false);
		foreach(disappearingBlock dB in dBList)
		{
			dB.Disappear();
		}
	}
}
