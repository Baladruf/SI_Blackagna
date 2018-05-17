using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public static bool gameStarted = false;
    public Transform playersControllers;
    public Cadavre cadavre;
    public PlayerController[] players;
    private int countRuche = 4;

    private void Awake()
    {
        Instance = this;
        players = new PlayerController[4];
        for(int i = 0; i < 4; i++)
        {
            players[i] = playersControllers.GetChild(i).GetComponent<PlayerController>();
        }
        cadavre = playersControllers.GetChild(4).GetComponent<Cadavre>();
    }

    private void Start()
    {
        gameStarted = true;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if(countRuche <= 1){
            int monsterRestant = 0;
            for(int i = 0; i < players.Length; i++){
                if(!players[i].isDead){
                    monsterRestant++;
                }
            }
            if(monsterRestant == 1){
                //fin game
            }
        }
    }

    public void RucheCount(){
        countRuche--;
    }
}
