using UnityEngine;
using System.Collections;

public class defineTriggerStay : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay(Collider coll)
	{
		Debug.Log("trigger stay in child"); // trigger stay must be defined in child for it to be accessible in parent
		//GetComponentInParent<CharacterBehaviorScript>().TriggerStayFromChild(coll);
	}
}
