using UnityEngine;

public class Lazer : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeToDestroy;
    
    private Transform _lazerGun;
    private float _timeToDestroyTemp;

    private void Start()
    {
        _timeToDestroyTemp = _timeToDestroy;
    }

    private void Update()
    {
    }

    private void FixedUpdate()
    {
        DestroyLazer();
    }

    private void DestroyLazer()
    {
        _timeToDestroyTemp -= Time.fixedDeltaTime;
        if (_timeToDestroyTemp <= 0)
        {
            Destroy(gameObject);
            _timeToDestroyTemp = _timeToDestroy;
        }
    }
}
