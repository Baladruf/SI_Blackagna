using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Screeching : MonoBehaviour
{
	public Player Player;
	public int Id;
	public float Cooldown = 1.0f;
    public ParticleSystem wave;
    [System.NonSerialized]
    public PlayerAbstrait playerController;

    private bool canScreech = true;

	private void Start()
	{
		Player = ReInput.players.GetPlayer(Id);
	}
	void Update()
	{
        if (playerController.isDead || !playerController.isActif)
        {
            return;
        }

        if (canScreech && Player.GetButtonDown("Screech"))
        {
            canScreech = false;
            StartCoroutine(Screech());
        }
    }

	IEnumerator Screech()
	{
		Debug.Log("Screech");
        wave.Play();
        yield return new WaitForSeconds(Cooldown);
		canScreech = true;
	}
}
