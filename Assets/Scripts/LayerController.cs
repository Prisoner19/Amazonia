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
		StartCoroutine(ExecuteTweenOnLayer(goForeEnvironment, 0.07f));
		StartCoroutine(ExecuteTweenOnLayer(goMiddleEnvironment, 0f));
		
		StartCoroutine(ExecuteTweenOnLayer(goCurrentFloor, 0.07f));
		StartCoroutine(ExecuteTweenOnLayer(goNextFloor, 0f));
	}

	private IEnumerator ExecuteTweenOnLayer(GameObject layer, float delay)
	{
		yield return new WaitForSeconds(delay);
		
		foreach(EnvironmentObj envObj in layer.GetComponentsInChildren<EnvironmentObj>())
		{
			envObj.ExecuteTween();
		}
	}
	
	public static LayerController Instance
	{
		get{ return _instance; }
	}
}
