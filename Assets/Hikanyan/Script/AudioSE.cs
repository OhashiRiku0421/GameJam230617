using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioSE : MonoBehaviour
{
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _audioClip1;
    [SerializeField] private AudioClip _audioClip2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _audioManager.PlaySoundEffect(_audioClip1);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            _audioManager.PlaySoundEffect(_audioClip2);
        }

    } 
}
