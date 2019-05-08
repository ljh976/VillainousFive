using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder : MonoBehaviour
{

    public string dialogue;
    private DialogueManger dMan;
    private DialogueManger number;


    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManger>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (dMan.number == 0)
        {
            dMan.ShowBox(dialogue);
            dMan.number = dMan.number + 1;
        }

        if(dMan.number == 1)
        {
            dMan.ShowBox(dialogue);
            dMan.number = dMan.number + 1;
        }
    }
}
