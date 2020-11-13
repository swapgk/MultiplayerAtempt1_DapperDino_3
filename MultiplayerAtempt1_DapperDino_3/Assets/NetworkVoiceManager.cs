using Photon.Pun;
using Photon.Voice.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.PUN;

[RequireComponent(typeof(VoiceConnection))]
//[RequireComponent(typeof(PhotonVoiceNetwork))]

public class NetworkVoiceManager : MonoBehaviour
{
    public Transform remoteVoiceParent;

    private VoiceConnection voiceConnection;
    

    void Awake()
    {
        voiceConnection = GetComponent<VoiceConnection>();
    }


    private void OnEnable()
    {
        voiceConnection.SpeakerLinked += this.OnSpeakerCreated;
    }

    private void OnDisable()
    {
        voiceConnection.SpeakerLinked -= this.OnSpeakerCreated;
    }

    private void OnSpeakerCreated(Speaker speaker)
    {
        speaker.transform.SetParent(this.remoteVoiceParent);
        speaker.OnRemoteVoiceRemoveAction += OnRemoteVoiceRemove;
    }

    private void OnRemoteVoiceRemove(Speaker speaker)
    {
        if(speaker != null)
        {
            Destroy(speaker.gameObject);
        }
    }
}