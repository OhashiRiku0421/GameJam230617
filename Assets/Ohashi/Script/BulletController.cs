using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField, Tooltip("íeÇÃë¨Ç≥")]
    private float _movePower = 3f;

    [SerializeField, Tooltip("îΩéÀâÒêî")]
    private int _maxCollisionCount = 5;

    [SerializeField]
    private AudioClip _clip;

    private Rigidbody2D _rb;

    private int _collisionCount = 0;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.AddForce(transform.up * _movePower, ForceMode2D.Impulse);
    }

    private void Update()
    {
        if(_collisionCount >= _maxCollisionCount)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            damageable.Damage();
            Destroy(gameObject);
        }
        AudioSource.PlayClipAtPoint(_clip, transform.position, 10);
        _collisionCount++;
    }
}
