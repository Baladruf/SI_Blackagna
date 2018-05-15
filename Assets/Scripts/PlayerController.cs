using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour {

    public PlayerMovement movement { get; private set; }
    public Rigidbody rb { get; private set; }
    public Player player;
    [SerializeField] int idPlayer;
    public Vector3 spawnPosition { get; private set; }
    [SerializeField] GameObject meshObject;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = ReInput.players.GetPlayer(idPlayer);
        (movement = GetComponent<PlayerMovement>()).playerController = this;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public override bool Equals(object other)
    {
        if (other is PlayerController)
        {
            return idPlayer == ((PlayerController)other).idPlayer;
        }
        return false;
    }

    public void SetPlayerForward(Vector3 value)
    {
        if (value != Vector3.zero)
        {
            meshObject.transform.forward = value;
        }
    }
}
