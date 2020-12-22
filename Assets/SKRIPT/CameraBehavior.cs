using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject RB;
    private Transform target; 
    private Vector3 offset = new Vector3(-38f,2f,-10f);

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