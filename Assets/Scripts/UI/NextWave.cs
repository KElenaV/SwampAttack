using UnityEngine;
using UnityEngine.UI;

public class NextWave : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _spawner.AllEnemiesSpawned += OnAllEnemiesSpawned;
        _button.onClick.AddListener(OnNextWaveButtonClick);
    }

    private void OnDisable()
    {
        _spawner.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        _button.onClick.RemoveListener(OnNextWaveButtonClick);
    }

    private void OnNextWaveButtonClick()
    {
        _spawner.NextWave();
        _button.gameObject.SetActive(false);
    }

    private void OnAllEnemiesSpawned()
    {
        _button.gameObject.SetActive(true);
    }
}
