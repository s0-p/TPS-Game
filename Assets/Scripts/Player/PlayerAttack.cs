using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("일반 공격 쿨타임"), SerializeField]
    float _nomalAttackCool = 1f;
    float _curTime = 0f;
    //----------------------------------------
    [Header("무기 스폰 위치"), SerializeField]
    Transform _weaponSpawnTrsf;
    [Header("일반 무기 프리팹"), SerializeField]
    GameObject _nomalWeaponPref;
    //----------------------------------------
    GameObject _target;
    Vector3 _dirToTarget;
    //-----------------------------------------------------------------
    void Update()
    {
        _curTime += Time.deltaTime;
        if (_target != null && _curTime > _nomalAttackCool)
        {
            _curTime = 0f;
            Instantiate(_nomalWeaponPref, _weaponSpawnTrsf.position, Quaternion.LookRotation(_dirToTarget));
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (_target == null)
            {
                _target = other.gameObject;
                _dirToTarget = other.transform.position - transform.position;
            }
            else
            {
                Vector3 dir = other.transform.position - transform.position;
                if (dir.sqrMagnitude < _dirToTarget.sqrMagnitude)
                {
                    _target = other.gameObject;
                    _dirToTarget = dir;
                }
            }
        }
    }
    void OnTriggerExit(Collider other) { _target = null; }
}
