using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("�Ϲ� ���� ��Ÿ��"), SerializeField]
    float _nomalAttackCool = 1f;
    float _nomalAttackTimer = 0f;
    //----------------------------------------
    [Header("��ź ��Ÿ��"), SerializeField]
    float _bombCool = 3f;
    float _bombTimer = 0f;
    //----------------------------------------
    [Header("���� ���� ��ġ"), SerializeField]
    Transform _weaponSpawnTrsf;
    [Header("�Ϲ� ���� ������"), SerializeField]
    GameObject _nomalWeaponPref;
    [Header("��ź ������"), SerializeField]
    GameObject _bombWeaponPref;
    [Header("ȸ�� ����"), SerializeField]
    GameObject _rotWeapon;
    public GameObject BombPref => _bombWeaponPref;
    public GameObject RotWeapon => _rotWeapon;
    //----------------------------------------
    GameObject _target;
    Vector3 _dirToTarget;
    //-----------------------------------------------------------------
    void Update()
    {
        _nomalAttackTimer += Time.deltaTime;
        _bombTimer += Time.deltaTime;
        if (_bombTimer >= _bombCool)
        {
            _bombTimer = 0f;
            Instantiate(_bombWeaponPref, _weaponSpawnTrsf.position, _weaponSpawnTrsf.rotation);
        }
        if (_target != null && _nomalAttackTimer >= _nomalAttackCool)
        {
            _nomalAttackTimer = 0f;
            Instantiate(_nomalWeaponPref, _weaponSpawnTrsf.position, Quaternion.LookRotation(_dirToTarget));
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            if (!other.GetComponent<EnemyHP>().IsDead)
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
    }
    void OnTriggerExit(Collider other) { _target = null; }
}
