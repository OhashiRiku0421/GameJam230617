using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSE : MonoBehaviour
{
    [SerializeField] private KeyCode _player1Se = KeyCode.None;
    [SerializeField] private KeyCode _player2Se = KeyCode.None;
    [SerializeField] private AudioManager _audioManager;
    [SerializeField] private AudioClip _audioClip1;
    [SerializeField] private AudioClip _audioClip2;

    void Update()
    {
        if (Input.GetKeyDown(_player1Se))
        {
            _audioManager.PlaySoundEffect(_audioClip1);
        }
        if (Input.GetKeyDown(_player2Se))
        {
            _audioManager.PlaySoundEffect(_audioClip2);
        }

    } 
}
