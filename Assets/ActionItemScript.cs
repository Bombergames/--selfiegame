using UnityEngine;
using System.Collections.Generic;

public class ActionItemScript : MonoBehaviour {

	// Use this for initialization
	public List<actionFunc> funcList = new List<actionFunc>();
	public List<DoorScript> doorList;
	public List<RotateMirrorScript> mirrorList;

	void Start () {
		funcList.Add(new actionFunc(TestActionFunc));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Interact() {
		Debug.Log("interact called");
		if(this.GetComponent<ButtonScript>())
		{
			this.GetComponent<ButtonScript>().Push();
		}
		if(funcList.Count != 0)
		{
			foreach(actionFunc a in funcList)
			{
				a();
			}
			foreach(DoorScript d in doorList)
			{
				d.Open();
			}
			foreach(RotateMirrorScript m in mirrorList)
			{
				m.flip();
			}
		}
		else
		{
			Debug.Log("no delegates");
		}
	}
	
	void TestActionFunc()
	{
		Debug.Log("test action func called");
	}

	public delegate void actionFunc();

	
}
