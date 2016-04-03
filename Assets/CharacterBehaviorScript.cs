using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.UI;

public class CharacterBehaviorScript : MonoBehaviour {

	// Use this for initialization
	public bool isActiveCharacter = true;
	public GameObject previousCharacter;
	public Color tintColor;
	public Camera characterCamera;
	public Material skyboxMat;
	ActionItemScript actionItem;
	GrabbableItemScript grabbableItem;

	void Start () {
		if(tintColor == null)
		{
			tintColor = Color.white;
			tintColor.a = WindowScript.WINDOW_ALPHA;
		}
		characterCamera = this.GetComponentInChildren<Camera>();
		this.GetComponentInChildren<Renderer>().material.SetColor("_Color", tintColor);
	}
	
	// Update is called once per frame
	void Update () {

		Debug.DrawRay(characterCamera.transform.position, characterCamera.transform.rotation * Vector3.forward * 1000, Color.green);
		if(isActiveCharacter) {
			if(Input.GetButtonDown("Grab"))
			{
				if(grabbableItem != null)
				{
					grabbableItem.Grab(characterCamera.transform);
				}
			}

			if(Input.GetButtonUp("Grab"))
			{
					grabbableItem.UnGrab();	
			}

			if(Input.GetButtonDown("Jump"))
			{
					if(actionItem != null)
					{
					actionItem.Interact();
					}	
			}

			if(Input.GetButtonDown("Duplicate"))
			{
				if(Duplicate())
				{
					this.isActiveCharacter = false;
					GetComponent<FirstPersonController>().enabled = false;
					GetComponentInChildren<Camera>().enabled = false;
					GetComponentInChildren<Light>().enabled = false;
				}
			}

			if(Input.GetButtonDown("UnDuplicate"))
			{
				Die();
			}


		}
	}

	public void Die()
	{
		previousCharacter.GetComponent<CharacterBehaviorScript>().isActiveCharacter = true;
		previousCharacter.GetComponent<FirstPersonController>().enabled = true;
		previousCharacter.GetComponentInChildren<Camera>().enabled = true;
		previousCharacter.GetComponentInChildren<Light>().enabled = true;
		Recolor(previousCharacter.GetComponent<CharacterBehaviorScript>().tintColor);
		Color tempColor = previousCharacter.GetComponent<CharacterBehaviorScript>().tintColor;
		Debug.Log("previous color is: " + tempColor.r + ", " + tempColor.g + ", " + tempColor.b + "," + tempColor.a);
		Destroy(this.gameObject);
	}

	bool Duplicate()
	{
		
		RaycastHit raycastInfo;
		Color childTintColor = tintColor;

		return shootCamera(out raycastInfo, characterCamera.transform.position, characterCamera.transform.rotation * Vector3.forward, ref childTintColor);
	}

	void Recolor(Color newColor)
	{
		foreach(Light l in FindObjectsOfType<Light>())
		{
			l.color = newColor;
		}

		foreach(UnityEngine.UI.Image i in FindObjectsOfType<UnityEngine.UI.Image>())
		{
			newColor.a = 0.5f;
			i.color = newColor;
		}

		foreach(WindowScript w in FindObjectsOfType<WindowScript>())
		{
			w.tint(newColor);
		}
		//RenderSettings.skybox.SetColor("_Tint", newColor);
		//RenderSettings.skyboSetColor("_Color",newColor);
		//RenderSettings.ambientGroundColor = newColor;
		//skyboxMat.SetColor("_Tint", newColor);
		//skyboxMat.color = newColor;
		//RenderSettings.skybox.SetColor("_SkyTint", newColor);
		characterCamera.GetComponent<Skybox>().material.SetColor("_SkyTint", newColor);
		characterCamera.GetComponent<Skybox>().material.SetColor("_GroundColor", newColor);
		DynamicGI.UpdateEnvironment();
	}

	void OnTriggerEnter(Collider coll)
	{
		Debug.Log("trigger enter");
		if (coll.gameObject.GetComponent<ActionItemScript>())
		{
			this.actionItem = coll.gameObject.GetComponent<ActionItemScript>();
		}
		else if (coll.gameObject.GetComponent<GrabbableItemScript>())
		{
			this.grabbableItem = coll.gameObject.GetComponent<GrabbableItemScript>();
		}
			
	}

