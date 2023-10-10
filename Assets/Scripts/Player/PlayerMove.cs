using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMove : MonoBehaviour
{
    [Header("���� ȸ�� �ӵ�"), SerializeField]
    float _rotSpeed = 10f;
    [Header("���� �̵� �ӵ�"), SerializeField]
    float _moveSpeed = 5f;
    float _upSpeed = 1f;
    public float UpSpeed { get { return _upSpeed; } set { _upSpeed = value; } }
    //----------------------------------------
    PlayerAnim _animCtrl;
    //----------------------------------------
    [Header("�̵� ��Ʈ�ѷ�"), SerializeField]
    InputCtrlBase _inputCtrl;
    Transform _characterTrsf;
    //-----------------------------------------------------------------
    void Awake()
    {
        _upSpeed = 1f;
        _animCtrl = GetComponent<PlayerAnim>();
        _characterTrsf = GetComponentInChildren<Transform>();
    }
    void Update() { Move(); }
    //-----------------------------------------------------------------
    void Move()
    {
        if (_inputCtrl == null) return;

        Vector3 moveDir = new Vector3(_inputCtrl.InputDir.x, 0f, _inputCtrl.InputDir.y);

        if (moveDir != Vector3.zero)
        {
            _animCtrl.Run(true);
            _characterTrsf.SetPositionAndRotation(
                    _characterTrsf.position + Time.deltaTime * _moveSpeed * _upSpeed * moveDir,
                    Quaternion.Lerp(_characterTrsf.rotation, Quaternion.LookRotation(moveDir), Time.deltaTime * _rotSpeed * _upSpeed)
                );
        }
        else
        {
            _animCtrl.Run(false);
        }
    }
}
