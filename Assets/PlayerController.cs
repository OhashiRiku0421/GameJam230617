using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
// 日本語対応
public class PlayerController : MonoBehaviour, IDamageable
{
    public PlayerType CurrentPlayerType => _playerType;

    [SerializeField] private PlayerType _playerType = PlayerType.None;
    [SerializeField] private KeyCode _up = KeyCode.None;
    [SerializeField] private KeyCode _left = KeyCode.None;
    [SerializeField] private KeyCode _down = KeyCode.None;
    [SerializeField] private KeyCode _right = KeyCode.None;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private KeyCode _shootKey = KeyCode.None;
    [SerializeField] private Transform _muzzle = null;
    [SerializeField] private GameObject _bullet = null;
    private Rigidbody2D _rb2d = null;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        int h = 0;
        int v = 0;

        if (Input.GetKey(_up)) ++v;
        if (Input.GetKey(_left)) --h;
        if (Input.GetKey(_down)) --v;
        if (Input.GetKey(_right)) ++h;

        Vector2 dirOfTravel = 
            new Vector2(h, v).normalized * _speed;

        if (dirOfTravel != Vector2.zero)
        {
            transform.up = dirOfTravel;
        }
        _rb2d.velocity = dirOfTravel;

        if (Input.GetKeyDown(_shootKey))
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
        }
    }

    public void Damage()
    {
        GameManager.ChangeCurrentPlayer(_playerType);
        Destroy(gameObject);
    }

    public enum PlayerType
    {
        None,
        Player1,
        Player2,
    }
}
