using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{

    public PlayerMovement movement { get; private set; }
    public PlayerAction action { get; private set; }
    public Rigidbody rb { get; private set; }
    private Collider colliderPlayer;
    public Player player;
    //private static int idPlayer;
    public int id;
    public Vector3 spawnPosition { get; private set; }
    public GameObject meshObject;
    public bool isDead { get; private set; }
    [SerializeField] Ruche ruchePlayer;


    private float life;
    [SerializeField] int maxLife = 100;
    [SerializeField] float dot = 2;
    [SerializeField] int maxHumainLife = 500;
    [SerializeField] float recupHpHumain = 2;
    [SerializeField] int foodRecup = 15;

    [SerializeField] int damagaShot = 5;
    [SerializeField] int damagePunch = 3;

    [SerializeField] float timeDead = 2;
    [SerializeField] float penaliteDead = 1;
    [SerializeField] float maxTimeDead = 10;

    [SerializeField] float delayInvicibleRucheDestry = 5;
    private float timerInvicible = 0;
    public int rankBonus { get; private set; }
    [SerializeField] float bonus = 0.5f;

    public bool isHumain { get; private set; }

    public Gradient alien_color_gradient;
    private TrailRenderer alien_trail;

    private void Awake()
    {
        life = maxLife;
        rankBonus = 0;
        isHumain = false;
        rb = GetComponent<Rigidbody>();
        colliderPlayer = GetComponent<Collider>();
        (movement = GetComponent<PlayerMovement>()).playerController = this;
        (action = transform.GetChild(0).GetComponent<PlayerAction>()).playerController = this;
        isDead = false;
        ruchePlayer.player = this;
    }



    private void Start()
    {
        player = ReInput.players.GetPlayer(id);
        //id = idPlayer;
        //idPlayer++;
        //print("player " + gameObject.name + ", id = " + id);
        alien_trail = transform.GetChild(1).GetComponent<TrailRenderer>();
        alien_trail.colorGradient = alien_color_gradient;
    }

    // Update is called once per frame
    void Update()
    {
        var cadavre = GameManager.Instance.Cadavre.cadavreWithPlayer;
        if(ReferenceEquals(this, cadavre))
        {
            life = Mathf.Min(maxHumainLife, life + (recupHpHumain * Time.deltaTime));
        }

        if(timerInvicible != 0)
        {
            timerInvicible = Mathf.Max(0, timerInvicible - Time.deltaTime);
            return;
        }

        if (!ReferenceEquals(this, cadavre))
        {
            life -= dot * Time.deltaTime;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timerInvicible > 0)
            return;

        if(collision.transform.tag == "Shot")
        {
            TakeDamage(damagaShot + (int)(bonus * rankBonus));
        }

        if (collision.transform.tag == "ExtWall")
        {
            int motorIndex = 0;
            float motorLevel = 1.0f;
            float duration = 2.0f;

            //--------------------------------VIBRATION------------------------
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var cadavre = GameManager.Instance.Cadavre;
        if (timerInvicible > 0)
            return;


        if (cadavre.cadavreWithPlayer == null)
            return;

        var player = other.GetComponent<PlayerController>();
        if (other.tag == "Punch" && player != null && ReferenceEquals(cadavre.cadavreWithPlayer, player))
        {
            TakeDamage(damagePunch + (int)(bonus * rankBonus));
        }
    }

    public override bool Equals(object other)
    {
        if (other is PlayerController)
        {
            return id == ((PlayerController)other).id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return id.GetHashCode();
    }

    public void SetPlayerForward(Vector3 value)
    {
        if (value != Vector3.zero)
        {
            meshObject.transform.forward = value;
        }
    }

    public void TakeDamage(int damage, PlayerController player = null)
    {
        life -= damage;
        if (ReferenceEquals(this, GameManager.Instance.Cadavre.cadavreWithPlayer))
        {
            if(life < 0)
            {
                life = maxLife;
                //echanger de corps
            }
        }
        else
        {
            if (life < 0)
            {
                isDead = true;
                colliderPlayer.enabled = false;
                meshObject.GetComponent<Renderer>().enabled = false;
                StartCoroutine(Respawn());
                //dead
            }
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeDead);
        if (!ruchePlayer.isDestroy)
        {
            transform.position = ruchePlayer.spawnPlayer.position;
            colliderPlayer.enabled = true;
            meshObject.GetComponent<Renderer>().enabled = true;
            life = maxLife;
            if (timeDead + penaliteDead < maxTimeDead)
                timeDead += penaliteDead;
            else
                timeDead = maxTimeDead;
        }
    }

    public void AddRankBonus()
    {
        rankBonus++;
    }

    public void InitInvincible()
    {
        timerInvicible = delayInvicibleRucheDestry;
    }

    public void RecupFood()
    {
        life = Mathf.Max(maxLife, life + foodRecup);
    }
}
