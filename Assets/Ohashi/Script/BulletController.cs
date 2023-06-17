using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField, Tooltip("�e�̑���")]
    private float _movePower = 3f;

    [SerializeField, Tooltip("���ˉ�")]
    private int _maxCollisionCount = 5;

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
        _collisionCount++;
    }
}
