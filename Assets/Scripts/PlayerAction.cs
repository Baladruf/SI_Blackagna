using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [System.NonSerialized]
    public PlayerController playerController;
    [SerializeField] int damage = 3;
    [SerializeField] float delayAttack = 0.5f;
    private float cooldown = 0;


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
