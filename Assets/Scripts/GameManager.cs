using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Duoshooter
{
    public class GameManager : MonoBehaviourPunCallbacks
    {
        void LoadArena()
        {
            if (!PhotonNetwork.IsMasterClient)
            {
                Debug.LogError("PhotonNetwork : Trying to load a level but we are not the mast Client");
            }
            Debug.LogFormat("PhotonNetwork : Loading Level : Game");
            PhotonNetwork.LoadLevel(2);
        }

        public static GameManager Instance;

        void Start()
        {
            Instance = this;
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene(0);
            }
        }

        public override void OnLeftRoom()
        {
            SceneManager.LoadScene(0);
        }

        public void LeaveRoom()
        {
            PhotonNetwork.LeaveRoom();
        }
    }
}