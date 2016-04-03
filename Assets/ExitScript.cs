using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExitScript : MonoBehaviour {

	// Use this for initialization
	public string nextScene;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log("nextscene");
		if(coll.gameObject.GetComponentInChildren<CharacterBehaviorScript>())
		{
			Debug.Log("nextsssssscene");
			if (coll.gameObject.GetComponentInParent<CharacterBehaviorScript>().tintColor == Color.white)
			{
				Debug.Log("wtf");
				SceneManager.LoadScene(nextScene);
			}
		}
	}
}
