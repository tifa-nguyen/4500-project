using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Duoshooter
{
    public class LobbyController : MonoBehaviour
    {
        public static LobbyController lobby;
        public Text playerStatus;
        public Button startButton;

        private void Awake()
        {
            lobby = this;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            playerStatus.text = ("Players Connected: " + PhotonNetwork.CountOfPlayers + " / 2");
        }

        public void StartGame()
        {
            PhotonNetwork.LoadLevel(2);
        }
    }
}