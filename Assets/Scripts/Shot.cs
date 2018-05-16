using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField] float speed = 8;
    private Rigidbody rigidbodyShot;

    private void Awake()
    {
        rigidbodyShot = GetComponent<Rigidbody>();
        Destroy(gameObject, 5);
    }

    public void SetDirection(Vector3 forward)
    {
        rigidbodyShot.velocity = forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //tir detruit
        Destroy(gameObject);
    }
}
