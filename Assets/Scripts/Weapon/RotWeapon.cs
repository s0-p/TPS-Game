using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotWeapon : MonoBehaviour
{
    [Header("���ݷ�"), SerializeField]
    float _attackPow = 5f;
    [Header("�˹� ��"), SerializeField]
    float _knockPow = 7f;
    //----------------------------------------
    [Header("ȸ�� �ӵ�"), SerializeField]
    float _rotSpeed = 300f;
    Vector3 _rot = Vector3.zero;
    //-----------------------------------------------------------------
    void Update()
    {
        _rot.y += Time.deltaTime * _rotSpeed;
        transform.rotation = Quaternion.Euler(_rot);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInParent<EnemyHP>().TakeDamage(_attackPow, _knockPow);
        }
    }
}
