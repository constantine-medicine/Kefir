using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;

    private float _timeToDestroyTemp;

    private void Start()
    {
        _timeToDestroyTemp = _timeToDestroy;
    }

    void Update()
    {
        SpawnObject();
    }

    private void FixedUpdate()
    {
        DestroyBullet();
    }

    private void SpawnObject()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        _timeToDestroyTemp -= Time.fixedDeltaTime;
        if (_timeToDestroyTemp <= 0)
        {
            Destroy(gameObject);
            _timeToDestroyTemp = _timeToDestroy;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip") || collision.CompareTag("AsteroidMini") || collision.CompareTag("Asteroid"))
        {         
            Destroy(gameObject);
        }
    }
}
