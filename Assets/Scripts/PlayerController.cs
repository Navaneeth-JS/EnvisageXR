using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] ObjectBehaviour _objectBehaviour;

    float _playerSpeed = 10f;
    float _inputHorizontal;
    int _score;

    public TextMeshProUGUI ScoreText;
    [SerializeField] GameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
        _objectBehaviour.SpawnObject();
        _score = 0;
        ScoreText.text = "Score: 0";
    }
    
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (_gameManager._gameOver == true)
        {
            ScoreText.text = "GAME OVER - Final Score: " + _score;
        }

        if (collision.gameObject.tag == "Object" && _gameManager._gameOver == false)
        {
            _score += 1;
            ScoreText.text = "Score: " + _score;
        }

    }
    // Update is called once per frame
    void Update()
    {
        _inputHorizontal = Input.GetAxisRaw("Horizontal");
        if (_inputHorizontal != 0)
        {
            _rb.AddForce(new Vector2(_inputHorizontal*_playerSpeed, 0f));
        }
    }
}
