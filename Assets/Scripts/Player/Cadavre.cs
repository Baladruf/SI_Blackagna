using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cadavre : MonoBehaviour {

    [NonSerialized]
    public PlayerController cadavreWithPlayer = null;
    public Rigidbody rigidbodyCadavre { get; private set; }
    public Transform posShot;
    public GameObject shotPrefab;

    private void Awake()
    {
        rigidbodyCadavre = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
