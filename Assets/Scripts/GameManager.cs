using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public static bool gameStarted = false;
    public Transform playersControllers;
    public Cadavre Cadavre;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
