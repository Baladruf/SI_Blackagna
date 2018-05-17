using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour {

    [SerializeField] float speed = 8;
    [SerializeField] float tempsDExistance = 5;
    private Rigidbody rigidbodyShot;

    private void Awake()
    {
        rigidbodyShot = GetComponent<Rigidbody>();
        Destroy(gameObject, tempsDExistance);
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
