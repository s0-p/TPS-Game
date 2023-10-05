using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Header("이동 속도"), SerializeField]
    float _moveSpeed = 5f;
    [Header("회전 속도"), SerializeField]
    float _rotSpeed = 10f;
    [Header("이동 컨트롤러"), SerializeField]
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
