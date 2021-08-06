using UnityEngine;
using UnityEngine.UI;

public class UIInfo : MonoBehaviour
{
    [SerializeField] private Text _coordinates;
    [SerializeField] private Text _angle;
    [SerializeField] private Text _speed;
    [SerializeField] private Text _countLazerAmmo;
    [SerializeField] private Text _timeToReloadLazer;
    [SerializeField] private ShipBehaviour _playerShip;
    [SerializeField] private LazerGun _lazerGun;

    private void Update()
    {
        PrintInfo();
    }

    private void PrintInfo()
    {
        _coordinates.text = $"Координаты: {_playerShip.GetCoordinates()}";
        _angle.text = $"Угол поворота: {_playerShip.GetAngle()}";
        _speed.text = $"Скорость корабля: {_playerShip.Speed}";
        _countLazerAmmo.text = $"Число зарядов лазера: {_lazerGun.CountAmmo}";
        _timeToReloadLazer.text = $"Время до выстрела: {_lazerGun.TimeToReload}";
    }
}
