using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _playerTransform;
    
    private void Start()
    {
        _playerTransform = FindObjectOfType<ShipBehaviour>().GetComponent<Transform>();
    }

    void Update()
    {
        MoveShip();
        GameOverBehaviour();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Lazer"))
        {
            Destroy(gameObject);
        }
    }

    private void MoveShip()
    {
        transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speed * Time.deltaTime);
    }

    private void GameOverBehaviour()
    {
        if (Time.timeScale == 0)
            Destroy(gameObject);
    }
}
