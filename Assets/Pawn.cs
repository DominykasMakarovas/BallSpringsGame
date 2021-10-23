using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int damage;
    [SerializeField] private int velocity;
    [SerializeField] private GameObject indicatorPosition;
    [SerializeField] private GameObject indicator;

    private Rigidbody rb;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private bool isShooting;
    private GameObject arrow;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        arrow = Instantiate(indicator, indicatorPosition.transform.position, Quaternion.identity);
        arrow.transform.parent = gameObject.transform;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        Destroy(arrow);
    }

    public void Shoot(Vector3 force)
    {
        rb.AddForce(new Vector3(force.x, 0, force.y).normalized * velocity);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Enemy"))
        {
           other.gameObject.GetComponent<Enemy>().dealDamage(damage);
        }
    }
}
