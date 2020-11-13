using Photon.Pun;
using UnityEngine;

namespace PhotonTutorial
{
    public class PlayerSpawner : MonoBehaviour
    {
    
        [SerializeField] private GameObject playerPrefab = null;
        private Vector3 position= new Vector3(0,10,0);
        // void Update() {
        //     Vector3 position = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), ,
        //                                  UnityEngine.Random.Range(-10.0f, 10.0f));

        // }
        private void Start() => PhotonNetwork.Instantiate(playerPrefab.name, position, Quaternion.identity);
    }

}