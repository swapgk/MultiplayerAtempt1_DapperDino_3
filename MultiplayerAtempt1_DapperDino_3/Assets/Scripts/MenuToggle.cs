using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using PhotonTutorial.Menus;

namespace PhotonTutorial.abc
{

    public class MenuToggle : MonoBehaviour
    {
        [SerializeField] public GameObject menu; // Assign in inspector
        //[SerializeField] private Canvas CanvasObject; // Assign in inspector
        //[SerializeField] private GameObject playerPrefab = null;  //my player

        private bool isShowing=false;
        void Start () 
        {
            // Cursor.visible = true; 
            // Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 1;

        }
        void Update() {
            if (Input.GetKeyDown("escape")) {
                isShowing = !isShowing;
                menu.SetActive(isShowing);
                if(isShowing==true){
                    Cursor.visible = true;
                }
                else {
                    Cursor.visible = false;
                }
            }

            // if (Input.GetKeyUp(KeyCode.Escape)) 
            //  {
            //      CanvasObject.enabled = !isShowing;
            //      isShowing = !isShowing;
            //      if(isShowing==true){
            //          Cursor.visible = true;
            //      }
            //      else {
            //          Cursor.visible = false;
            //      }
            //  } 
        
            
        }
        public void MyDisconnect()
        {
            Debug.Log("inside GoToMainmenu function");
            PhotonNetwork.Disconnect();
            // changeit();
            GoToMainMenu();
        }
        public void GoToMainMenu()
        {
            SceneManager.LoadScene("Menu"); 
        }

    
    }

}