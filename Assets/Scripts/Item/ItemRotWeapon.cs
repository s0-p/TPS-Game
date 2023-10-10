using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotWeapon : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerAttack attckCtrl = other.GetComponentInParent<PlayerAttack>();
            GameObject rotWeapon = attckCtrl.RotWeapon;
            RotWeapon rotWeaponCtrl = rotWeapon.GetComponent<RotWeapon>();

            if (!rotWeapon.activeSelf)
                rotWeapon.SetActive(true);
            else
                rotWeaponCtrl.Upgrade();
            Destroy(gameObject);
        }
    }
}
