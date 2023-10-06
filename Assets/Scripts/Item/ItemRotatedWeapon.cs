using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotatedWeapon : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attckCtrl = other.GetComponentInParent<PlayerAttack>();
            GameObject rotWeapon = attckCtrl.Weapons[(int)WEAPON.ROTATED_WEAPON];
            if (!rotWeapon.activeSelf)
                rotWeapon.SetActive(true);
            else
            {
                rotWeapon.transform.localScale *= 1.2f;
            }
            Destroy(gameObject);
        }
    }
}
