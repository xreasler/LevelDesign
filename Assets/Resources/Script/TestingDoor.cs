using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingDoor : MonoBehaviour
{
    
    public float RotationSpeed = 5;
    float smooth = 5.0f;
    float inverted;
    void Start()
    {
        inverted -= Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.Rotate(0, inverted, 0, Space.World);
        }
        
        
    }
}
