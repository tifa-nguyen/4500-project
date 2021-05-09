using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Duoshooter
{
    public class RoomController : MonoBehaviourPunCallbacks, IInRoomCallbacks
    {
        public static RoomController room;

        private void Awake()
        {
            if (RoomController.room == null)
            {
                RoomController.room = this;
            }
            else
            {
                if (RoomController.room != this)
                {
                    Destroy(RoomController.room.gameObject);
                    RoomController.room = this;
                }
            }
            DontDestroyOnLoad(this.gameObject);
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void StartGame()
        {
            if (PhotonNetwork.CountOfPlayers == 1)
            {
                PhotonNetwork.LoadLevel(2);
            }
            if (PhotonNetwork.CountOfPlayers == 2)
            {
                PhotonNetwork.LoadLevel(3);
            }
        }
    }
}