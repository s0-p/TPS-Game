using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [Header("바닥 트랜스폼"), SerializeField]
    Transform _groundTrsf;
    float _radius;
    [Header("아이템 생성 간격"), SerializeField]
    float _interval = 3f;
    //----------------------------------------
    [Header("아이템 프리팹"), SerializeField]
    GameObject[] _itemPrefs;
    //-----------------------------------------------------------------
    void Awake() { _radius = _groundTrsf.localScale.x * 0.5f; }
    private void Start() { StartCoroutine(Crt_StartSpawn()); }
    IEnumerator Crt_StartSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(_interval);
        }
    }
    void Spawn()
    {
        Vector3 randomPos = transform.position + (Random.insideUnitSphere * _radius);
        int itemIdx = Random.Range(0, _itemPrefs.Length);
        
        var item = Instantiate(_itemPrefs[itemIdx]);
        randomPos.y = item.transform.position.y;
        item.transform.position = randomPos;
    }
}
