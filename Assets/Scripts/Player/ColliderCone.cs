using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderCone : MonoBehaviour {

    [System.NonSerialized]
    public PlayerAction action;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Food")
        {
            var food = other.GetComponent<Food>();
            food.Eat();
            ((PlayerController)(action.playerController)).RecupFood();
        }else if(other.tag == "Cadavre")
        {
            var cadavre = other.GetComponent<Cadavre>();
            if(cadavre != null && cadavre.cadavreWithPlayer == null)
            {
                SetCadavrePlayer(cadavre);
            }
        }
    }

    public void SetCadavrePlayer(Cadavre cadavre)
    {
        cadavre.cadavreWithPlayer = (PlayerController)action.playerController;
        cadavre.player = action.playerController.player;
        cadavre.SetHumainLife();
        action.playerController.Actif_Inactif(false);
    }
}
