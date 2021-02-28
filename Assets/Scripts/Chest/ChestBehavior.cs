using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestBehavior : MonoBehaviour
{
    public ColorType[] answer;
    public int level = 1;
    public bool isOpened = false;
     
    
    // Start is called before the first frame update
    void Start()
    {
        answer = new ColorType[level];

        if (level == 1)
        {
            answer[0] = (ColorType)Random.Range(0, 3);
        }
        else if (level == 2)
        {
            answer[0] = (ColorType)Random.Range(0, 6);
            do{
                answer[1] = (ColorType)Random.Range(0, 6);
            } while (answer[0] == answer[1]);
        }
        else
        {
            answer[0] = (ColorType)Random.Range(0, 6);
            do{
                answer[1] = (ColorType)Random.Range(0, 6);
            } while (answer[0] == answer[1]);
            do{
                answer[2] = (ColorType)Random.Range(0, 6);
            } while (answer[0] == answer[2] || answer[1] == answer[2]);
        }

        foreach(ColorType c in answer)
        {
            Debug.Log(level + ", " + c);
        }
    }
}
