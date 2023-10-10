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
    EnemyAnim _animCtrl;
    //----------------------------------------
    Transform _targetTrsf;
    //-----------------------------------------------------------------
    void Awake()
    {
        _isSinking = false;
        _navMash = GetComponent<NavMeshAgent>();
        _rigidbody = GetComponent<Rigidbody>();
        _animCtrl = GetComponent<EnemyAnim>();
        _targetTrsf = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (_navMash.enabled)
        {
            float sqrDist = (_targetTrsf.position - transform.position).sqrMagnitude;
            if (sqrDist <= _navMash.stoppingDistance * _navMash.stoppingDistance)
                _animCtrl.Run(false);
            else
            {
                _navMash.SetDestination(_targetTrsf.position);
                _animCtrl.Run(true);
            }
        }

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
