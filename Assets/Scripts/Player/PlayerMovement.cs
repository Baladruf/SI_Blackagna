using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerMovement : MonoBehaviour {

    [System.NonSerialized] 
    public PlayerAbstrait playerController; 
    public float moveSpeed; 
    [Range(0, 1)]
    public float aimDeadZone = 0.4f;
    [SerializeField] float bonusSpeed = 0.5f;

    public bool isStun {get; private set;}

    void Awake() {
        isStun = false;
    }

    void FixedUpdate() {
        if (!GameManager.gameStarted || playerController.isDead || !playerController.isActif) {
            return;
        }
        AimUpdate();
        MovementUpdate();
        OutOfBoundsUpdate();
    }

    void MovementUpdate() {
        if (isStun) {
            return;
        }

        if(playerController.isHumain && ((Cadavre)playerController).cadavreWithPlayer == null)
        {
            return;
        }

        //print();
        if (!playerController.isHumain)
        {
            playerController.animator.SetFloat("move", Mathf.Max(Mathf.Abs(playerController.player.GetAxis("MoveHorizontal")), Mathf.Abs(playerController.player.GetAxis("MoveVertical"))));
        }
        else
        {
            float speedAnime = Mathf.Max(Mathf.Abs(playerController.player.GetAxis("MoveHorizontal")), Mathf.Abs(playerController.player.GetAxis("MoveVertical")));
            playerController.animator.SetFloat("Speed", speedAnime <= 0.01f ? 0 : 1);
        }
        playerController.rb.MovePosition(transform.position + new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")) * (moveSpeed + (bonusSpeed * playerController.rankBonus)) * Time.deltaTime);

    }

    void AimUpdate() {

        if (isStun)
        {
            return;
        }

        if (playerController.isHumain)
        {
            if (((Cadavre)playerController).cadavreWithPlayer == null)
            {
                return;
            }

            if (Mathf.Abs(playerController.player.GetAxis("AimHorizontal")) < aimDeadZone && Mathf.Abs(playerController.player.GetAxis("AimVertical")) < aimDeadZone)
            {
                return;
            }
            Vector3 lookDirection = new Vector3(playerController.player.GetAxis("AimHorizontal"), 0, playerController.player.GetAxis("AimVertical")).normalized;
            if (lookDirection != Vector3.zero)
            {
                playerController.SetPlayerForward(lookDirection);
            }
        }
        else
        {
            if (Mathf.Abs(playerController.player.GetAxis("MoveHorizontal")) < aimDeadZone && Mathf.Abs(playerController.player.GetAxis("MoveVertical")) < aimDeadZone)
            {
                return;
            }
            Vector3 lookDirection = -new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")).normalized;
            if (lookDirection != Vector3.zero)
            {
                playerController.SetPlayerForward(lookDirection);
            }
        }

    }

    void OutOfBoundsUpdate() {
        if (transform.position.y < -10) {
            transform.position = playerController.spawnPosition;
            playerController.rb.velocity = Vector3.zero;
        }
    }

    public void Stun() {
        isStun = true;
    }

    public void LeftStun()
    {
        isStun = false;
    }
}
