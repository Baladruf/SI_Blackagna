using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Rewired;

public class PlayerMovement : MonoBehaviour {

    [System.NonSerialized] 
    public PlayerController playerController; 
    public float moveSpeed; 
    [Range(0, 1)]
    public float aimDeadZone = 0.4f;
    [SerializeField] float bonusSpeed = 0.5f;

    public bool isStun {get; private set;}

    void Awake() {
        isStun = false;
    }

    void FixedUpdate() {
        if (!GameManager.gameStarted && !playerController.isDead) {
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

        var cadavre = GameManager.Instance.Cadavre;
        if (!ReferenceEquals(cadavre.cadavreWithPlayer, playerController))
            playerController.rb.MovePosition(transform.position + new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")) * (moveSpeed + (bonusSpeed * playerController.rankBonus)) * Time.deltaTime);
        else
        {
            cadavre.rigidbodyCadavre.MovePosition(cadavre.transform.position + new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")) * (moveSpeed + (bonusSpeed * playerController.rankBonus)) * Time.deltaTime);
            if(transform.localPosition != Vector3.zero)
            {
                transform.localPosition = Vector3.zero;
            }
        }
    }

    void AimUpdate() {
        if (!ReferenceEquals(playerController, GameManager.Instance.Cadavre.cadavreWithPlayer))
        {
            print("la aussi");
            if (Mathf.Abs(playerController.player.GetAxis("MoveHorizontal")) < aimDeadZone && Mathf.Abs(playerController.player.GetAxis("MoveVertical")) < aimDeadZone)
            {
                return;
            }
            Vector3 lookDirection = new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")).normalized;
            if (lookDirection != Vector3.zero)
            {
                playerController.SetPlayerForward(lookDirection);
            }
        }
        else
        {
            /*if (Mathf.Abs(playerController.player.GetAxis("AimHorizontal")) < aimDeadZone && Mathf.Abs(playerController.player.GetAxis("AimVertical")) < aimDeadZone)
            {
                return;
            }*/
            print("active");
            Vector3 lookDirection = new Vector3(playerController.player.GetAxis("AimHorizontal"), 0, playerController.player.GetAxis("AimVertical")).normalized;
            if (lookDirection != Vector3.zero)
            {
                var cadavre = GameManager.Instance.Cadavre;
                cadavre.transform.GetChild(0).forward = lookDirection;
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
}
