using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("스폰 최소 시간"), SerializeField]
    float _spawnMinTime = 3f;
    [Header("스폰 최대 시간"), SerializeField]
    float _spawnMaxTime = 5f;
    float _spawnTime;
    //----------------------------------------
    int _spawnCnt = 1;
    //----------------------------------------
    [Header("스폰 위치"), SerializeField]
    Transform[] _spawnTransfs;
    //----------------------------------------
    [Header("적 프리팹"), SerializeField]
    GameObject[] _enemyPrefs;
    //-----------------------------------------------------------------
    void Awake() { _spawnTime = 0f; _spawnCnt = 1; }
    void Start() { StartCoroutine(Crt_StartSpawn()); }
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
    void Spawn()
    {
        _spawnTime = Random.Range(_spawnMinTime, _spawnMaxTime);
        int spawnPosIdx = Random.Range(0, _spawnTransfs.Length);
        int enemyIdx = Random.Range(0, _enemyPrefs.Length);

        Instantiate(_enemyPrefs[enemyIdx], _spawnTransfs[spawnPosIdx].position, _spawnTransfs[spawnPosIdx].rotation);        
    }
}
