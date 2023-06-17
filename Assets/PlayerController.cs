using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// 日本語対応
public class PlayerController : MonoBehaviour, IDamageable
{
    public PlayerType CurrentPlayerType => _playerType;

    [SerializeField] private PlayerType _playerType = PlayerType.None;
    [SerializeField] private float _speed = 1f;
    private Rigidbody2D _rb2d = null;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 dirOfTravel = 
            new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized * _speed;

        if (dirOfTravel != Vector2.zero)
        {
            transform.up = dirOfTravel;
        }
        _rb2d.velocity = dirOfTravel;
    }

    public void Damage()
    {
        
    }

    public enum PlayerType
    {
        None,
        Player1,
        Player2,
    }
}
