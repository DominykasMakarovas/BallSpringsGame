using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int velocity;

    private Rigidbody rb;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private bool isShooting;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
    }

    public void Shoot(Vector3 force)
    {
        rb.AddForce(new Vector3(force.x, 0, force.y).normalized * velocity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
            // Change to damage enemy rather than 1 hit them. Add enemy HP and subtract from player damage.
            Destroy(other.gameObject);
        }
    }
}
