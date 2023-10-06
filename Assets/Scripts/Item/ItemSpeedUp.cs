using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpeedUp : MonoBehaviour
{
    [Header("�̵� �ӵ� ������"), SerializeField]
    float _upValue = 3f;
    [Header("������ ȿ�� ���� �ð�"), SerializeField]
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
