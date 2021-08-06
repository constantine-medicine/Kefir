using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BlankEvent _collisionOnEnemyShip;
    [SerializeField] private BlankEvent _collisionOnAsteroid;
    [SerializeField] private GameObject _gameOverImage;

    private void Update()
    {
        _collisionOnEnemyShip.Listeners += Death;
        _collisionOnAsteroid.Listeners += Death;
    }

    private void Death()
    {
        Time.timeScale = 0;
        _gameOverImage.SetActive(true);
    }
}
