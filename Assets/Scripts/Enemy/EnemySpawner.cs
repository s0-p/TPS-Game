using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("���� �ּ� �ð�"), SerializeField]
    float _spawnMinTime = 3f;
    [Header("���� �ִ� �ð�"), SerializeField]
    float _spawnMaxTime = 5f;
    float _spawnTime;
    //----------------------------------------
    [Header("�� �� ���� �ð�����"), SerializeField]
    float _IncreaseInterval = 10;
    [Header("�� �� ������"), SerializeField]
    int _IncreaseCnt = 2;
    int _spawnCnt = 1;
    //----------------------------------------
    [Header("���� ��ġ"), SerializeField]
    Transform[] _spawnTransfs;
    //----------------------------------------
    [Header("�� ������"), SerializeField]
    GameObject[] _enemyPrefs;
    //-----------------------------------------------------------------
    void Awake() { _spawnTime = 0f; _spawnCnt = 1; }
    void Start() 
    { 
        StartCoroutine(Crt_StartSpawn());
        StartCoroutine(Crt_IncreaseSpawnCnt());
    }
    void Update() { if (GameManager.Instance.IsEnd) StopAllCoroutines(); }
    //-----------------------------------------------------------------
    IEnumerator Crt_StartSpawn()
    {
        while (true)
        {
            for (int i = 0; i < _spawnCnt; i++)
                Spawn();

            yield return new WaitForSeconds(_spawnTime);
        }
    }
    IEnumerator Crt_IncreaseSpawnCnt()
    {
        while (true)
        {
            yield return new WaitForSeconds(_IncreaseInterval);
            _spawnCnt += _IncreaseCnt;
        }
    }
    void Spawn()
    {
        _spawnTime = Random.Range(_spawnMinTime, _spawnMaxTime);
        int spawnPosIdx = Random.Range(0, _spawnTransfs.Length);
        int enemyIdx = Random.Range(0, _enemyPrefs.Length);

        Instantiate(_enemyPrefs[enemyIdx], _spawnTransfs[spawnPosIdx].position, _spawnTransfs[spawnPosIdx].rotation);        
    }
}
