using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRecover : MonoBehaviour
{
    [Header("ü�� ȸ����"), SerializeField]
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
