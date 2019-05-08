using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BaddieController : MonoBehaviour {

    public GameObject player;

    public string attributes;

    public float speed;

    [HideInInspector]
    private bool inMenu;

    // Use this for initialization
    void Start () {
        inMenu = false;
	}
	
	// Update is called once per frame
	void Update () {
			if(Vector3.Distance(transform.position, player.transform.position) < 0.75f)
			{
				transform.GetComponent<Rigidbody2D>().AddForce((player.transform.position - transform.position).normalized * 15);
			}
	}
}
