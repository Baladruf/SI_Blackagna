using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance { get; private set; }
    public static bool gameStarted = false;
    public PlayerController[] playerController;
    public PlayerController Cadavre = null;

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
