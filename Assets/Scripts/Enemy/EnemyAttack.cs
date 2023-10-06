using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("공격력"), SerializeField]
    float _power = 5f;
    [Header("공격 쿨타임"), SerializeField]
    float _coolTime = 1f;
    float _coolTimer = 0f;
    //----------------------------------------
    bool _isPlayerInRange = false;
    //----------------------------------------
    PlayerHP _playerHP;
    //-----------------------------------------------------------------
    void Awake() { _coolTimer = 0f; _isPlayerInRange = false; }
    void Update()
    {
        _coolTimer += Time.deltaTime;
        if (_isPlayerInRange && _coolTimer >= _coolTime)
        {
            _coolTimer = 0f;
            _playerHP.TakeDamage(_power);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            _playerHP = other.GetComponentInParent<PlayerHP>();
        }
    }
    void OnTriggerExit(Collider other) { _isPlayerInRange = false; _playerHP = null; }

}
