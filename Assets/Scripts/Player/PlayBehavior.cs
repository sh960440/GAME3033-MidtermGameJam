using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayBehavior : MonoBehaviour
{
    [SerializeField] private float movespeed = 3.0f;
    public float rotateSpeed = 2.0f;
    private Animator animator;
    private Rigidbody rigidbody;
    private Vector2 mouseValue;
    private bool isRotating;
    private bool isMoveing;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isRotating)
        {
            transform.Rotate(rotateSpeed * new Vector3(0, mouseValue.x, 0));
        }
        
        if (isMoveing)
        {
            rigidbody.velocity = transform.forward * movespeed;;
        }
        else
        {
            rigidbody.velocity = Vector3.zero;
        }

    }

    private void OnMove()
    {
        isMoveing = true;
    }
    private void OnStopMoving()
    {
        isMoveing = false;
    }
    private void OnRotate()
    {
        isRotating = true;
    }
    private void OnStopRotating()
    {
        isRotating = false;
    }

    private void OnAttack()
    {
        Debug.Log("Attack!");
    }

    void OnRotateCamera(InputValue value)
    {
        mouseValue = value.Get<Vector2>();
        mouseValue.Normalize();
    }
}
