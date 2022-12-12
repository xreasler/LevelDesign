using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class doorInteract : MonoBehaviour, IPushInteract
{

    public FirstPersonController FPC;
    public PlayerInteract PI;
    public Rigidbody rb;
    public float thrust = 1f;
    private float invertedAxis;


    
    public void Update()
    {

        invertedAxis -= Input.GetAxis("Mouse X");
        
    }


    public void Interact()
    {

        while (Input.GetMouseButton(0))
        {
            rb.AddRelativeForce(invertedAxis,0,0);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        while (Input.GetMouseButton(0))
        {
            rb.AddRelativeForce(invertedAxis,0,0);
        }
    }
}
