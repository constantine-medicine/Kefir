using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnerBox;
    [SerializeField] private EnemyShip _enemyShip;
    [SerializeField] private Asteroid _asteroid;
    [SerializeField] private float _timeToSpawn;

    private float _timeToSpawnTemp;
    private bool _spawnComplited = true;

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (_spawnComplited)
        {
            _spawnComplited = false;
            int boxSpawn = Random.Range(0, _spawnerBox.Length - 1);
            Instantiate(_enemyShip, _spawnerBox[boxSpawn].transform.position, new Quaternion(0, 0, 0, 0));
            Instantiate(_asteroid, _spawnerBox[boxSpawn].transform.position, new Quaternion(0, 0, 0, 0));
        }

        if (!_spawnComplited)
        {
            _timeToSpawnTemp -= Time.fixedDeltaTime;
            if (_timeToSpawnTemp <= 0)
            {
                _spawnComplited = true;
                _timeToSpawnTemp = _timeToSpawn;
            }
        }
    }
}
