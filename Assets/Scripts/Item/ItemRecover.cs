using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecover : MonoBehaviour
{
    [Header("체력 회복량"), SerializeField]
    float _AmoutOfRecover = 10f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInParent<PlayerHP>().Recover(_AmoutOfRecover);
            Destroy(gameObject);
        }
    }
}
