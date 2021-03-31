using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject firstCheckpoint;
    public GameObject secondCheckpoint;
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count == 3)
        {
            Destroy(firstCheckpoint);
        }
        else if (count == 6)
        {
            Destroy(secondCheckpoint);
        }
    }
}
