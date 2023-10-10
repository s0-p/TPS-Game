using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    Animator _animator;
    void Awake() { _animator = GetComponentInChildren<Animator>(); }
    public void Run(bool isMove) { _animator.SetBool("isMove", isMove); }
    public void Damaged() { _animator.SetTrigger("isDamaged"); }
    public void Attack() { _animator.SetTrigger("isAttack"); }
    public void Die() { _animator.SetTrigger("isDead"); }
}
