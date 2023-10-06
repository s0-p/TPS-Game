using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    bool _isSinking = false;
    [Header("»ç¸Á ½Ã °¡¶ó¾É´Â ¼Óµµ"), SerializeField]
    float _sinkSpeed = 1f;
    //----------------------------------------
    NavMeshAgent _navMash;
    Rigidbody _rigidbody;
    //----------------------------------------
    Transform _targetTrsf;
    //-----------------------------------------------------------------
    void Awake()
    {
        _isSinking = false;
        _navMash = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _targetTrsf = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (_navMash.enabled)
            _navMash.SetDestination(_targetTrsf.position);
        if (_isSinking)
            transform.Translate(Time.deltaTime * _sinkSpeed * Vector3.down);
    }
    //-----------------------------------------------------------------
    public void KnockBack(Vector3 dir, float power) { _rigidbody.AddForce(dir * power); }
    public void StartSink()
    {
        _isSinking = true;
        _navMash.enabled = false;
        _rigidbody.isKinematic = true;
    }
}
