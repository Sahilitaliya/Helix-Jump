using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject Targate;
    private Vector3 OffSet;
    private float Smooth = 0.04f;

    private void Start()
    {
        OffSet = transform.position - Targate.transform.position;
    }
    private void LateUpdate()
    {
        Vector3 NewPos = Vector3.Lerp(transform.position , Targate.gameObject.transform.position + OffSet , Smooth);
        transform.position = NewPos;
    }
}