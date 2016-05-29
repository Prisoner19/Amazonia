using UnityEngine;
using System.Collections;

public class LayerController : MonoBehaviour 
{
	private static LayerController _instance;
	
	public GameObject goLayer1;
	public GameObject goLayer2;
    public GameObject goLayer3;
    public GameObject goLayer4;
    public GameObject goLayer5;

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
        if (GetCurrentLayer() != null)
        { 
            GetCurrentLayer().GetComponent<LayerEvents>().ExecuteCommandList(EventTrigger.onMoveForward);
        }
        
        _currentLayer = (_currentLayer == 5) ? _currentLayer : _currentLayer + 1;
    }

    public void MoveBackward()
    {
        if (GetCurrentLayer() != null)
        { 
            GetCurrentLayer().GetComponent<LayerEvents>().ExecuteCommandList(EventTrigger.onMoveBackward);
        }
        
        _currentLayer = (_currentLayer == 1) ? _currentLayer : _currentLayer - 1;
	}

    private GameObject GetCurrentLayer()
    { 
        switch (_currentLayer)
        {
            case 1: return goLayer1;
            case 2: return goLayer2;
            case 3: return goLayer3;
            case 4: return goLayer4;
            case 5: return goLayer5;
            default: return null;
        }
    }

    // public void MoveForward()
    // {
    // 	_currentLayer += 1;
    // 	StartCoroutine(ExecuteTweenOnLayer(goForeEnvironment, 0.1f, true));
    // 	StartCoroutine(ExecuteTweenOnLayer(goMiddleEnvironment, 0f, true));

    // 	StartCoroutine(ExecuteTweenOnLayer(goCurrentFloor, 0.1f, true));
    // 	StartCoroutine(ExecuteTweenOnLayer(goNextFloor, 0f, true));
    // }

    // public void MoveBackward()
    // {
    // 	_currentLayer -= 1;
    // 	StartCoroutine(ExecuteTweenOnLayer(goForeEnvironment, 0f, false));
    // 	StartCoroutine(ExecuteTweenOnLayer(goMiddleEnvironment, 0.1f, false));

    // 	StartCoroutine(ExecuteTweenOnLayer(goCurrentFloor, 0f, false));
    // 	StartCoroutine(ExecuteTweenOnLayer(goNextFloor, 0.1f, false));
    // }

    // private IEnumerator ExecuteTweenOnLayer(GameObject layer, float delay, bool isForward)
    // {
    // 	yield return new WaitForSeconds(delay);

    // 	foreach(EnvironmentObj envObj in layer.GetComponentsInChildren<EnvironmentObj>())
    // 	{
    // 		if(isForward)
    // 		{
    // 			envObj.ExecuteForwardTween();
    // 		}
    // 		else
    // 		{
    // 			envObj.ExecuteBackwardTween();
    // 		}
    // 	}
    // }

    public static LayerController Instance
	{
		get{ return _instance; }
	}
}
