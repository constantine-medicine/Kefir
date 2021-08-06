using UnityEngine;

[RequireComponent(typeof(Transform))]
public class MachineGun : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private float _rateOfFire;
    [SerializeField] private BlankEvent _shootEvent;

    private Transform _gunPostition;
    private float _rateOfFireTemp;
    private bool _reloadComplited = true;

    private void Start()
    {
        _gunPostition = GetComponent<Transform>();
        _rateOfFireTemp = _rateOfFire;
    }

    private void Update()
    {
        _shootEvent.Listeners += FireMachineGun;
    }

    private void FireMachineGun()
    {
        if (_reloadComplited)
        {
            Instantiate(_bullet, _gunPostition.position, _gunPostition.rotation);
            _reloadComplited = false;
        }
        if (!_reloadComplited)
        {
            _rateOfFireTemp -= Time.deltaTime;
            if (_rateOfFireTemp <= 0)
            {
                _rateOfFireTemp = _rateOfFire;
                _reloadComplited = true;
            }
        }
    }
}
