using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayBehavior : MonoBehaviour
{
    [SerializeField] private float movespeed = 5.0f;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject openButton;
    [SerializeField] private AudioSource spiderDeathSound;
    [SerializeField] private AudioSource pickGemSound;
    [SerializeField] private AudioSource chestSound;
    public float rotateSpeed = 2.0f;
    private Animator animator;
    private Rigidbody rigidbody;
    private Vector2 mouseValue;
    private bool isRotating;
    private bool isMoveing;
    private float attackDelay = 1.0f;
    private float attackTimer = 0.0f;
    private GameObject facingChest;

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

        attackTimer += Time.deltaTime;
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
        if (attackTimer >= attackDelay)
        {
            attackTimer = 0.0f;

            SpiderBehavior[] spiders = FindObjectsOfType<SpiderBehavior>();

            foreach (SpiderBehavior spider in spiders)
            {
                if (spider.canbeAttacked)
                {
                    spider.Die();
                    GameManager.Instance.SpawnGem(spider.gameObject.transform.position, spider.type);
                    spiderDeathSound.Play();
                    Destroy(spider.gameObject, 1.0f);
                }
            }

            GemBehavior[] gems = FindObjectsOfType<GemBehavior>();

            foreach (GemBehavior gem in gems)
            {
                if (gem.pickable)
                {
                    GameManager.Instance.PickupGem(gem.color);
                    pickGemSound.Play();
                    Destroy(gem.gameObject);
                }
            }

            animator.SetBool("Attack", true);
        }  
    }

    void OnRotateCamera(InputValue value)
    {
        mouseValue = value.Get<Vector2>();
        mouseValue.Normalize();
    }

    public void OpenChest()
    {
        openButton.SetActive(false);
        bool matched = false;

        switch (facingChest.GetComponent<ChestBehavior>().level)
        {
            case 1:
                for (int i = 0; i < 4; i++)
                {
                    if (facingChest.GetComponent<ChestBehavior>().answer[0] == GameManager.Instance.collectedObj[i])
                    {
                        matched = true;
                    }
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    if (facingChest.GetComponent<ChestBehavior>().answer[0] == GameManager.Instance.collectedObj[i])
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (facingChest.GetComponent<ChestBehavior>().answer[1] == GameManager.Instance.collectedObj[j])
                            {
                                matched = true;
                            }
                        }
                    }
                }
                break;
            case 3:
                for (int i = 0; i < 4; i++)
                {
                    if (facingChest.GetComponent<ChestBehavior>().answer[0] == GameManager.Instance.collectedObj[i])
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            if (facingChest.GetComponent<ChestBehavior>().answer[1] == GameManager.Instance.collectedObj[j])
                            {
                                for (int k = 0; k < 4; k++)
                                {
                                    if (facingChest.GetComponent<ChestBehavior>().answer[2] == GameManager.Instance.collectedObj[k])
                                    {
                                        matched = true;
                                    }
                                }
                                
                            }
                        }
                    }
                }
                break;
        }

        if (matched)
        {
            chestSound.Play();
            facingChest.GetComponent<ChestBehavior>().isOpened = true;
            facingChest.GetComponent<Animator>().SetBool("IsOpen", true);
            GameManager.Instance.openedNumber++;
            if (GameManager.Instance.openedNumber >= 5)
            {
                StartCoroutine(Win());
            }
        }

        GameManager.Instance.UseCollectedGems(); 
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(1.5f);
        pauseScreen.SetActive(false);
        winScreen.SetActive(true);
        Time.timeScale = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            other.GetComponent<SpiderBehavior>().canbeAttacked = true;
        }

        if (other.CompareTag("Chest"))
        {
            facingChest = other.gameObject;
            if (!GameManager.Instance.IsCollectionEmpty() && !facingChest.GetComponent<ChestBehavior>().isOpened)
            {
                openButton.SetActive(true);
            }
        }

        if (other.CompareTag("Gem"))
        {
            other.GetComponent<GemBehavior>().pickable = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Spider"))
        {
            other.GetComponent<SpiderBehavior>().canbeAttacked = false;
        }

        if (other.CompareTag("Gem"))
        {
            other.GetComponent<GemBehavior>().pickable = false;
        }

        if (other.CompareTag("Chest"))
        {
            facingChest = null;
            openButton.SetActive(false);
        }
    }

    private void OnPause()
    {
        if (Time.timeScale >= 1)
        {
            Time.timeScale = 0;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseScreen.SetActive(false);
        }

    }
}
