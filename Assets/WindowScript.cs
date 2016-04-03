using UnityEngine;
using System.Collections;

public class WindowScript : MonoBehaviour {
	public const float WINDOW_ALPHA = 122f/255f;
	// Use this for initialization
	public Color naturalColor = Color.blue;
	//float naturalAlpha = Color.blue.a;
	void Start () {
		naturalColor = this.GetComponent<Renderer>().material.GetColor("_Color");
		//naturalAlpha = this.GetComponent<Renderer>().material.GetColor("_Color").a;
	}

	public void tint(Color tintColor)
	{
		Debug.Log("natural color is: " + naturalColor.r + ", " + naturalColor.g + ", " + naturalColor.b + ", " + naturalColor.a);
		if(tintColor.r == 1f && tintColor.g == 1f && tintColor.b == 1f)
		{
			unTint();
		}
		else
		{
			//Color tempColor = new Color(tintColor.r * naturalColor.r, tintColor.g * naturalColor.g, tintColor.b * naturalColor.b, naturalColor.a);
			Color tempColor = CharacterBehaviorScript.filterColor(tintColor, naturalColor);
			tempColor.a = WINDOW_ALPHA;
			this.GetComponent<Renderer>().material.SetColor("_Color", tempColor);
		}
	}

	void unTint()
	{
		Debug.Log("untinting");
		this.GetComponent<Renderer>().material.SetColor("_Color", naturalColor);
	}
}
