using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator _animator;
    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void Run(bool isMove) { _animator.SetBool("isMove", isMove); }
    public void Hitted() { _animator.SetTrigger("isHitted"); }
    public void Dead() { _animator.SetTrigger("isDead"); }
}
