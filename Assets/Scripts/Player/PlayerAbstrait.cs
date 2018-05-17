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
            rendererMesh.enabled = true;
            colliderPlayer.enabled = true;
            rb.useGravity = true;
        }
        else
        {
            rendererMesh.enabled = false;
            rb.useGravity = false;
            colliderPlayer.enabled = false;
        }
    }
}
