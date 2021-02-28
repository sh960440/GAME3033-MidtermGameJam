using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayBehavior : MonoBehaviour
{
    [SerializeField] private float movespeed = 5.0f;
    [SerializeField] private Collider detector;
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
        animator.SetBool("isRunning", true);
    }
    private void OnStopMoving()
    {
        isMoveing = false;
        animator.SetBool("isRunning", false);
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
        SpiderBehavior[] spiders = FindObjectsOfType<SpiderBehavior>();

        foreach (SpiderBehavior spider in spiders)
        {
            if (spider.canbeAttacked)
            {
                spider.Die();
                Destroy(spider.gameObject, 1.0f);
            }
        }

        animator.SetBool("Attack", true);
    }

    void OnRotateCamera(InputValue value)
    {
        mouseValue = value.Get<Vector2>();
        mouseValue.Normalize();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            other.GetComponent<SpiderBehavior>().canbeAttacked = true;
            Debug.Log("Find a spider!");
        }

        if (other.CompareTag("Chest"))
        {
            other.GetComponent<Animator>().SetBool("IsOpen", true);
            Debug.Log("Find a Chest!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            other.GetComponent<SpiderBehavior>().canbeAttacked = false;
        }
    }
}
