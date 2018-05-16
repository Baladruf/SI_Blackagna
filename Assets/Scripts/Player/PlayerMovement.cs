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

    public bool isStun {get; private set;}

    void Awake() {
        isStun = false;
    }

    void FixedUpdate() {
        if (!GameManager.gameStarted) {
            return;
        }
        MovementUpdate();
        AimUpdate();
        OutOfBoundsUpdate();
    }

    void MovementUpdate() {
        if (isStun) {
            return;
        }

        var cadavre = GameManager.Instance.Cadavre;
        if (!ReferenceEquals(cadavre.cadavreWithPlayer, playerController))
            playerController.rb.MovePosition(transform.position + new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")) * moveSpeed * Time.deltaTime);
        else
            cadavre.rigidbodyCadavre.MovePosition(transform.position + new Vector3(playerController.player.GetAxis("MoveHorizontal"), 0, playerController.player.GetAxis("MoveVertical")) * moveSpeed * Time.deltaTime);
    }

    void AimUpdate() {
        if (Mathf.Abs(playerController.player.GetAxis("AimHorizontal")) < aimDeadZone && Mathf.Abs(playerController.player.GetAxis("AimVertical")) < aimDeadZone) { 
            return; 
        } 
        Vector3 lookDirection = new Vector3(playerController.player.GetAxis("AimHorizontal"), 0, playerController.player.GetAxis("AimVertical")).normalized;
        if (lookDirection != Vector3.zero) {
            var cadavre = GameManager.Instance.Cadavre;
            if (!ReferenceEquals(cadavre.cadavreWithPlayer, playerController))
                playerController.SetPlayerForward(lookDirection);
            else
                cadavre.transform.GetChild(0).forward = lookDirection;
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
