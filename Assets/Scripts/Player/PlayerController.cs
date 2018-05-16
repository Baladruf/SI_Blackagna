using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{

    public PlayerMovement movement { get; private set; }
    public PlayerAction action { get; private set; }
    public Rigidbody rb { get; private set; }
    public Player player;
    private static int idPlayer = 0;
    public int id { get; private set; }
    public Vector3 spawnPosition { get; private set; }
    public GameObject meshObject;
    public bool isDead { get; private set; }
    [SerializeField] Ruche ruchePlayer;


    [SerializeField] int life = 100;
    [SerializeField] int damagaShot = 5;
    [SerializeField] int damagePunch = 3;

    [SerializeField] float timeDead = 2;
    [SerializeField] float penaliteDead = 1;
    [SerializeField] float maxTimeDead = 10;

    public bool isHumain { get; private set; }

    private void Awake()
    {
        isHumain = false;
        rb = GetComponent<Rigidbody>();
        (movement = GetComponent<PlayerMovement>()).playerController = this;
        (action = transform.GetChild(0).GetComponent<PlayerAction>()).playerController = this;
        isDead = false;
    }



    private void Start()
    {
        player = ReInput.players.GetPlayer(idPlayer);
        id = idPlayer;
        idPlayer++;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Shot")
        {
            TakeDamage(damagaShot);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Punch")
        {
            TakeDamage(damagePunch);
        }
    }

    public override bool Equals(object other)
    {
        if (other is PlayerController)
        {
            return idPlayer == ((PlayerController)other).id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return idPlayer.GetHashCode();
    }

    public void SetPlayerForward(Vector3 value)
    {
        if (value != Vector3.zero)
        {
            meshObject.transform.forward = value;
        }
    }

    public void TakeDamage(int damage)
    {
        life -= damage;
        if(life < 0){
            isDead = true;
            //dead
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(timeDead);
        if (!ruchePlayer.isDestroy)
        {
            transform.position = ruchePlayer.spawnPlayer.position;
            if (timeDead + penaliteDead < maxTimeDead)
                timeDead += penaliteDead;
            else
                timeDead = maxTimeDead;
        }
    }
}
