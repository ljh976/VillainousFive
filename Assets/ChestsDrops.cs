using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestsDrops : MonoBehaviour {

	public GameObject Item;
	bool isQuitting;
	// Update is called once per frame
	void Update () {
		
	}
	void OnApplicationQuit()
	{
		isQuitting = true;
	}
	public void OnDestroy()
	{
		if (!isQuitting)
		{
			Instantiate (Item, transform.position, Quaternion.identity);
		}
	}
}
