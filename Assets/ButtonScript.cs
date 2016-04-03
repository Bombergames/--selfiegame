using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour {
	Animator anim;
	int pushHash = Animator.StringToHash("push");
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
	}

	public void Push()
	{
		anim.SetTrigger(pushHash);
	}
}
