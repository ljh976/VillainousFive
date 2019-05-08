using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public GameObject key;

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(key.gameObject);

    }
}
