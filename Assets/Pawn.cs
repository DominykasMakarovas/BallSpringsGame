using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Cursor = UnityEngine.Cursor;

public class Pawn : MonoBehaviour
{
    [SerializeField] private int velocity;
    [SerializeField] private GameObject indicatorPosition;
    [SerializeField] private GameObject indicator;

    private Rigidbody rb;
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private GameObject arrow;

    private void Start()
    {
        Cursor.visible = true;
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
        arrow = Instantiate(indicator, gameObject.transform);
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

    private void Update()
    {
        var startPos = new Vector3(mousePressDownPos.x, 0, mousePressDownPos.y);
        var endPos = new Vector3(Input.mousePosition.x, 0, Input.mousePosition.y);
        var dir = (startPos - endPos).normalized;
        var toRotation = Quaternion.LookRotation(dir, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 1000f * Time.deltaTime);
    }
}
