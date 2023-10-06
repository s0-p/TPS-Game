using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [Header("타겟 트랜스폼"), SerializeField]
    Transform _targetTrsf;
    //----------------------------------------
    [Header("이동 속도"), SerializeField]
    float _speed = 5f;
    [Header("타겟으로부터 높이"), SerializeField]
    float _heightOffset = 10f;
    //-----------------------------------------------------------------
    void LateUpdate()
    {
        transform.position = _targetTrsf.position + Vector3.up * _heightOffset;
        transform.LookAt(_targetTrsf);
    }
}
