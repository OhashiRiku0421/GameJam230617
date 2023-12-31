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
    [SerializeField] private KeyCode _shootKey = KeyCode.None;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _interval = 1f;
    [SerializeField] private Transform _muzzle = null;
    [SerializeField] private GameObject _bullet = null;
    [SerializeField] private GameObject _onDestroyEffect = null;
    [SerializeField] AudioClip _se = null;
    [SerializeField] AudioClip _destroySe = null;
    private ParticleSystem _smoke = null;
    private Rigidbody2D _rb2d = null;
    private AudioManager _audio = null;
    private float _timer = 0f;

    private void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _smoke = GetComponentInChildren<ParticleSystem>();
        _audio = GameObject.Find("GameManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        int h = 0;
        int v = 0;

        if (Input.GetKey(_up)) ++v;
        if (Input.GetKey(_left)) --h;
        if (Input.GetKey(_down)) --v;
        if (Input.GetKey(_right)) ++h;

        Vector2 dirOfTravel = new Vector2(h, v).normalized * _speed;

        if (dirOfTravel == Vector2.zero)
        {
            _smoke.Stop();
        }
        else
        {
            transform.up = dirOfTravel;
            _smoke.Play();
        }
        _rb2d.velocity = dirOfTravel;

        _timer += Time.deltaTime;

        if (_timer > _interval && Input.GetKeyDown(_shootKey))
        {
            Instantiate(_bullet, _muzzle.position, transform.rotation);
            if(_se) _audio.PlaySoundEffect(_se);
            _timer = 0f;
        }
    }

    public void Damage()
    {
        GameManager.ChangeCurrentPlayer(_playerType);
        if(_destroySe) _audio.PlaySoundEffect(_destroySe);
        Instantiate(_onDestroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public enum PlayerType
    {
        None,
        Player1,
        Player2,
    }
}
