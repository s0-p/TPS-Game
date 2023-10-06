using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager _instance;
    public static GameManager Instance => _instance;
    //----------------------------------------
    public bool IsEnd { get; set; }
    //----------------------------------------
    [Header("제한 시간"), SerializeField]
    float _limitTime = 30f;
    [Header("시간 슬라이더"), SerializeField]
    Slider _sliderTime;
    //----------------------------------------
    [Header("결과 패널"), SerializeField]
    GameObject _panelResult;
    Text _textResult;
    //-----------------------------------------------------------------
    void Awake()
    {
        IsEnd = false;
        _instance = this;
        _sliderTime.maxValue = _limitTime;
        _textResult = _panelResult.GetComponentInChildren<Text>();
        _panelResult.SetActive(false);
    }
    void Update()
    {
        if (!IsEnd)
        {
            if (_limitTime <= 0f)
            {
                IsEnd = true;
                _panelResult.SetActive(true);
                _textResult.text = "Success!!";
            }
            _limitTime -= Time.deltaTime;
            _sliderTime.value = _limitTime;
        }
        else if(_limitTime > 0)
        {
            _panelResult.SetActive(true);
            _textResult.text = "Fail...";
        }
    }

}
