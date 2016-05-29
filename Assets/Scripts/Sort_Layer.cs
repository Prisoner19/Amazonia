using UnityEngine;
using System.Collections;

public class Sort_Layer : MonoBehaviour 
{
	public int SortInLayer;
	void Awake()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortInLayer;
	}

	void Start () 
	{
	
	}
	

	void Update () 
	{
	
	}
}
