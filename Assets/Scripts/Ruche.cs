using System.Collections;
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
        if (ReferenceEquals(GameManager.Instance.Cadavre.cadavreWithPlayer, player))
            return;

        life -= damage;
        if(life <= 0)
        {
            isDestroy = true;
            player.InitInvincible();
            for(int i = 0; i < GameManager.Instance.players.Length; i++)
            {
                GameManager.Instance.players[i].AddRankBonus();
            }
            //dead ruche
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
