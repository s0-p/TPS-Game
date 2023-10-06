using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [Header("기초 체력"), SerializeField]
    float _initHP = 30;
    float _curHP;
    public float CurHP => _curHP;
    //----------------------------------------
    MeshRenderer _meshRenderer;
    [Header("피격 유지 시간"), SerializeField]
    float _hittedTime = 1f;
    //----------------------------------------
    EnemyMove _moveCtrl;
    EnemyAttack _attackCtrl;
    //----------------------------------------
    bool _isDamaged;
    bool _isDead;
    public bool IsDead => _isDead;
    //-----------------------------------------------------------------
    void Awake()
    {
        _curHP = _initHP;
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
        _moveCtrl = GetComponent<EnemyMove>();
        _attackCtrl = GetComponent<EnemyAttack>();
    }
    void Update()
    {
        if (_isDamaged)
        {
            _meshRenderer.material.color
                = Color.Lerp(Color.white, Color.red, 0.5f);
            StartCoroutine(Crt_ReleseHitState());
        }
        else
        {
            _meshRenderer.material.color = Color.white;
        }
    }
    //-----------------------------------------------------------------
    public void TakeDamage(float damage, float knockPow)
    {
        _isDamaged = true;
        _curHP = _curHP - damage <= 0 ? 0 : _curHP - damage;

        Debug.Log(_curHP);

        if (_curHP <= 0f)
            OnDead();

        _moveCtrl.KnockBack(-transform.forward, knockPow);
    }
    //-----------------------------------------------------------------
    IEnumerator Crt_ReleseHitState()
    {
        yield return new WaitForSeconds(_hittedTime);
        _isDamaged = false;
    }
    void OnDead()
    {
        _isDead = true;
        GetComponentInChildren<CapsuleCollider>().isTrigger = true;
        StartSinking();
    }
    void StartSinking()
    {
        _moveCtrl.StartSink();
        _attackCtrl.enabled = false;
        Destroy(gameObject, 2f);
    }

}
