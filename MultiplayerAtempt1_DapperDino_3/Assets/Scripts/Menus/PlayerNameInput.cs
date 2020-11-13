using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace PhotonTutorial.Menus
{
    public class PlayerNameInput : MonoBehaviour
    {
        [SerializeField] private InputField nameInputField = null;
        [SerializeField] private Button continueButton = null;

        private const string PlayerPrefsNameKey = "PlayerName";

        private void Start() => SetUpInputField();

        private void SetUpInputField()
        {
            if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)) { return; }

            string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

            nameInputField.text = defaultName;

            SetPlayerName(defaultName);
        }

        public void SetPlayerName(string name)
        {
            continueButton.interactable = !string.IsNullOrEmpty(name);
        }

        public void SavePlayerName()
        {
            string playerName = nameInputField.text;

            PhotonNetwork.NickName = playerName;

            PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
        }
    }
}

// using Photon.Pun;
// using UnityEngine;
// using UnityEngine.UI;

// namespace PhotonTutorial.Menus
// {
//     public class PlayerNameInput : MonoBehaviour
//     {
//         [SerializeField] private InputField nameInputField = null;


//         [SerializeField] private InputField roomNameInputField=null;

//         [SerializeField] private Button continueButton = null;

//         // To remember the name of the player when he leaves 
//         private const string PlayerPrefsNameKey = "PlayerName";
//         public static string roomName=null;

//         private void Start() {
//             SetUpInputField();
            
//         } 

//         private void SetUpInputField()
//         {
//             if (!PlayerPrefs.HasKey(PlayerPrefsNameKey)  ) { return; }
// //|| string.IsNullOrEmpty(roomName)
//             string defaultName = PlayerPrefs.GetString(PlayerPrefsNameKey);

//             nameInputField.text = defaultName;

//             SetPlayerName(defaultName);
//         }

//         //Enable the continue buttion only when there is text in the InputField
//         public void SetPlayerName(string name)
//         {
//             if(  !string.IsNullOrEmpty(name) )
//             {
//                 //if( !string.IsNullOrEmpty(roomName)){
//                     continueButton.interactable = true ;

//                 //}

//             }
            
//         }

//         public void SavePlayerName()
//         {
//             string playerName = nameInputField.text;
//             PhotonNetwork.NickName = playerName;
//             PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
          
//             //string roomName = roomNameInputField.text;

//         }

//     }
// }



  
// using Photon.Pun;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// namespace PhotonTutorial.Menus
// {
//     public class PlayerNameInput : MonoBehaviour
//     {
//         [SerializeField] private InputField nameInputField = null;
//         [SerializeField] private InputField roomNameInputField = null;

//         [SerializeField] private Button continueButton = null;

//         private const string PlayerPrefsNameKey = "PlayerName";
//         private const string RoomPrefsNameKey = "RoomName";

//         public const string roomName = null;

//         private void Start(){
//             SetUpInputField();
//         } 
       
//         private void SetUpInputField()
//         {
//             string defaultName1=null;
//             string defaultName2=null;
//             if (PlayerPrefs.HasKey(PlayerPrefsNameKey)) { 
//                 defaultName1 = PlayerPrefs.GetString(PlayerPrefsNameKey);
//                 nameInputField.text = defaultName1;
//             }

            
//              if (PlayerPrefs.HasKey(RoomPrefsNameKey)) { 
//                 defaultName2 = PlayerPrefs.GetString(RoomPrefsNameKey);
//                 roomNameInputField.text = defaultName2;
//             }

//             SetPlayerName(defaultName1,defaultName2 );

//         }
       
//         public void SetPlayerName(string name, string roomName1)
//         {
//             continueButton.interactable = ( !string.IsNullOrEmpty(name)
//                                          && !string.IsNullOrEmpty(roomName1) ) ;
//         }

//         public void SavePlayerName()
//         {
//             string playerName = nameInputField.text;

//             PhotonNetwork.NickName = playerName;

//             PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
//         }

//          public void SaveRoomName()
//         {
//             string roomName = roomNameInputField.text;
//             PlayerPrefs.SetString(RoomPrefsNameKey, roomName);
         
//         }

//     }
// }


  
// using Photon.Pun;
// using TMPro;
// using UnityEngine;
// using UnityEngine.UI;

// namespace PhotonTutorial.Menus
// {
//     public class PlayerNameInput : MonoBehaviour
//     {
//         [SerializeField] private InputField nameInputField = null;
//         [SerializeField] private InputField roomNameInputField = null;
//         [SerializeField] private Button continueButton = null;

//         private const string PlayerPrefsNameKey = "PlayerName";
//          private const string RoomPrefsNameKey = "RoomName";

//         private void Start() => SetUpInputField();
      
//         private void SetUpInputField()
//         {   
//             string defaultName1=null;
//             string defaultName2=null;
            
//             if (PlayerPrefs.HasKey(PlayerPrefsNameKey)) { 
//                 defaultName1 = PlayerPrefs.GetString(PlayerPrefsNameKey);
//                 nameInputField.text = defaultName1;
//             }

            
//              if (PlayerPrefs.HasKey(RoomPrefsNameKey)) { 
//                 defaultName2 = PlayerPrefs.GetString(RoomPrefsNameKey);
//                 roomNameInputField.text = defaultName2;
//             }

//             Continue_Check(defaultName1,defaultName2);
//         }

//         public void Continue_Check(string name1, string name2)
//         {
//             bool a= !string.IsNullOrEmpty(name1) ;
//             bool b= !string.IsNullOrEmpty(name2) ;

//             if(a &&b ){

//                 continueButton.interactable = true;
//             }
//         }

//         public void SavePlayerName()
//         {
//             string playerName = nameInputField.text;

//             PhotonNetwork.NickName = playerName;

//             PlayerPrefs.SetString(PlayerPrefsNameKey, playerName);
//         }
//     }
// }