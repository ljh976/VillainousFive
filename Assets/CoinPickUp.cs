using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickUp : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other){
		if (other.GetComponent<PlayerController> () == null)
			return;

        other.GetComponent<PlayerController>().coins++;
        other.GetComponents<AudioSource>()[0].Play();
        Destroy (gameObject);
	}
}
