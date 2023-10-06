using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    [Header("이동 속도 증가량"), SerializeField]
    float _upValue = 3f;
    [Header("아이템 효과 지속 시간"), SerializeField]
    float _duration = 2f;
    //----------------------------------------
    GameObject _item;
    //-----------------------------------------------------------------
    void Awake() { _item = transform.GetChild(0).gameObject; }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _item.SetActive(false);
            StartCoroutine(Crt_Use(other.GetComponentInParent<PlayerMove>()));
        }
    }
    IEnumerator Crt_Use(PlayerMove moveCtrl)
    {
        if (moveCtrl.UpSpeed < _upValue)
        {
            moveCtrl.UpSpeed = _upValue;
            yield return new WaitForSeconds(_duration);
            moveCtrl.UpSpeed = 1;
        }
        Destroy(gameObject);
    }
}
