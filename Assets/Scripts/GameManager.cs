using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public static bool gameStarted = false;
    public Transform playersControllers;
    public Cadavre Cadavre;
    public PlayerController[] players;

    private void Awake()
    {
        Instance = this;
        players = new PlayerController[4];
        for(int i = 0; i < 4; i++)
        {
            players[i] = playersControllers.GetChild(i).GetComponent<PlayerController>();
        }
    }

    private void Start()
    {
        gameStarted = true;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
