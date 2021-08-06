using UnityEngine;

public class ShipBehaviour : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _downRestartPosition;
    [SerializeField] private Transform _topRestartPosition;
    [SerializeField] private BlankEvent _collisionOnEnemyShip;
    [SerializeField] private BlankEvent _collisionOnAsteroid;
    [SerializeField] private BlankEvent _shootOnLazerGun;
    [SerializeField] private BlankEvent _shootOnMachineGun;
    
    private InputKeyboard _inputKeyboard;
    private int _directionMove = 0;
    private float _speedTemp;

    public float Speed { get => _speedTemp; }

    private void Start()
    {
        _speedTemp = _speed;
        _inputKeyboard = GetComponent<InputKeyboard>();
    }

    void Update()
    {
        Move();
        Rotation();
        ShootOnMachineGun();
        ShootOnLazerGun();
    }

    private void Rotation()
    {
        if (Input.GetKey(_inputKeyboard.RightRotate))
        {
            transform.Rotate(new Vector3(0, 0, -1) * _speedRotation * Time.deltaTime);
        }
        if (Input.GetKey(_inputKeyboard.LeftRotate))
        {
            transform.Rotate(new Vector3(0, 0, 1) * _speedRotation * Time.deltaTime);
        }
    }

    private void ShootOnMachineGun()
    {
        if (Input.GetKey(_inputKeyboard.ShootOnMachineGun))
            _shootOnMachineGun.Raise();
    }

    private void ShootOnLazerGun()
    {
        if (Input.GetKeyDown(_inputKeyboard.ShootOnLazerGun))
            _shootOnLazerGun.Raise();
    }

    private void Move()
    {
        MoveUp();
        MoveDown();
        MoveUpMomentum();
        MoveDownMomentum();
    }

    private void MoveUp()
    {
        if (Input.GetKey(_inputKeyboard.Up))
        {
            _directionMove = 1;
            _speedTemp = _speed;
            Vector2 target = new Vector2(transform.position.x, transform.position.y + 0.1f);
            transform.position = Vector2.MoveTowards(transform.position, target, _speedTemp);
        }
    }

    private void MoveDown()
    {
        if (Input.GetKey(_inputKeyboard.Down))
        {
            _directionMove = 2;
            _speedTemp = _speed;
            Vector2 target = new Vector2(transform.position.x, transform.position.y - 0.1f);
            transform.position = Vector2.MoveTowards(transform.position, target, _speed);
        }

    }

    private void MoveUpMomentum()
    {
        if (_directionMove == 1 && !Input.GetKey(_inputKeyboard.Up) && !Input.GetKey(_inputKeyboard.Down))
        {
            Vector2 target = new Vector2(transform.position.x, transform.position.y + 0.1f);
            transform.position = Vector2.MoveTowards(transform.position, target, _speedTemp);
            _speedTemp -= Time.deltaTime * 0.005f;
            if (_speedTemp <= 0)
            {
                _speedTemp = 0;
                _directionMove = 0;
            }
        }
    }

    private void MoveDownMomentum()
    {
        if (_directionMove == 2 && !Input.GetKey(_inputKeyboard.Up) && !Input.GetKey(_inputKeyboard.Down))
        {
            Vector2 target = new Vector2(transform.position.x, transform.position.y - 0.1f);
            transform.position = Vector2.MoveTowards(transform.position, target, _speedTemp);
            _speedTemp -= Time.deltaTime * 0.005f;
            if (_speedTemp <= 0)
            {
                _speedTemp = 0;
                _directionMove = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip"))
        {
            _collisionOnEnemyShip.Raise();
        }

        if (collision.CompareTag("Asteroid") || collision.CompareTag("AsteroidMini"))
        {
            _collisionOnAsteroid.Raise();
        }
    }

    public float GetAngle()
    {
        return transform.eulerAngles.z;
    }

    public string GetCoordinates()
    {
        return $"({transform.position.x}, {transform.position.y})";
    }
}
