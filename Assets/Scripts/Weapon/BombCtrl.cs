using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombCtrl : MonoBehaviour
{
    [Header("공격력"), SerializeField]
    float _power = 20f;
    [Header("속도"), SerializeField]
    float _speed = 200f;
    [Header("발사 거리"), SerializeField]
    float _dist = 5f;
    [Header("데미지 반경"), SerializeField]
    static float _radius = 2.5f;
    //----------------------------------------
    [Header("최대 업그레이드 단계"), SerializeField]
    static int _maxUpgrade = 5;
    static int _curUpgrade = 1;
    //----------------------------------------
    [Header("적 레이어"), SerializeField]
    LayerMask _layer;
    //----------------------------------------
    [Header("폭발 이펙트 프리팹"), SerializeField]
    GameObject _effectPref;
    static float _effectScale = 1f;
    //----------------------------------------
    Rigidbody _rigidbody;
    //-----------------------------------------------------------------
    void Awake() 
    { 
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.isKinematic = true;

        _curUpgrade = 1;
        _effectScale = 1f;
    }
    void Start()
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce((Vector3.up * 2 + transform.forward) * _speed * _dist);
    }
    void OnCollisionEnter(Collision collision)
    {
        ++_curUpgrade;
        CreateEffect();
        IndirectDamage();
        Destroy(gameObject);
    }
    public static void Upgrade()
    {
        if (_curUpgrade < _maxUpgrade)
        {
            ++_curUpgrade;
            _radius += 0.3f;
            _effectScale *= 1.2f;
        }
    }
    void CreateEffect()
    {
        GameObject effect = Instantiate(_effectPref, transform.position, transform.rotation);
        effect.transform.localScale *= _effectScale;
        Destroy(effect, 2f);
    }
    void IndirectDamage()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius * _curUpgrade, _layer);
        foreach (var coll in colliders)
            coll.GetComponent<EnemyHP>().TakeDamage(_power);
    }
}
