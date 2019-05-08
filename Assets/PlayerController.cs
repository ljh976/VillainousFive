using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public GameObject cam, combatController, dialogueController, menuController;

    public string attributes;

    public float speed;
	public Vector2 lastMove;
    private Animator anim;

    public int coins = 0;

    [HideInInspector]
    public bool inMenu;

    [HideInInspector]
    private Vector3 cameraPos;

    private DialogueManger dman;
    private DialogueManger2 dman2;
    private DialogueManger3 dman3;
    private DialogueManger4 dman4;


    // Use this for initialization
    void Start()
    {
        inMenu = false;

        anim = GetComponent<Animator>();
		lastMove = new Vector2 (0, -1f);

        dman = FindObjectOfType<DialogueManger>();
        dman2 = FindObjectOfType<DialogueManger2>();
        dman3 = FindObjectOfType<DialogueManger3>();
        dman4 = FindObjectOfType<DialogueManger4>();
    }

    // Update is called once per frame
    void Update()
    {
        cameraPos = new Vector3(transform.position.x, transform.position.y, -5);
        cam.transform.position = cameraPos;

		Vector2 movement = new Vector2 (Input.GetAxisRaw ("Horizontal") * speed, Input.GetAxisRaw ("Vertical") * speed);
		anim.SetBool ("IsPlayerMoving", false);

		if (dman.canmove == false && dman2.canmove == false && dman3.canmove == false && dman4.canmove == false && !inMenu) 
		{
			if (movement != Vector2.zero) 
			{
				anim.SetBool ("IsPlayerMoving", true);
				anim.SetFloat ("MoveX", movement.x);
				anim.SetFloat ("MoveY", movement.y);

				lastMove = movement;
			 
			} else
				anim.SetBool ("IsPlayerMoving", false);
			
			transform.GetComponent<Rigidbody2D> ().AddForce (movement);

			anim.SetFloat ("LastMoveX", lastMove.x);
			anim.SetFloat ("LastMoveY", lastMove.y);
		}
		

    }

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Chest") 
		{
            transform.GetComponents<AudioSource>()[1].Play();
			Destroy (other.gameObject, 1);
		}
	}
}