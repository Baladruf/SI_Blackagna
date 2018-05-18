using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Cadavre : PlayerAbstrait {

    [NonSerialized]
    public PlayerController cadavreWithPlayer = null;
    //public Rigidbody rigidbodyCadavre { get; private set; }
    [SerializeField] int maxHumainLife = 500;
    [SerializeField] float recupHpHumain = 2;
    [SerializeField] int damagePunch = 3;
    [SerializeField] float forcePropulsion = 25;
    [SerializeField] float forcePropUp = 5;
    [SerializeField] float delayStun;

    [SerializeField] Sprite portraitHumain;
    [SerializeField] Sprite portraitMonstre;

    protected override void Awake()
    {
        base.Awake();
        //rigidbodyCadavre = GetComponent<Rigidbody>();
        isHumain = true;
    }

    private void Start()
    {
        animator = meshObject.transform.GetChild(1).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        life = Mathf.Min(maxHumainLife, life + (recupHpHumain * Time.deltaTime));
        if(cadavreWithPlayer != null)
        {
            cadavreWithPlayer.lifeSlider.value = life / maxHumainLife;
        }
    }

    public override void TakeDamage(float damage, PlayerController player = null)
    {
        life -= damagePunch;
        if (cadavreWithPlayer != null)
        {
            cadavreWithPlayer.lifeSlider.value = life / maxHumainLife;
        }
        if (life < 0)
        {
            cadavreWithPlayer.Actif_Inactif(true);
            cadavreWithPlayer.RecupFullLife();
            life = maxHumainLife;
            cadavreWithPlayer.transform.position = transform.position;

            //meshObject.GetComponent<Renderer>().enabled = true;
            if (player != null)
            {
                cadavreWithPlayer.transform.forward = (player.transform.position - transform.position).normalized.WithY(0);
                cadavreWithPlayer.rb.velocity = (-transform.forward * forcePropulsion).WithRelativeY(forcePropUp);
                cadavreWithPlayer.movement.Stun();
                StartCoroutine(cadavreWithPlayer.TimeStun(delayStun));

                cadavreWithPlayer.portraitPlayer.sprite = portraitMonstre;
                cadavreWithPlayer = player;
                cadavreWithPlayer.portraitPlayer.sprite = portraitHumain;

                this.player = player.player;
                player.Actif_Inactif(false);
                cadavreWithPlayer.lifeSlider.value = life / maxHumainLife;
            }
        }
    }

    public void SetHumainLife()
    {
        life = maxHumainLife;
    }

    private void OnTriggerEnter(Collider other)
    {
        var attaquant = other.GetComponent<ColliderCone>();
        if (timerInvicible > 0 || attaquant == null)
            return;


        //faire swap
        var player = attaquant.action.playerController;

        if (cadavreWithPlayer == null && player != null)
        {
            cadavreWithPlayer = (PlayerController)player;
            this.player = player.player;
            cadavreWithPlayer.portraitPlayer.sprite = portraitHumain;
            return;
        }

        if (other.tag == "Punch" && player != null)
        {
            TakeDamage(damagePunch + (int)(bonus * rankBonus), (PlayerController)player);
        }
    }
}
