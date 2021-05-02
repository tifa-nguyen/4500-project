using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private float seconds;
    private float ms;
    public static int count = 0;
    public static bool isGameWin = false;
    // Final player time variable here
    private bool quitGame = false;

    // Start is called before the first frame update
    void Start()
    {
        clockText.text = "Time: " + seconds.ToString() + "." + ms.ToString();
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
            winText.text = "Stage Complete!" +
                "\nTime taken: " + seconds.ToString() + "." + ms.ToString() + " seconds";
            menuButton.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
        }
    }

    void clock()
    {
        timeCount = 0;
        timer += Time.deltaTime;
        seconds = (int)timer % 60f;
        ms = ((int)(timer * 1000f)) % 1000;
        clockText.text = "Time: " + seconds.ToString() + "." + ms.ToString() + " seconds";
    }

    public void OnMenuButtonPress()
    {
        SceneManager.LoadScene("Menu");  // Play the game
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("Game");  // Play the game
    }

    public void OnExitButtonPress()
    {
        quitGame = true;
        Application.Quit();  // Exit the game
    }
}
