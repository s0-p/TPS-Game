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
    public float CurHP 
    { 
        get { return _curHP; }
        set
        {
            _curHP = value;
            if (_curHP > _maxHP) _curHP = _maxHP;
        }
    }
    //----------------------------------------
    [Header("체력 슬라이더"), SerializeField]
    Slider _sliderHP;
    //----------------------------------------
    PlayerMove _moveCtrl;
    PlayerAttack _attackCtrl;
    PlayerAnim _animCtrl;
    //-----------------------------------------------------------------
    void Awake()
    {
        _isDead = false;
        _curHP = _sliderHP.maxValue = _maxHP;
        _moveCtrl = GetComponent<PlayerMove>();
        _attackCtrl = GetComponent<PlayerAttack>();
        _animCtrl = GetComponent<PlayerAnim>();
    }
    //-----------------------------------------------------------------
    public void TakeDamage(float damage)
    {
        _curHP = _curHP - damage < 0 ? 0 : _curHP - damage;
        _sliderHP.value = _curHP;

        if (_curHP <= 0f && !_isDead)
            OnDead();
        else
            _animCtrl.Hitted();
    }
    public void Recover(float amount)
    {
        _curHP = _curHP + amount > _maxHP ? _maxHP : _curHP + amount;
        _sliderHP.value = _curHP;
    }
    //-----------------------------------------------------------------
    void OnDead()
    {
        _isDead = true;
        _moveCtrl.enabled = false;
        _attackCtrl.RotWeapon.SetActive(false);
        _attackCtrl.enabled = false;
        GameManager.Instance.IsEnd = true;
        _animCtrl.Dead();
    }
}
