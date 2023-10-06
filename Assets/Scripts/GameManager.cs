using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("시간 슬라이더"), SerializeField]
    Slider _sliderTime;
    [Header("제한 시간"), SerializeField]
    float _limitTime = 30f;

    void Awake()
    {
        _sliderTime.maxValue = _limitTime;
    }
}
