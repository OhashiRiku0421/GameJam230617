using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] AudioManager _audioManager;
    
    [SerializeField] GameObject _player1Win = null;
    [SerializeField] GameObject _player2Win = null;

    [SerializeField] private AudioClip _winAudioClip;
    // Enumの値を監視するReactiveProperty
    static ReactiveProperty<PlayerController.PlayerType> _currentPlayer = 
        new ReactiveProperty<PlayerController.PlayerType>(PlayerController.PlayerType.None);

    private bool isStop;
    public IReadOnlyReactiveProperty<PlayerController.PlayerType> CurrentPlayer => _currentPlayer;

    private void Awake()
    {
        _currentPlayer = new ReactiveProperty<PlayerController.PlayerType>();
        _currentPlayer.Value = PlayerController.PlayerType.None;
    }

    private void Start()
    {
        // Enumの値が変更されたらコンソールに出力するサンプル
        _currentPlayer.Subscribe(player =>
        {
            if(isStop)return;
            switch (player)
            {
                case PlayerController.PlayerType.Player1:
                    _player2Win.SetActive(true);
                    _audioManager.PlaySoundEffect(_winAudioClip);
                    isStop = true;
                    break;
                case PlayerController.PlayerType.Player2:
                    _player1Win.SetActive(true);
                    _audioManager.PlaySoundEffect(_winAudioClip);
                    isStop = true;
                    break;
                default: break;
            }
            Debug.Log($"Victory is player name : {player}");
        });
    }

    // Enumの値を変更するメソッド
    static public void ChangeCurrentPlayer(PlayerController.PlayerType player)
    {
        _currentPlayer.Value = player;
    }
    
    public async UniTask LoadSceneAsync(string sceneName)
    {
        // シーンの非同期読み込み
        await SceneManager.LoadSceneAsync(sceneName);
    }

    private void OnDestroy()
    {
        _currentPlayer.Dispose();
    }
}