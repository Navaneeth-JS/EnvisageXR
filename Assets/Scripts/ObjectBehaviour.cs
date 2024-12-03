using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectBehaviour : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    GameManager _gameManager;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void SpawnObject()
    {
        Instantiate(prefab, new Vector3(Random.Range(-8,8), 6f, 0f), Quaternion.identity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && _gameManager._gameOver == false)
        {
            SpawnObject();
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Ground")
        {
            _gameManager._gameOver = true;
            Debug.Log("GAME OVER! You lose");
        }

    }
}
