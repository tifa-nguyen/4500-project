using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;

namespace Duoshooter
{
    public class GameController : MonoBehaviour
    {
        public GameObject firstCheckpoint;
        public GameObject secondCheckpoint;
        public Text clockText;
        public Text winText;
        public Button restartButton;
        public Button quitButton;
        public static int timeCount;
        public static float timer = 0.0f;
        private float seconds;
        private float ms;
        private float finalTimeScoreSeconds;
        private float finalTimeScoreMiliseconds;
        public static int count = 0;
        public static bool isGameWin = false;
        public static bool quitGame = false;

        // Start is called before the first frame update
        void Start()
        {
            clockText.text = "Time: " + seconds.ToString() + "." + ms.ToString();
            winText.text = "";
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
                finalTimeScoreSeconds = seconds;
                finalTimeScoreMiliseconds = ms;
                winText.text = "Stage Complete!" +
                    "\nTime taken: " + finalTimeScoreSeconds.ToString() + "." + finalTimeScoreMiliseconds.ToString() + " seconds";
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
            quitGame = true;
            PhotonNetwork.LoadLevel(0);  // Leave to menu
        }

        public void OnRestartButtonPress()
        {
            PhotonNetwork.LoadLevel(2);  // Restart the game
        }

    }
}