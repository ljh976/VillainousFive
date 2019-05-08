using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour {

    public GameObject cam, combatController, dialogueController, menuController;

    public string attributes;

    public float speed;

    [HideInInspector]
    private bool inMenu;

    // Use this for initialization
    void Start()
    {
        inMenu = false;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
