using UnityEngine;

public class AsteroidMini : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;

    private float _timeToDestroyTemp;
    private Vector2 target;

    private void Start()
    {
        RandomTarget();
        _timeToDestroyTemp = _timeToDestroy;
    }

    private void Update()
    {
        GameOverBehaviour();
        MoveAsteroid();      
    }

    private void FixedUpdate()
    {
        DestroyAstroid();
    }

    private void MoveAsteroid()
    {
        transform.Translate(target * _speed * Time.deltaTime);
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);
    }

    private void DestroyAstroid()
    {
        _timeToDestroyTemp -= Time.fixedDeltaTime;
        if (_timeToDestroyTemp <= 0)
        {
            Destroy(gameObject);
            _timeToDestroyTemp = _timeToDestroy;
        }
    }

    private void GameOverBehaviour()
    {
        if (Time.timeScale == 0)
            Destroy(gameObject);
    }

    private void RandomTarget()
    {
        if (transform.position.y > 0 && transform.position.x < 0)
        {
            target = new Vector3(Random.Range(0, 8f), Random.Range(-11f, -6f));
        }

        if (transform.position.y > 0 && transform.position.x > 0)
        {
            target = new Vector3(Random.Range(0, -8f), Random.Range(-11f, -6f));
        }

        if (transform.position.y < 0 && transform.position.x < 0)
        {
            target = new Vector3(Random.Range(0, 8f), Random.Range(11f, 6f));
        }

        if (transform.position.y < 0 && transform.position.x > 0)
        {
            target = new Vector3(Random.Range(0, -8f), Random.Range(11f, 6f));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Lazer"))
        {
            Destroy(gameObject);
        }
    }
}
