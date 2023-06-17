using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using Cysharp.Threading.Tasks;

public class GameManager : MonoBehaviour
{
    // Enumの値を監視するReactiveProperty
    private ReactiveProperty<PlayerController.PlayerType> _currentPlayer = new ReactiveProperty<PlayerController.PlayerType>(PlayerController.PlayerType.None);

    // カプセル化したプロパティを公開
    public IReadOnlyReactiveProperty<PlayerController.PlayerType> CurrentPlayer => _currentPlayer;

    private void Start()
    {
        // Enumの値が変更されたらコンソールに出力するサンプル
        _currentPlayer.Subscribe(player =>
        {
            Debug.Log($"Victory is player name : {player}");
        });
    }

    // Enumの値を変更するメソッド
    public void ChangeCurrentPlayer(PlayerController.PlayerType player)
    {
        _currentPlayer.Value = player;
    }
}