using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGun : MonoBehaviour
{

    [SerializeField]
    private KeyCode _keyCode;

    [SerializeField]
    private Transform _muzzlePos;

    [SerializeField]
    private GameObject _bullet;

    private void Update()
    {
        if(Input.GetKeyDown(_keyCode))
        {
            Instantiate(_bullet, _muzzlePos.position, transform.rotation);
        }
    }
}
