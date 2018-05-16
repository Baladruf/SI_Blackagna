using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    [System.NonSerialized]
    public PlayerController playerController;
    private ColliderCone colliderCone;
    [SerializeField] float delayAttack = 0.5f;
    [SerializeField] float delayShot = 1.5f;
    [SerializeField] int nbMunitionByShot = 5;
    [SerializeField] float delayBetweenShot = 0.2f;
    private bool cooldownPunch = true;
    private bool cooldownShot = true;
    private Collider coneAttack;
    [SerializeField] float timeCollider = 0.2f;



    private void Awake()
    {
        coneAttack = transform.GetChild(0).GetComponent<Collider>();
        coneAttack.enabled = false;
        (colliderCone = coneAttack.GetComponent<ColliderCone>()).action = this;
    }

    // Update is called once per frame
    void Update () {
        var cadavre = GameManager.Instance.Cadavre;
        if (ReferenceEquals(cadavre.cadavreWithPlayer, playerController))
        {
            if (playerController.player.GetButton("RightTrigger") && cooldownShot)
            {
                cooldownShot = false;
                StartCoroutine(TimeShot(cadavre));
            }
        }
        else
        {
            if (playerController.player.GetButton("RightTrigger") && cooldownPunch)
            {
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

    private IEnumerator TimeShot(Cadavre cadavre)
    {
        int i;
        for(i = 0; i < nbMunitionByShot; i++)
        {
            var shot = Instantiate(cadavre.shotPrefab, cadavre.posShot.position, Quaternion.identity);
            shot.GetComponent<Shot>().SetDirection(cadavre.transform.GetChild(0).forward);
            yield return new WaitForSeconds(delayBetweenShot);
        }
        yield return new WaitForSeconds(delayShot - (i * delayBetweenShot));
        cooldownShot = true;
    }
}
