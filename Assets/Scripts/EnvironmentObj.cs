using UnityEngine;
using System.Collections;

public class EnvironmentObj : MonoBehaviour 
{
	public bool hasMiddleTween;
	public float tweenTime;
	
	private Vector2 startPosition;
	public Vector2 middlePosition;
	public Vector2 finalPosition;
	
	void Start()
	{
		startPosition = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
	}
	
	public void ExecuteForwardTween()
	{
		if(hasMiddleTween)
		{
			LeanTween.move(gameObject, new Vector3(middlePosition.x, middlePosition.y, gameObject.transform.position.z), tweenTime/2).setEase(LeanTweenType.easeInQuad).setOnComplete(Finish_Tween);
		}
		else
		{
			LeanTween.move(gameObject, new Vector3(finalPosition.x, finalPosition.y, gameObject.transform.position.z), tweenTime).setEase(LeanTweenType.easeInOutQuad);
		}
		LeanTween.scale(gameObject,new Vector3(1.5f,1.5f,1), tweenTime).setEase(LeanTweenType.easeInOutQuad);
	}
	
	private void Finish_Tween()
	{
		LeanTween.move(gameObject, new Vector3(finalPosition.x, finalPosition.y, gameObject.transform.position.z), tweenTime/2).setEase(LeanTweenType.easeOutQuad);
	}
	
	public void ExecuteBackwardTween()
	{
		LeanTween.move(gameObject, new Vector3(startPosition.x, startPosition.y, gameObject.transform.position.z), tweenTime).setEase(LeanTweenType.easeInOutQuad);
		LeanTween.scale(gameObject,new Vector3(1f,1f,1), tweenTime).setEase(LeanTweenType.easeInOutQuad);
	}
}
