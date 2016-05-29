using UnityEngine;
using System.Collections;

public class Show_Text : MonoBehaviour 
{
	public TextMesh text;
	private bool shouldfadeIn;
	private bool shouldfadeOut;
	private bool fadeIn;
	private bool fadeOut;
	private float changingAlpha;

	
	void Start () 
	{
		shouldfadeIn = false;
		shouldfadeOut = false;
		fadeIn = false;
		fadeOut = false;
		changingAlpha = 0;
	}
	

	void Update () 
	{
		if(shouldfadeIn == true)
		{
			text.gameObject.SetActive (true);
			text.gameObject.GetComponent<Renderer>().material.color = new Color (1,1,1,changingAlpha);
			fadeIn = true;
			if(fadeIn == true)
			{
				changingAlpha += 0.75f * Time.deltaTime;
				text.gameObject.GetComponent<Renderer>().material.color += new Color (1,1,1,changingAlpha);
				if(changingAlpha > 1)
				{
					changingAlpha = 1;
					fadeIn = false;
				}
			}
		}

		if(shouldfadeOut == true)
		{
			text.gameObject.GetComponent<Renderer>().material.color = new Color (1,1,1,changingAlpha);
			fadeOut = true;
			if (fadeOut == true) 
			{
				changingAlpha += -0.75f * Time.deltaTime;
				text.gameObject.GetComponent<Renderer>().material.color += new Color (1,1,1,changingAlpha);

				if(changingAlpha < 0)
				{
					changingAlpha = 0;
					text.gameObject.SetActive (false);
					fadeOut = false;
				}
			}
		}
	}

	void OnMouseOver()
	{
		shouldfadeIn = true;
		shouldfadeOut = false;
	}

	void OnMouseExit()
	{
		shouldfadeIn = false;
		shouldfadeOut = true;
	}
}
