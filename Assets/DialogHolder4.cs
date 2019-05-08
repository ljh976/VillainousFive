using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHolder4 : MonoBehaviour
{

    public string dialogue;
    private DialogueManger4 dMan;
    private DialogueManger4 number;


    // Use this for initialization
    void Start()
    {
        dMan = FindObjectOfType<DialogueManger4>();

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
