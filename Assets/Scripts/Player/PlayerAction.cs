using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [System.NonSerialized]
    public PlayerAbstrait playerController;
    [System.NonSerialized]
    public ColliderCone colliderCone;
    [SerializeField] float delayAttack = 0.5f;
    [SerializeField] float delayShot = 1.5f;
    [SerializeField] int nbMunitionByShot = 5;
    [SerializeField] float delayBetweenShot = 0.2f;
    private bool cooldownPunch = true;
    private bool cooldownShot = true;
    private Collider coneAttack;
    [SerializeField] float timeCollider = 0.2f;



    private void Start()
    {
        if (!playerController.isHumain)
        {
            coneAttack = transform.GetChild(0).GetComponent<Collider>();
            coneAttack.enabled = false;
            (colliderCone = coneAttack.GetComponent<ColliderCone>()).action = this;
        }
    }

    // Update is called once per frame
    void Update () {
        Debug.DrawRay(transform.position, transform.forward * 5,Color.red);

        if (playerController.isDead || !playerController.isActif)
        {
            return;
        }

        if (playerController.isHumain)
        {
            if(((Cadavre)playerController).cadavreWithPlayer == null)
            {
                return;
            }

            if (playerController.player.GetButton("RightTrigger") && cooldownShot)
            {
                //playerController.animator.SetTrigger("attack");
                cooldownShot = false;
                StartCoroutine(TimeShot());
            }
        }
        else
        {
            if (playerController.player.GetButton("RightTrigger") && cooldownPunch)
            {
                playerController.animator.SetTrigger("attack");
                coneAttack.enabled = true;
                cooldownPunch = false;
                StartCoroutine(TimerCollider());
            }
        }
	}

    private IEnumerator TimerCollider()
    {
        yield return new WaitForSeconds(timeCollider);
        coneAttack.enabled = false;
        yield return new WaitForSeconds(delayAttack - timeCollider);
        cooldownPunch = true;
    }

    private IEnumerator TimeShot()
    {
        int i;
        for(i = 0; i < nbMunitionByShot; i++)
        {
            var shot = Instantiate(playerController.shotPrefab, playerController.posShot.position, Quaternion.identity);
            shot.GetComponent<Shot>().SetDirection(transform.forward);
            yield return new WaitForSeconds(delayBetweenShot);
        }
        yield return new WaitForSeconds(delayShot - (i * delayBetweenShot));
        cooldownShot = true;
    }
}
