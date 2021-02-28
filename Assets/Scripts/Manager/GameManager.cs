using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] spiderStartPoints;
    public Transform[] spiderSpawnPoints;
    public GameObject[] auraPrefabs;
    public GameObject[] gemPrefabs;
    public Sprite[] slotSprites;
    public Image[] mixingSlots;
    public Image[] collectedSlots;
    public ColorType[] mixingObjs;
    public ColorType[] collectedObj;
    public int openedNumber = 0;

    [SerializeField] private GameObject spiderPrefab;
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

    public void SpawnGem(Vector3 target, ColorType color)
    {
        Vector3 spawnPosition = new Vector3(target.x, target.y + 1.0f, target.z);
        Instantiate(gemPrefabs[(int)color], spawnPosition, new Quaternion(1.0f, 0.0f, 0.0f, 1.0f));
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


    public void PickupGem(ColorType color)
    {
        if(mixingObjs[0] == ColorType.WHITE)
        {
            mixingObjs[0] = color;
            mixingSlots[0].sprite = slotSprites[(int)color];
        }
        else
        {
            if (mixingObjs[1] == ColorType.WHITE)
            {
                mixingObjs[1] = color;
                mixingSlots[1].sprite = slotSprites[(int)color];
            }
        }
    }

    public void Mix()
    {
        if (mixingObjs[0] == ColorType.WHITE || mixingObjs[1] == ColorType.WHITE) return;
        if (collectedObj[0] != ColorType.WHITE && collectedObj[1] != ColorType.WHITE && collectedObj[2] != ColorType.WHITE && collectedObj[3] != ColorType.WHITE) return;

        ColorType result = ColorType.WHITE;
        switch(mixingObjs[0], mixingObjs[1])
        {
            case (ColorType.RED, ColorType.RED):
                result = ColorType.RED;
                break;
            case (ColorType.GREEN, ColorType.GREEN):
                result = ColorType.GREEN;
                break;
            case (ColorType.BLUE, ColorType.BLUE):
                result = ColorType.BLUE;
                break;

            case (ColorType.RED, ColorType.BLUE):
                result = ColorType.PURPLE;
                break;
            case (ColorType.BLUE, ColorType.RED):
                result = ColorType.PURPLE;
                break;

            case (ColorType.RED, ColorType.GREEN):
                result = ColorType.YELLOW;
                break;
            case (ColorType.GREEN, ColorType.RED):
                result = ColorType.YELLOW;
                break;

            case (ColorType.GREEN, ColorType.BLUE):
                result = ColorType.ORANGE;
                break;
            case (ColorType.BLUE, ColorType.GREEN):
                result = ColorType.ORANGE;
                break;
        }

        if (collectedObj[0] == ColorType.WHITE)
        {
            collectedObj[0] = result;
            collectedSlots[0].sprite = slotSprites[(int)result];
        }
        else if (collectedObj[1] == ColorType.WHITE)
        {
            collectedObj[1] = result;
            collectedSlots[1].sprite = slotSprites[(int)result];
        }
        else if (collectedObj[2] == ColorType.WHITE)
        {
            collectedObj[2] = result;
            collectedSlots[2].sprite = slotSprites[(int)result];
        }
        else
        {
            collectedObj[3] = result;
            collectedSlots[3].sprite = slotSprites[(int)result];
        }

        mixingObjs[0] = ColorType.WHITE;
        mixingSlots[0].sprite = slotSprites[(int)ColorType.WHITE];
        mixingObjs[1] = ColorType.WHITE;
        mixingSlots[1].sprite = slotSprites[(int)ColorType.WHITE];
    }

    public void UseCollectedGems()
    {
        for(int i = 0; i < 4; i++)
        {
            collectedObj[i] = ColorType.WHITE;
            collectedSlots[i].sprite = slotSprites[(int)ColorType.WHITE];
        }
    }

    public bool IsCollectionEmpty()
    {
        for (int i = 0; i < collectedObj.Length; i++)
        {
            if (collectedObj[i] != ColorType.WHITE)
            {
                return false;
            }
        }
        return true;
    }

    public void Resume()
    {
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }

    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("GameScene");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
