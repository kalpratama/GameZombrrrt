using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    public float recoilAmount = 1f;
    public float recoilSpeed = 6f;
    public float returnSpeed = 25f;

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
    }

    public void ApplyRecoil()
    {
        Vector3 recoilVector = new Vector3(0, 0, -recoilAmount);
        transform.localPosition += recoilVector;
    }

    void Update()
    {
        if (transform.localPosition != originalPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, originalPosition, Time.deltaTime * returnSpeed);
        }
    }
}
