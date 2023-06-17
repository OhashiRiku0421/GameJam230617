using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// 日本語対応
public class Retry : MonoBehaviour
{
    [SerializeField] private KeyCode _key = KeyCode.R;
    private Text _message = null;

    private void Start()
    {
        _message = GetComponent<Text>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(_key))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        _message.text = $"Press {_key} -> Try Again";
    }
}
