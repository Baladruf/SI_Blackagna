using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public abstract class PlayerAbstrait : MonoBehaviour {

    public GameObject meshObject;
    public Player player;
    public bool isDead { get; protected set; }
    public Rigidbody rb { get; protected set; }
    public Vector3 spawnPosition { get; private set; }
    public int rankBonus { get; protected set; }
    protected Collider colliderPlayer;
    public PlayerMovement movement { get; protected set; }
    public Screeching screeching { get; protected set; }
    protected float life;
    [SerializeField]
    protected float delayInvicibleRucheDestry = 5;
    protected float timerInvicible = 0;
    [SerializeField]
    protected float bonus = 0.5f;
    public bool isHumain { get; protected set; }
    public PlayerAction action { get; protected set; }
    public Transform posShot;
    public GameObject shotPrefab;
    protected Renderer rendererMesh;

    public Gradient alien_color_gradient;
    protected TrailRenderer alien_trail;

    public bool isActif { get; protected set; }

    public Animator animator { get; protected set; }

    public void SetPlayerForward(Vector3 value)
    {
        if (value != Vector3.zero)
        {
            meshObject.transform.forward = value;
        }
    }

    protected virtual void Awake()
    {
        rankBonus = 0;
        rb = GetComponent<Rigidbody>();
        colliderPlayer = GetComponent<Collider>();
        (movement = GetComponent<PlayerMovement>()).playerController = this;
        (action = transform.GetChild(0).GetComponent<PlayerAction>()).playerController = this;
        (screeching = GetComponent<Screeching>()).playerController = this;
        rendererMesh = meshObject.GetComponent<Renderer>();
        isDead = false;
        isActif = true;
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void TimerInvincible()
    {
        if (timerInvicible != 0)
        {
            timerInvicible = Mathf.Max(0, timerInvicible - Time.deltaTime);
            return;
        }
    }

    public abstract void TakeDamage(float damage, PlayerController player = null);

    public void AddRankBonus()
    {
        rankBonus++;
    }

    public void InitInvincible()
    {
        timerInvicible = delayInvicibleRucheDestry;
    }

    public void Actif_Inactif(bool actif)
    {
        if (actif)
        {
            animator.enabled = true;
            rendererMesh.enabled = true;
            colliderPlayer.enabled = true;
            rb.useGravity = true;
            alien_trail.enabled = true;
            isActif = true;
        }
        else
        {
            animator.SetTrigger("death");
            if (isDead)
            {
                StartCoroutine(AnimationDeath());
            }
            else
            {
                animator.enabled = false;
                rendererMesh.enabled = false;
                rb.useGravity = false;
                colliderPlayer.enabled = false;
                alien_trail.enabled = false;
                isActif = false;
            }
        }
    }

    protected IEnumerator AnimationDeath()
    {
        yield return new WaitForSeconds(3.15f);
        animator.enabled = false;
        rendererMesh.enabled = false;
        rb.useGravity = false;
        colliderPlayer.enabled = false;
        alien_trail.enabled = false;
        isActif = false;
    }
}
