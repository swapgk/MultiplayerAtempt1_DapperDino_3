using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//using Photon.Voice.Unity.UtilityScripts;

namespace PhotonTutorial.Menus
{
    public class RoomNameInput : MonoBehaviour
    {
        public static string roomName;
        //private ConnectAndJoin CJ=;
        [SerializeField] private InputField roomNameInputField = null;

        [SerializeField] private Button continueButton = null;

        private const string RoomPrefsNameKey = "RoomName";

        private void Start() {
            SetUpInputField();
            
        }

        private void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(RoomPrefsNameKey)) { return; }

            string defaultName1 = PlayerPrefs.GetString(RoomPrefsNameKey);

            roomNameInputField.text = defaultName1;

            Continue_Check(defaultName1);
        }

        
        public void Continue_Check(string roomName)
        {
           continueButton.interactable = !string.IsNullOrEmpty(roomName);
        }
      
        public void SaveRoomName()
        {
            roomName = roomNameInputField.text;

            //PhotonNetwork.NickName = playerName;

            PlayerPrefs.SetString(RoomPrefsNameKey, roomName);
            //ConnectAndJoin CJ= GetComponent<ConnectAndJoin>();
           // CJ.RoomName = roomName;
        }
    }
}
