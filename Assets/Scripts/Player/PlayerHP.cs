using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    bool _isDead = false;
    public bool IsDead => _isDead;
    //----------------------------------------
    [Header("최대 체력"), SerializeField]
    float _maxHP = 100f;
    float _curHP;

    public float CurHP => _curHP;
    //----------------------------------------
    [Header("체력 슬라이더"), SerializeField]
    Slider _sliderHP;
    //----------------------------------------
    PlayerMove _moveCtrl;
    PlayerAttack _attackCtrl;
    //-----------------------------------------------------------------
    void Awake()
    {
        _isDead = false;
        _curHP = _sliderHP.maxValue = _maxHP;
        _moveCtrl = GetComponent<PlayerMove>();
        _attackCtrl = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        if (_isDead) return;
    }
    //-----------------------------------------------------------------
    public void TakeDamage(float damage)
    {
        _curHP = _curHP - damage < 0 ? 0 : _curHP - damage;
        _sliderHP.value = _curHP;

        if (_curHP <= 0f && !_isDead)
            OnDead();
    }
    //-----------------------------------------------------------------
    void OnDead()
    {
        _isDead = true;
        _moveCtrl.enabled = false;
        _attackCtrl.StopAttack();
    }
}
