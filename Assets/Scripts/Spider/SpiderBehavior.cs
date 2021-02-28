using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ColorType
{
    RED,
    GREEN,
    BLUE
}

public class SpiderBehavior : MonoBehaviour
{
    public bool canbeAttacked;
    public ColorType type;

    [SerializeField] private GameObject aura;
    private NavMeshAgent agent;
    private bool arrivedStartPoint = false;
    private bool startPatrolling = false;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        type = (ColorType)Random.Range(0, 3);
        aura = Instantiate(GameManager.Instance.auras[(int)type], transform); 

        animator.SetBool("IsMoving", true);
        agent.destination = GameManager.Instance.spiderStartPoints[Random.Range(0, 5)].position;
    }

    // Update is called once per frame
    void Update()
    {
        if (arrivedStartPoint)
        {
            if (!startPatrolling)
            {
                startPatrolling = true;
                StartCoroutine(Patrol());
            }

            if (Vector3.Distance(transform.position, agent.destination) <= 2.0f)
            {
                animator.SetBool("IsMoving", false);
            }
            else
            {
                animator.SetBool("IsMoving", true);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, agent.destination) <= 2.0f)
            {
                animator.SetBool("IsMoving", false);
                arrivedStartPoint = true;
            }
        }
    }

    public void Die()
    {
        animator.SetBool("IsDead", true);
    }

    void FindNextPoint()
    {
        
        Debug.Log(agent.destination);
    }

    IEnumerator Patrol()
    {
        yield return new WaitForSeconds(4.0f);
        agent.destination = new Vector3(transform.position.x + Random.Range(-12.0f, 12.0f), 
                                        transform.position.y, 
                                        transform.position.z + + Random.Range(-12.0f, 12.0f));
        StartCoroutine(Patrol());
    }
}
