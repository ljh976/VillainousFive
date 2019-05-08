using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder2 : MonoBehaviour
{

    public string dialogue;
    private DialogueManger2 dMan;
    private DialogueManger2 number;


    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManger2>();

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

    }
}
