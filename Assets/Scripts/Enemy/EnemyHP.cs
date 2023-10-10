using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("���� ü��"), SerializeField]
    float _initHP = 30;
    float _curHP;
    public float CurHP => _curHP;
    //----------------------------------------
    public bool IsDead { get; private set; }
    //----------------------------------------
    //MeshRenderer _meshRenderer;
    [Header("�ǰ� ���� �ð�"), SerializeField]
    float _hittedTime = 1f;
    //----------------------------------------
    EnemyMove _moveCtrl;
    EnemyAttack _attackCtrl;
    EnemyAnim _animCtrl;
    //-----------------------------------------------------------------
    void Awake()
    {
        _curHP = _initHP;
        IsDead = false;
        //_meshRenderer = GetComponentInChildren<MeshRenderer>();
        _moveCtrl = GetComponent<EnemyMove>();
        _attackCtrl = GetComponent<EnemyAttack>();
        _animCtrl = GetComponent<EnemyAnim>();
    }
    //-----------------------------------------------------------------
    public void TakeDamage(float damage, float knockPow = 0)
    {
        _curHP = _curHP - damage <= 0 ? 0 : _curHP - damage;

        if (_curHP <= 0f)
            OnDead();
        else
        {
            _attackCtrl.enabled = false;
            _animCtrl.Damaged();
            _moveCtrl.KnockBack(-transform.forward, knockPow);
            StartCoroutine(Crt_ReleseHitState());
        }
    }
    //-----------------------------------------------------------------
    IEnumerator Crt_ReleseHitState()
    {
        yield return new WaitForSeconds(_hittedTime);
        _attackCtrl.enabled = true;
    }
    void OnDead()
    {
        IsDead = true;
        _animCtrl.Die();
        _attackCtrl.enabled = false;
        GetComponentInChildren<BoxCollider>().isTrigger = true;
        StartSinking();
    }
    void StartSinking()
    {
        _moveCtrl.Invoke("StartSink", 1f);
        Destroy(gameObject, 3f);
    }

}