	void OnTriggerExit(Collider coll)
	{	Debug.Log("trigger exit");
		if(coll.gameObject.GetComponent<ActionItemScript>() && this.actionItem == coll.gameObject.GetComponent<ActionItemScript>())
		{
			this.actionItem = null;
		}
		else if (coll.gameObject.GetComponent<GrabbableItemScript>() && this.grabbableItem == coll.gameObject.GetComponent<GrabbableItemScript>())
		{
			this.grabbableItem = null;
		}
	}

	public static Color filterColor(Color filter, Color currentTint)
	{
		filter.a = 1;

		if(filter == Color.white)
		{
			Debug.Log("FILTER WAS WHITE"); //this should never happen
			return Color.white;
		}

		if(currentTint == Color.white || currentTint == filter)
		{
			return filter;
		}

		if(currentTint == Color.red)
		{
			if(filter == Color.green)
			{
				return Color.yellow;
			}

			if (filter == Color.blue)
			{
				return Color.magenta;
			}

			if(filter == Color.cyan)
			{
				return Color.white;
			}

			if(filter == Color.magenta)
			{
				return Color.magenta;
			}

			if(filter == Color.yellow)
			{
				return Color.yellow;
			}
		}

		if(currentTint == Color.green)
		{
			if(filter == Color.blue)
			{
				return Color.cyan;
			}

			if (filter == Color.red)
			{
				return Color.yellow;
			}

			if(filter == Color.cyan)
			{
				return Color.cyan;
			}

			if(filter == Color.magenta)
			{
				return Color.white;
			}

			if(filter == Color.yellow)
			{
				return Color.yellow;
			}
		}

		if(currentTint == Color.blue)
		{
			if(filter == Color.green)
			{
				return Color.cyan;
			}

			if (filter == Color.red)
			{
				return Color.magenta;
			}

			if(filter == Color.cyan)
			{
				return Color.cyan;
			}

			if(filter == Color.magenta)
			{
				return Color.magenta;
			}

			if(filter == Color.yellow)
			{
				return Color.white;
			}
		}

		if(currentTint == Color.cyan)
		{
			if(filter == Color.red || filter == Color.magenta || filter == Color.yellow)
			{
				return Color.white;
			}

			if(filter == Color.blue || filter == Color.green)
			{
				return Color.cyan;
			}
				
		}

		if(currentTint == Color.yellow)
		{
			if(filter == Color.blue || filter == Color.magenta || filter == Color.cyan)
			{
				return Color.white;
			}

			if(filter == Color.red || filter == Color.green)
			{
				return Color.yellow;
			}

		}

		if(currentTint == Color.magenta)
		{
			if(filter == Color.green || filter == Color.yellow || filter == Color.cyan)
			{
				return Color.white;
			}

			if(filter == Color.red || filter == Color.blue)
			{
				return Color.magenta;
			}

		}

		return filter;
	}

	bool shootCamera(out RaycastHit raycastInfo, Vector3 origin, Vector3 direction,  ref Color currentColor)
	{
		
		if(Physics.Raycast(origin, 
			direction, out raycastInfo) 
			&& raycastInfo.collider.tag == "ValidDupeLocation")
		{
			if(raycastInfo.collider.gameObject.GetComponent<WindowScript>())
			{
				currentColor = filterColor(raycastInfo.collider.gameObject.GetComponent<WindowScript>().naturalColor, currentColor);
				return shootCamera(out raycastInfo, raycastInfo.point + characterCamera.transform.rotation * Vector3.forward * 1, direction, ref currentColor);
			} else if(raycastInfo.collider.gameObject.GetComponent<MirrorReflection>()){
				return shootCamera(out raycastInfo, raycastInfo.point + characterCamera.transform.rotation * Vector3.forward * 1, Vector3.Reflect(direction, raycastInfo.normal), ref currentColor);
			}

			Recolor(currentColor);

			GameObject child = Instantiate(Resources.Load("OriginalCharacter"), raycastInfo.point, Quaternion.identity) as GameObject;
			child.GetComponent<CharacterBehaviorScript>().previousCharacter = this.gameObject;
			child.GetComponent<CharacterBehaviorScript>().tintColor = currentColor;
			child.GetComponentInChildren<Light>().color = currentColor;
			return true;
		}
		else
		{
			return false;
		}
	}
}
