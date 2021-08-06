using UnityEngine;

[RequireComponent(typeof(Transform))]
public class LazerGun : MonoBehaviour
{
    [SerializeField] private Lazer _lazer;
    [SerializeField] private float _fireRate;
    [SerializeField] private int _countAmmo;
    [SerializeField] private BlankEvent _shootEvent;

    private Transform _gunPosition;
    private float _fireRateTemp;
    private bool _reloadComplited = true;

    public int CountAmmo { get => _countAmmo; }
    public float TimeToReload { get => _fireRateTemp; }

    private void Start()
    {
        _gunPosition = GetComponent<Transform>();
        _fireRateTemp = _fireRate;
    }

    private void Update()
    {
        _shootEvent.Listeners += FireLazerGun;
        Reload();
    }

    private void FireLazerGun()
    {
        if (_reloadComplited && _countAmmo > 0)
        {
            _countAmmo--;
            Instantiate(_lazer, _gunPosition.position, _gunPosition.rotation);
            _reloadComplited = false;
        }
    }


    private void Reload()
    {
        if (!_reloadComplited)
        {
            _fireRateTemp -= Time.deltaTime;
            if (_fireRateTemp <= 0)
            {
                _fireRateTemp = _fireRate;
                _reloadComplited = true;
            }
        }

    }
}
