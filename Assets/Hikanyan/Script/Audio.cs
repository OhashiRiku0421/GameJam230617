using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Audio : MonoBehaviour
{
    [SerializeField]Button _audio;
    [SerializeField]  AudioClip _audioClip;
    [SerializeField] AudioManager _audioManager;
    private void Start()
    {
        _audio.onClick.AddListener(() =>
        {
            _audioManager.PlayMusic(_audioClip);
        });
    }
}
