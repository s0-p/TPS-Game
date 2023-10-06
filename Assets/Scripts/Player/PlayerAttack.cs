using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("�Ϲ� ���� ��Ÿ��"), SerializeField]
    float _nomalAttackCool = 1f;
    //----------------------------------------
    [Header("���� ���� ��ġ"), SerializeField]
    Transform _weaponSpawnTrsf;
    [Header("�Ϲ� ���� ������"), SerializeField]
    GameObject _nomalWeaponPref;
    //-----------------------------------------------------------------
    void Start()
    {
        StartCoroutine(Crt_AutoNomalAttack());
    }

    IEnumerator Crt_AutoNomalAttack()
    {
        while (true)
        {
            Instantiate(_nomalWeaponPref, _weaponSpawnTrsf.position, _weaponSpawnTrsf.rotation);
            yield return new WaitForSeconds(_nomalAttackCool);
        }
    }
    //-----------------------------------------------------------------
    public void StopAttack()
    {
        StopAllCoroutines();
    }
}
