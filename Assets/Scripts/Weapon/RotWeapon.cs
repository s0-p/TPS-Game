using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotWeapon : MonoBehaviour
{
    [Header("공격력"), SerializeField]
    float _attackPow = 5f;
    [Header("넉백 힘"), SerializeField]
    float _knockPow = 7f;
    //----------------------------------------
    [Header("회전 속도"), SerializeField]
    float _rotSpeed = 300f;
    Vector3 _rot = Vector3.zero;
    //----------------------------------------
    [Header("최대 업그레이드 단계"), SerializeField]
    int _maxUpgrade = 10;
    int _curUpgrade = 0;
    //-----------------------------------------------------------------
    void Update()
    {
        _rot.y += Time.deltaTime * _rotSpeed;
        transform.rotation = Quaternion.Euler(_rot);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            other.gameObject.GetComponentInParent<EnemyHP>().TakeDamage(_attackPow, _knockPow);
        }
    }
    public void Upgrade()
    {
        if (_curUpgrade < _maxUpgrade)
            transform.localScale *= 1.3f;
    }
}
