using UnityEngine;
using System.Collections;

public class LayerController : MonoBehaviour 
{
	private static LayerController _instance;
	
	public GameObject goForeEnvironment;
	public GameObject goMiddleEnvironment;
	
	public GameObject goCurrentFloor;
	public GameObject goNextFloor;

	private int _currentLayer;

	void Awake()
	{
		_instance = this;
	}

	void Start () 
	{
		_currentLayer = 1;
	}
	
	public void MoveForward()
	{
		_currentLayer += 1;
		StartCoroutine(ExecuteTweenOnLayer(goForeEnvironment, 0.1f, true));
		StartCoroutine(ExecuteTweenOnLayer(goMiddleEnvironment, 0f, true));
		
		StartCoroutine(ExecuteTweenOnLayer(goCurrentFloor, 0.1f, true));
		StartCoroutine(ExecuteTweenOnLayer(goNextFloor, 0f, true));
	}
	
	public void MoveBackward()
	{
		_currentLayer -= 1;
		StartCoroutine(ExecuteTweenOnLayer(goForeEnvironment, 0f, false));
		StartCoroutine(ExecuteTweenOnLayer(goMiddleEnvironment, 0.1f, false));
		
		StartCoroutine(ExecuteTweenOnLayer(goCurrentFloor, 0f, false));
		StartCoroutine(ExecuteTweenOnLayer(goNextFloor, 0.1f, false));
	}

	private IEnumerator ExecuteTweenOnLayer(GameObject layer, float delay, bool isForward)
	{
		yield return new WaitForSeconds(delay);
		
		foreach(EnvironmentObj envObj in layer.GetComponentsInChildren<EnvironmentObj>())
		{
			if(isForward)
			{
				envObj.ExecuteForwardTween();
			}
			else
			{
				envObj.ExecuteBackwardTween();
			}
		}
	}
	
	public static LayerController Instance
	{
		get{ return _instance; }
	}
}
