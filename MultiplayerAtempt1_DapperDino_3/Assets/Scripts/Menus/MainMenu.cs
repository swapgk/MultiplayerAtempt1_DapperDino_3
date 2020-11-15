// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// public class MainMenu : MonoBehaviour
// {
//     public void Playgame() 
//     {
//         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
//     }
//     public void QuitGame()
//     {   
//         Debug.Log("Quit");
//         Application.Quit();
//     }
    
// }
  
using System.Collections;
using System.Collections.Generic;

using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using PhotonTutorial.abc;

//using PhotonTutorial.Menus;

namespace PhotonTutorial.Menus
{
    public class MainMenu : MonoBehaviourPunCallbacks
    {
        [SerializeField] private GameObject findOpponentPanel = null;
        [SerializeField] private GameObject waitingStatusPanel = null;
        [SerializeField] private TextMeshProUGUI waitingStatusText = null;

        private bool isConnecting = false;
        public bool Idisconnected=false;

        //private string room = "VRMeetup1";
         private string room;
        // private void LateUpdate() {
        //     room= RoomNameInput.roomName;

        // }
        

         private bool m_createdRoom = false; 
        private const string GameVersion = "0.1";
        private const int MaxPlayersPerRoom = 3;
        private const int MinPlayerPerRoom = 1;


        private void Awake() => PhotonNetwork.AutomaticallySyncScene = true;

        void Start(){
            Cursor.visible = true; 
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;


        }

        public void changeit(){
             Idisconnected=true;

        }
        public void FindOpponent()
        {
            isConnecting = true;

             findOpponentPanel.SetActive(false);
             waitingStatusPanel.SetActive(true);

            waitingStatusText.text = "Searching...";

            
            if (PhotonNetwork.IsConnected)
            {
                OnConnectedToMaster();
            }
            else
            {
                PhotonNetwork.GameVersion = GameVersion;
                PhotonNetwork.ConnectUsingSettings();
            }
        }

        public void doquit(){
            Application.Quit();
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("the room name is" + room);

            Debug.Log("Connected to master!");
            Debug.Log("Joining room...");

        ////////////////////////////////////////////cheap
            // findOpponentPanel.SetActive(false);
            // waitingStatusPanel.SetActive(false);
            //PhotonNetwork.JoinRandomRoom();
            room = RoomNameInput.roomName;
            PhotonNetwork.JoinRoom(room);
        
        }

        // Original OnConnectedToMaster
        // public override void OnConnectedToMaster()
        // {
        //     Debug.Log("Connected To Master");

        //     if (isConnecting)
        //     {
        //         PhotonNetwork.JoinRandomRoom();
        //     }
        // }

        public override void OnDisconnected(DisconnectCause cause)
        {
            
            // waitingStatusPanel.SetActive(false);
            // findOpponentPanel.SetActive(true);
            Debug.Log($"Disconnected due to: {cause}");
            
        }

        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("No clients are waiting for an opponent, creating a new room");

            PhotonNetwork.CreateRoom(room, new RoomOptions { MaxPlayers = MaxPlayersPerRoom });
        }
         public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.LogWarning("Room join failed " + message);
            m_createdRoom = true;
            Debug.Log("Creating room...");
            PhotonNetwork.CreateRoom(room, new RoomOptions { MaxPlayers = 8, IsOpen = true, IsVisible = true }, TypedLobby.Default);
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("Client successfully joined a room: "+ room);

            int playerCount = PhotonNetwork.CurrentRoom.PlayerCount;

            if(playerCount < MinPlayerPerRoom)
            {
                waitingStatusText.text = "Waiting For Players";
                Debug.Log("Client is waiting for a Player");
            }
            else
            {
               // waitingStatusText.text = "Player Found";
                Debug.Log("Ready to create room");
                PhotonNetwork.LoadLevel("Game");
            }
        }

        public override void OnPlayerEnteredRoom(Player newPlayer)
        {
            if(PhotonNetwork.CurrentRoom.PlayerCount == MaxPlayersPerRoom)
            {
                PhotonNetwork.CurrentRoom.IsOpen  = false;
                
                waitingStatusText.text = "Player Found";
                Debug.Log("Match is ready to begin");

             
            }
            
        }
        public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        base.OnRoomListUpdate(roomList);
        Debug.Log("Got " + roomList.Count + " rooms.");
        foreach(RoomInfo room in roomList)
        {
            Debug.Log("Room: " + room.Name + ", " + room.PlayerCount);
        }
    }
    }
}