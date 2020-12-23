﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject RB;
    public Transform target; 

    public Vector3 offset = new Vector3(0, 0, -10);

    // Start is called before the first frame update
    void Start()
    {
        target = RB.transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.TransformPoint(offset);
        transform.LookAt(target);
    }
}