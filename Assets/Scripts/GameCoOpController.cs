using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Duoshooter
{
    public class GameCoOpController : MonoBehaviourPunCallbacks
    {
        public GameObject firstCheckpoint;
        public GameObject secondCheckpoint;
        public GameObject thirdCheckpoint;
        public Text clockText;
        public Text winText;
        public Button restartButton;
        public Button quitButton;
        public static float timer = 0.0f;
        private float seconds;
        private float ms;
        private float finalTimeScoreSeconds;
        private float finalTimeScoreMiliseconds;
        public static int count = 0;
        public static bool isBossFight = false;
        public static bool isGameWin = false;
        public static bool quitGame = false;

        // Start is called before the first frame update
        void Start()
        {
            clockText.text = "Time: " + seconds.ToString() + "." + ms.ToString();
            winText.text = "";
            restartButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(false);


            if (PhotonNetwork.IsMasterClient)
            {
                int playerCount = 1;
                foreach (Player p in PhotonNetwork.PlayerList)
                {
                    if (playerCount == 1)
                    {
                        Vector3 position = new Vector3(-8f, 2.5f, 0f);
                        Quaternion rotation = Quaternion.Euler(0f, 0f, 270f);
                        PhotonNetwork.Instantiate("Player1", position, rotation, 0);
                        playerCount++;
                    }
                    else if (playerCount == 2)
                    {
                        Vector3 position = new Vector3(-8f, -2.5f, 0f);
                        Quaternion rotation = Quaternion.Euler(0f, 0f, 270f);
                        PhotonNetwork.Instantiate("Player2", position, rotation, 0);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            if (!isGameWin)
            {
                clock();
            }

            if (count == 2)
            {
                Destroy(firstCheckpoint);
            }
            else if (count == 4)
            {
                Destroy(secondCheckpoint);
            }
            else if (count == 8)
            {
                Destroy(thirdCheckpoint);
                isBossFight = true;
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
            timer += Time.deltaTime;
            seconds = (int)timer % 60f;
            ms = ((int)(timer * 1000f)) % 1000;
            clockText.text = "Time: " + seconds.ToString() + "." + ms.ToString() + " seconds";
        }

        public void OnMenuButtonPress()
        {
            quitGame = true;
            PhotonNetwork.LeaveRoom();
            PhotonNetwork.LoadLevel(0);  // Leave to menu
        }

        public void OnRestartButtonPress()
        {
            PhotonNetwork.LoadLevel(2);  // Restart the game
        }
    }
}