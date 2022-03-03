using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public GameObject RB;
    public Transform target; 

    public Vector3 offset = new Vector3(3, 6, -10);

    // Start is called before the first frame update
    void Start()
    {
        target = RB.transform;
        target.rotation = Quaternion.identity;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.TransformVector(offset);
        transform.LookAt(target);
        
    }
}