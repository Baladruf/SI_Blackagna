﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCone : MonoBehaviour {

    [System.NonSerialized]
    public PlayerAction action;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            var food = other.GetComponent<Food>();
            food.Eat();
            action.playerController.RecupFood();
        }else if(other.tag == "Cadavre")
        {
            var cadavre = GameManager.Instance.Cadavre;
            if(cadavre.cadavreWithPlayer == null)
            {
                action.playerController.meshObject.GetComponent<MeshRenderer>().enabled = false;
                //transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                action.playerController.transform.parent = cadavre.transform.GetChild(0);
                action.playerController.transform.localPosition = Vector3.zero;
                cadavre.cadavreWithPlayer = action.playerController;
            }
        }
    }
}
