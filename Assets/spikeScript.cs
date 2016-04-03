using UnityEngine;
using System.Collections;

public class spikeScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		if(coll.gameObject.GetComponentInParent<CharacterBehaviorScript>())
		{
			coll.gameObject.GetComponentInParent<CharacterBehaviorScript>().Die();
		}
	}
}
