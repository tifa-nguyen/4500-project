using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

namespace Duoshooter
{
    public class ConnectionController : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields
        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 2;
        #endregion

        #region Private Fields
        string gameVersion = "1";
        bool isConnecting;
        private Dictionary<int, GameObject> playerListEntries;
        #endregion

        #region Public Fields
        public GameObject controlPanel;
        public GameObject progressLabel;
        public GameObject playerListEntryPrefab;
        #endregion

        #region MonoBehaviour CallBacks
        void Awake()
        {
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        // Start is called before the first frame update
        void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        #endregion

        #region Public Methods
        // Update is called once per frame
        void Update()
        {

        }

        public void Connect()
        {
            isConnecting = true;
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);

            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = this.gameVersion;
            }

            /*isConnecting = PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;*/
        }

        public void OnMenuButtonPress()
        {
            SceneManager.LoadScene("Menu");  // Load the menu
        }
        #endregion

        #region MonoBehaviourPunCallbacks Callbacks
        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            Debug.Log("Connected to the " + PhotonNetwork.CloudRegion + " server");
            if (isConnecting)
            {
                //PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = maxPlayersPerRoom });
                PhotonNetwork.JoinRandomRoom();
                isConnecting = false;
            }
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
            PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = this.maxPlayersPerRoom });
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom called by PUN. Now this client is in a room.");
            if (playerListEntries == null)
            {
                playerListEntries = new Dictionary<int, GameObject>();
            }
            foreach (Player p in PhotonNetwork.PlayerList)
            {
                GameObject entry = Instantiate(playerListEntryPrefab);
                entry.GetComponent<PlayerListEntry>().Initialize(p.ActorNumber, p.NickName);
                playerListEntries.Add(p.ActorNumber, entry);
            }
            PhotonNetwork.LoadLevel(1);
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            GameObject entry = Instantiate(playerListEntryPrefab);
            entry.GetComponent<PlayerListEntry>().Initialize(newPlayer.ActorNumber, newPlayer.NickName);
            playerListEntries.Add(newPlayer.ActorNumber, entry);
        }

        public override void OnPlayerLeftRoom(Player otherPlayer)
        {
            Destroy(playerListEntries[otherPlayer.ActorNumber].gameObject);
            playerListEntries.Remove(otherPlayer.ActorNumber);
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            isConnecting = false;
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reaon {0}", cause);
        }

        public override void OnLeftRoom()
        {
            foreach (GameObject entry in playerListEntries.Values)
            {
                Destroy(entry.gameObject);
            }

            playerListEntries.Clear();
            playerListEntries = null;
        }
        #endregion
    }
}