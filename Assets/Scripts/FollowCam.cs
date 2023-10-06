using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("Ÿ�� Ʈ������"), SerializeField]
    Transform _targetTrsf;
    //----------------------------------------
    [Header("�̵� �ӵ�"), SerializeField]
    float _speed = 5f;
    [Header("Ÿ�����κ��� ����"), SerializeField]
    float _heightOffset = 10f;
    //-----------------------------------------------------------------
    void LateUpdate()
    {
        transform.position = _targetTrsf.position + Vector3.up * _heightOffset;
        transform.LookAt(_targetTrsf);
    }
}
