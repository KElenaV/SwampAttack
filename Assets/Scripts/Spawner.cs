using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _curentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawnedCount;

    public event UnityAction AllEnemiesSpawned;
    public event UnityAction<int, int> EnemyCountChanged;

    private void Start()
    {
        SetWave(_curentWaveNumber);
    }

    private void Update()
    {
        if(_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            SpawnEnemy();
            _spawnedCount++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawnedCount, _currentWave.Count);
        }

        if (_currentWave.Count <= _spawnedCount)
        {
            if(_curentWaveNumber < _waves.Count - 1)
                AllEnemiesSpawned?.Invoke();
            
            _currentWave = null;
        }
    }

    public void NextWave()
    {
        SetWave(++_curentWaveNumber);
        _spawnedCount = 0;
    }

    private void SpawnEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_target);
        enemy.Died += OnEnemyDied;
    }

    private void OnEnemyDied(Enemy enemy)
    {
        enemy.Died -= OnEnemyDied;
        _target.AddMoney(enemy.Reward);
    }

    private void SetWave(int waveNumber)
    {
        _currentWave = _waves[waveNumber];
        EnemyCountChanged?.Invoke(0, 1);
    }
}