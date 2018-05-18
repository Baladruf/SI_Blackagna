﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruche : MonoBehaviour {

    [SerializeField] int life;
    public bool isDestroy { get; private set; }
    public Transform spawnPlayer;
    [System.NonSerialized]
    public PlayerController player;
    [SerializeField] int damage = 5;

    private void Awake()
    {
        isDestroy = false;
    }

    public void TakeDamage(int damage)
    {
        var manager = GameManager.Instance;
        if (ReferenceEquals(manager.cadavre.cadavreWithPlayer, player))
            return;

        life -= damage;
        if(life <= 0)
        {
            isDestroy = true;
            GameManager.Instance.RucheCount();
            player.InitInvincible();
            for(int i = 0; i < GameManager.Instance.players.Length; i++)
            {
                GameManager.Instance.players[i].AddRankBonus();
            }
            //dead ruche
            GameManager.Instance.AddIdDestroyRuche(player.id);
            player.rucheIcon.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Shot")
        {
            TakeDamage(damage);
        }
    }
}
