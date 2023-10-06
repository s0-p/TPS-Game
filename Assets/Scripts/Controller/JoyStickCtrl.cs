using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyStickCtrl : InputCtrlBase, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    RectTransform _rectTrsf;
    //----------------------------------------
    [Header("레버 트랜스폼"), SerializeField]
    RectTransform _leverRectTrsf;
    [Header("레버 범위"), SerializeField, Range(30, 100)]
    float _leverRange = 50f;
    Vector2 _firstTouch;
    //-----------------------------------------------------------------
    void Awake()
    {
        _rectTrsf = GetComponent<RectTransform>();
    }
    //-----------------------------------------------------------------
    public void OnBeginDrag(PointerEventData eventData)
    {
        _firstTouch = eventData.position;

        var leverDir = eventData.position - _rectTrsf.anchoredPosition;
        var clampeDir = leverDir.magnitude < _leverRange ? leverDir : leverDir.normalized * _leverRange;

        _leverRectTrsf.anchoredPosition = clampeDir;
        InputDir = _leverRectTrsf.anchoredPosition / _leverRange;
    }

    public void OnDrag(PointerEventData eventData)
    {
        var leverDir = eventData.position - _firstTouch;
        var clampeDir = leverDir.magnitude < _leverRange ? leverDir : leverDir.normalized * _leverRange;

        _leverRectTrsf.anchoredPosition = clampeDir;
        InputDir = _leverRectTrsf.anchoredPosition / _leverRange;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _leverRectTrsf.anchoredPosition = InputDir = Vector2.zero;
    }
}
