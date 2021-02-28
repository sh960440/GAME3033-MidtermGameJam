using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] spiderStartPoints;
    public Transform[] spiderSpawnPoints;

    [SerializeField] private GameObject spiderPrefab;
    [SerializeField] private GameObject gemPrefab;
    [SerializeField] private int spiderAmountMax;

    private bool point1Spawned;

    private static GameManager m_Instance;
    public static GameManager Instance
    {
        get
        {
            if (m_Instance == null){
                if (FindObjectOfType<GameManager>() != null)
                {
                    m_Instance = FindObjectOfType<GameManager>();
                }
                else
                {
                    GameObject gm = new GameObject("GameManager");
                    m_Instance = gm.AddComponent<GameManager>();
                } 
            }
            return m_Instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SpwanSpider();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnGem(Vector3 position, ColorType color)
    {
        // TODO
    }

    public void SpwanSpider()
    {
        if (FindObjectsOfType<SpiderBehavior>().Length <= spiderAmountMax)
        {
            if (point1Spawned)
            {
                Instantiate(spiderPrefab, spiderSpawnPoints[1].position, Quaternion.identity);
                point1Spawned = false;
            }
            else
            {
                Instantiate(spiderPrefab, spiderSpawnPoints[0].position, Quaternion.identity);
                point1Spawned = true;
            }
        } 
        
        StartCoroutine(WaitForNextSpider());
    }

    IEnumerator WaitForNextSpider()
    {
        yield return new WaitForSeconds(5.0f);
        SpwanSpider();
    }
}
