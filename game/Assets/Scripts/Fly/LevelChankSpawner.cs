using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelChankSpawner : MonoBehaviour
{
    [SerializeField] private LevelChank[] _chankPrefabs;

    [SerializeField] private LevelChank _startChank;

    [SerializeField] private LevelChank _bossChank;

    private List<LevelChank> _spawnedChanks = new();

    [SerializeField] private Transform _playerPosition;

    [SerializeField] private GameObject _bossPrefab;

    private int chankCount = 1;

    private Boss boss;

    public static UnityAction<Boss> OnBossSpawned;

    private void Start()
    {
        boss = null;
        _spawnedChanks.Add(_startChank);
    }
    private void Update()
    {
        if (_playerPosition.position.z > _spawnedChanks[_spawnedChanks.Count - 1].StartChankPoint.position.z)
        {
            if(chankCount % 2 == 0 || boss != null)
            {
                SpawnBossChank();
            }
            else
                SpawnChank();
        }

        if (_spawnedChanks.Count > 2)
        {
            Destroy(_spawnedChanks[0].gameObject);
            _spawnedChanks.RemoveAt(0);
        }
    }
    private void SpawnChank()
    {
        LevelChank chank = Instantiate(_chankPrefabs[Random.Range(0, _chankPrefabs.Length)]);
        chank.transform.position = _spawnedChanks[_spawnedChanks.Count - 1].EndChankPoint.position + new Vector3(0, 0, 14);
        _spawnedChanks.Add(chank);

        chankCount++;
    }

    private void SpawnBossChank()
    {
        LevelChank chank = Instantiate(_bossChank);
        chank.transform.position = _spawnedChanks[_spawnedChanks.Count - 1].EndChankPoint.position + new Vector3(0, 0, 14);
        _spawnedChanks.Add(chank);

        chankCount++;

        SpawnBoss();
    }

    private void SpawnBoss()
    {
        if (boss!=null)
            return;

        var b = Instantiate(_bossPrefab, _spawnedChanks[_spawnedChanks.Count - 1].transform.position, Quaternion.Euler(0, 180, 0));
        boss = b.GetComponent<Boss>();
        OnBossSpawned?.Invoke(boss);
    }
}
