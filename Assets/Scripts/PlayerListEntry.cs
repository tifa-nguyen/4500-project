using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;

namespace Duoshooter
{
    public class PlayerListEntry : MonoBehaviour
    {
        private string ownerName;
        private int ownerID;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Initialize(int playerID, string playerName)
        {
            ownerID = playerID;
            ownerName = playerName;
        }
    }
}