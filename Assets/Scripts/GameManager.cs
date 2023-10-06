using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�ð� �����̴�"), SerializeField]
    Slider _sliderTime;
    [Header("���� �ð�"), SerializeField]
    float _limitTime = 30f;

    void Awake()
    {
        _sliderTime.maxValue = _limitTime;
    }
}
