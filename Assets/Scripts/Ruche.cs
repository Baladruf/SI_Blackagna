using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruche : MonoBehaviour {

    [SerializeField] int life;
    public bool isDestroy { get; private set; }
    public Transform spawnPlayer;
    private PlayerController player;

    private void Awake()
    {
        isDestroy = false;
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            isDestroy = true;
            //Game Manager
            //player invincible
        }
    }
}
