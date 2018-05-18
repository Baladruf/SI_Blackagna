using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : PlayerAbstrait
{
    public int id;
    [SerializeField] Ruche ruchePlayer;
    [SerializeField] int maxLife = 100;
    [SerializeField] float dot = 2;
    [SerializeField] int foodRecup = 15;
    [SerializeField] int damagaShot = 5;
    [SerializeField] float timeDead = 2;
    [SerializeField] float penaliteDead = 1;
    [SerializeField] float maxTimeDead = 10;
    public Color colorPlayer {get; private set;}
    private Coroutine corouSave = null;
    //public Color colorPlayer;

    protected override void Awake()
    {
        base.Awake();
        life = maxLife;
        isHumain = false;
        //isDead = false;
        ruchePlayer.player = this;
    }



    private void Start()
    {
        player = ReInput.players.GetPlayer(id);
        alien_trail = transform.GetChild(1).GetComponent<TrailRenderer>();
        alien_trail.colorGradient = alien_color_gradient;
        colorPlayer = alien_color_gradient.Evaluate(0);
        rendererMesh = meshObject.transform.GetChild(1).GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isActif){
            TakeDamage(dot * Time.deltaTime);
            alien_trail.widthMultiplier = life / maxLife;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (timerInvicible > 0)
            return;

        if(collision.transform.tag == "Shot")
        {
            //Modif de la couleur
            TakeDamage(damagaShot + (int)(bonus * rankBonus));
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        //check manette branchée
         if (corouSave == null && player.isPlaying)
        {
            if (collision.transform.tag == "ExtWall")
            {
                corouSave = StartCoroutine(Rumble(1.0f, 0.8f, 0.2f));
            }
            else if (collision.transform.tag != "DoNotRumble")
            {
                corouSave = StartCoroutine(Rumble(0.5f, 0.4f, 0.15f));
            }
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

    public override void TakeDamage(float damage, PlayerController player = null)
    {
        life -= damage;
        if (life < 0 && !isDead)
        {
            isDead = true;
            Actif_Inactif(false);
            StartCoroutine(Respawn());
            //dead
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3.15f + timeDead);
        if (!ruchePlayer.isDestroy)
        {
            life = maxLife;
            transform.position = ruchePlayer.spawnPlayer.position;
            Actif_Inactif(true);
            isDead = false;
            if (timeDead + penaliteDead < maxTimeDead)
                timeDead += penaliteDead;
            else
                timeDead = maxTimeDead;
        }
    }

    public void RecupFood()
    {
        //life = Mathf.Max(maxLife, life + foodRecup);
        life = Mathf.Min(maxLife, life + foodRecup);
    }

    public void RecupFullLife()
    {
        life = maxLife;
    }

    IEnumerator Rumble(float leftMotor, float rightMotor, float duration)
    {
        Rewired.Joystick joy = player.controllers.Joysticks[0];
        joy.StopVibration();

        joy.SetVibration(0, leftMotor, true);
        joy.SetVibration(1, rightMotor, false);

        yield return new WaitForSeconds(duration);

        joy.StopVibration();
        corouSave = null;
    }

    public IEnumerator TimeStun(float delayStun)
    {
        yield return new WaitForSeconds(delayStun);
        movement.LeftStun();
    }
}
