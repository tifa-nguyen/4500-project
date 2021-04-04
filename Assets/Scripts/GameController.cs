using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject firstCheckpoint;
    public GameObject secondCheckpoint;
    public Text clockText;
    public Text winText;
    public Button menuButton;
    public Button restartButton;
    public Button quitButton;
    public static int timeCount;
    public static float timer = 0.0f;
    private int seconds;
    public static int count = 0;
    public static bool isGameWin = false;

    // Start is called before the first frame update
    void Start()
    {
        clockText.text = "Time: " + timeCount.ToString() + " seconds";
        winText.text = "";
        menuButton.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameWin)
        {
            clock();
        }

        if (count == 3)
        {
            Destroy(firstCheckpoint);
        }
        else if (count == 6)
        {
            Destroy(secondCheckpoint);
        }

        if (isGameWin)
        {
            winText.text = "You win!" +
                "\nTime taken: " + timeCount.ToString() + " seconds";
        }
    }

    void clock()
    {
        timeCount = 0;
        timer += Time.deltaTime;
        seconds = (int)timer % 60;
        timeCount += seconds;
        clockText.text = "Time: " + timeCount.ToString() + " seconds";
    }
}
