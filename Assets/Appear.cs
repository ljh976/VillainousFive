using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Appear : MonoBehaviour {

    private DialogueManger4 dMan;
    private DialogueManger4 currentLine;

    public GameObject thehero;

    // Use this for initialization
    void Start () {
        dMan = FindObjectOfType<DialogueManger4>();
    }
	
	// Update is called once per frame
	void Update () {

        //Debug.Log(dMan.currentLine);
        if (dMan.currentLine > 1)
        {
            thehero.SetActive(true);
        }
        else
        {
            thehero.SetActive(false);
        }
	}
}
