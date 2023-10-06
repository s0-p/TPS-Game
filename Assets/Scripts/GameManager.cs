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
    [Header("���� �ð�"), SerializeField]
    float _limitTime = 30f;
    [Header("�ð� �����̴�"), SerializeField]
    Slider _sliderTime;
    //----------------------------------------
    [Header("��� �г�"), SerializeField]
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
