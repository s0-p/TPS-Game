using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("ÀÏ¹Ý °ø°Ý ÄðÅ¸ÀÓ"), SerializeField]
    float _nomalAttackCool = 1f;
    float _nomalAttackTimer = 0f;
    //----------------------------------------
    [Header("ÆøÅº ÄðÅ¸ÀÓ"), SerializeField]
    float _bombCool = 3f;
    float _bombTimer = 0f;
    //----------------------------------------
    [Header("¹«±â ½ºÆù À§Ä¡"), SerializeField]
    Transform _weaponSpawnTrsf;
    [Header("ÀÏ¹Ý ¹«±â ÇÁ¸®ÆÕ"), SerializeField]
    GameObject _nomalWeaponPref;
    [Header("ÆøÅº ÇÁ¸®ÆÕ"), SerializeField]
    GameObject _bombWeaponPref;
    [Header("È¸Àü ¹«±â"), SerializeField]
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
