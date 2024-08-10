using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XPPoint : MonoBehaviour
{
    public int xpAmount = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerExperience>().AddXP(xpAmount);
            Destroy(gameObject);
        }
    }
}