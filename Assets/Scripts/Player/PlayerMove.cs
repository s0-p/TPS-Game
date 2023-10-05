using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("�̵� �ӵ�"), SerializeField]
    float _moveSpeed = 5f;
    [Header("ȸ�� �ӵ�"), SerializeField]
    float _rotSpeed = 10f;
    [Header("�̵� ��Ʈ�ѷ�"), SerializeField]
    InputCtrlBase _inputCtrl;
    Transform _characterTrsf;

    void Awake()
    {
        _characterTrsf = GetComponentInChildren<Transform>();
    }
    void Update()
    {
        if (_inputCtrl == null) return;

        Vector3 moveDir = new Vector3(_inputCtrl.InputDir.x, 0f, _inputCtrl.InputDir.y);

        if (moveDir != Vector3.zero)
        {
            _characterTrsf.SetPositionAndRotation(
                    _characterTrsf.position + Time.deltaTime * _moveSpeed * moveDir,
                    Quaternion.Lerp(_characterTrsf.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * _rotSpeed)
                );
        }
    }
}
