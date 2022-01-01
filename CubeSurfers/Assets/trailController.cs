using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailController : MonoBehaviour
{
    private Quaternion defRotate;
    private void Start()
    {
        defRotate = transform.rotation;
    }

    private void FixedUpdate()
    {
        this.transform.rotation = defRotate;
    }
}
