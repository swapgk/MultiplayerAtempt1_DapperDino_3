using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using Photon.Pun;
using Photon.Realtime;
using Photon.Voice.Unity;
using Photon.Voice.PUN;


public class Canvas_Ui_Game : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update

    [SerializeField] private GameObject ESCPage = null;
   // [SerializeField] private Button quit = null;
    //[SerializeField]private NetworkVoiceManager nvm;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {   
                //   ESCPage.SetActive(!ESCPage.activeSelf);
                // //Status=!Status;
                //   Debug.Log(" update runing...");

             Debug.Log(" Leaving room...");

            // PhotonNetwork.LeaveRoom();
            // while(PhotonNetwork.InRoom){
            //     Debug.Log(" Leaving room...");
            // }

            // Debug.Log(" Left room");
            // SceneManager.LoadScene("Menu");
            // Debug.Log(" Scene loaded");
            GoBackToMainMenu();

        }
            
    }
    public void GoBackToMainMenu(){

        // Debug.Log(" Leaving room...");

        // PhotonNetwork.LeaveRoom();
        // while(PhotonNetwork.InRoom){
        //     Debug.Log(" Leaving room...");
        // }
        // Debug.Log(" Left room");

        // SceneManager.LoadScene("Menu");
        // Debug.Log(" Scene loaded");

        StartCoroutine(DisconnectandLoad());
        
    }

    IEnumerator DisconnectandLoad(){
        PhotonNetwork.LeaveRoom();
        while(PhotonNetwork.InRoom){
                Debug.Log(" Leaving room...");
            }
        PhotonNetwork.Disconnect();

        while(PhotonNetwork.IsConnected)
            yield return null;
        //SceneManager.LoadScene("Menu");

        Application.Quit();

    }


    
}
