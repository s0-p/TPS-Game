using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("일반 공격 쿨타임"), SerializeField]
    float _nomalAttackCool = 1f;
    //----------------------------------------
    [Header("무기 스폰 위치"), SerializeField]
    Transform _weaponSpawnTrsf;
    [Header("일반 무기 프리팹"), SerializeField]
    GameObject _nomalWeaponPref;
    //-----------------------------------------------------------------
    void Start()
    {
        StartCoroutine(Crt_AutoNomalAttack());
    }

    IEnumerator Crt_AutoNomalAttack()
    {
        while (true)
        {
            Instantiate(_nomalWeaponPref, _weaponSpawnTrsf.position, _weaponSpawnTrsf.rotation);
            yield return new WaitForSeconds(_nomalAttackCool);
        }
    }
    //-----------------------------------------------------------------
    public void StopAttack()
    {
        StopAllCoroutines();
    }
}
