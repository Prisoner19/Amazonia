using UnityEngine;
using System.Collections;

public class EnvironmentObj : MonoBehaviour 
{
	public float tweenTime;
	public Vector2 finalPosition;
	
	public void ExecuteTween()
	{
		LeanTween.move(gameObject, new Vector3(finalPosition.x, finalPosition.y, gameObject.transform.position.z), tweenTime).setEase(LeanTweenType.easeInOutQuad);
		LeanTween.scale(gameObject,new Vector3(1.2f,1.2f,1), tweenTime).setEase(LeanTweenType.easeInOutQuad);
	}
}
