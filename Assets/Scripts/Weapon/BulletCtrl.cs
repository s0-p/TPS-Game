using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [Header("���ݷ�"), SerializeField]
    float _attackPow = 10f;
    [Header("�˹� ��"), SerializeField]
    float _knockPow = 10f;
    [Header("�ӵ�"), SerializeField]
    float _speed = 100f;
    //----------------------------------------
    Rigidbody _rigidbody;
    //-----------------------------------------------------------------
    void Awake() { _rigidbody = GetComponent<Rigidbody>(); }
    void Start() 
    { 
        _rigidbody.AddForce(transform.forward * _speed);
        Destroy(gameObject, 3f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyHP>().TakeDamage(_attackPow, _knockPow);
        }
        Destroy(gameObject);
    }
}
