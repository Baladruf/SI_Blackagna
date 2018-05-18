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
    public SkinnedMeshRenderer head_mesh;
    public SkinnedMeshRenderer body_mesh;
    private Material head_material1;
    private Material head_material2;
    private Material body_material;
    public Color takedamage;
    private Color originalColor;
    private Coroutine hitCoroutine;
    [SerializeField] float timeHitColor = 0.2f;
    public ParticleSystem particleEnter;

    [SerializeField] Sprite portraitHumain;
    [SerializeField] Sprite portraitMonstre;

    protected override void Awake()
    {
        base.Awake();
        //rigidbodyCadavre = GetComponent<Rigidbody>();
        isHumain = true;
        body_material = body_mesh.material;
        head_material1 = head_mesh.materials[0];
        head_material2 = head_mesh.materials[1];
        originalColor = head_material1.color;

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
        if (hitCoroutine == null && cadavreWithPlayer != null)
        {
            hitCoroutine = StartCoroutine(HitColor());
        }


        print("hit");

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

                MakeSplashBlood();
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

        //print(" var null = " + (cadavreWithPlayer == null) + ", " + (player == null));
        if (cadavreWithPlayer == null && player != null)
        {
            cadavreWithPlayer = (PlayerController)player;
            this.player = player.player;
            //print("change icon");
            return;
        }

        if (other.tag == "Punch" && player != null)
        {
            TakeDamage(damagePunch + (int)(bonus * rankBonus), (PlayerController)player);
        }
    }

    private IEnumerator HitColor()
    {
        body_material.color = takedamage;
        head_material1.color = takedamage;
        head_material2.color = takedamage;

        yield return new WaitForSeconds(timeHitColor);
        
        body_material.color = originalColor;
        head_material1.color = originalColor;
        head_material2.color = originalColor;

        hitCoroutine = null;
    }

    public void ChangeSprite()
    {
        cadavreWithPlayer.portraitPlayer.sprite = portraitHumain;
    }
    public void MakeSplashBlood()
    {
        particleEnter.Play();
    }

}
