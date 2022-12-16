using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class doorInteract : MonoBehaviour
{

   
    public GameObject _playerRoot;
    public GameObject objectHeld;
    private float distance = 3f;
    private float maxDistanceGrab = 4f;
    public float range;
    
   
    public bool isObjectHeld;
    public bool tryPickupObject;
    private float PickupRange = 3f;
    private float ThrowStrength = 50f;

    public bool freezeRotation;


    public void Start()
    {
        isObjectHeld = false;
        tryPickupObject = false;
        objectHeld = null;
    }

    public void Update()
    {

        if(Input.GetMouseButton(0))
        {
            if(!isObjectHeld){
                TryPickObject();
                tryPickupObject = true;
            } else 
            {
                HoldObject();
            }
        }else if(isObjectHeld){
            DropObject();
        }
        // if(Input.GetMouseButton(1) && isObjectHeld){
        //    Debug.Log("ATTEMTPING THROW");
        //     isObjectHeld = false;
        //     objectHeld.GetComponent<Rigidbody>().useGravity = true;
        //     ThrowObject();
        // }
        
    }

    public void TryPickObject()
    {
        RaycastHit hit;

        Vector3 crossHairPoint = new Vector3(Screen.width / 2f - 30f, Screen.height / 2f + 30f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(crossHairPoint);
        
        


        if (Physics.Raycast(ray, out hit, range))
        {
            
            objectHeld = hit.collider.gameObject;
            if ((hit.collider.tag == "Door") && tryPickupObject == true)
            {
                Debug.Log("DOOR HIT");
                isObjectHeld = true;
                objectHeld.GetComponent<Rigidbody>().useGravity = true;
                objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
                /**/
                PickupRange = 2f;
                ThrowStrength = 10f;
                distance = 2f;
                maxDistanceGrab = 3f;
            }
            if(hit.collider.tag == "InteractItemsTag" && tryPickupObject){
                isObjectHeld = true;
                objectHeld.GetComponent<Rigidbody>().useGravity = true;
                if(freezeRotation)
                {
                    objectHeld.GetComponent<Rigidbody>().freezeRotation = true;
                }
                if(freezeRotation == false)
                {
                    objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
                }

                PickupRange = 3f;
                ThrowStrength = 50f;
                distance = 3f;
                maxDistanceGrab = 5f;
            }

        }
        
    }
    
    public void HoldObject()
    {
        Vector3 crossHairPoint = new Vector3(Screen.width / 2f - 30f, Screen.height / 2f + 30f, 0f);
        Ray playerAim = Camera.main.ScreenPointToRay(crossHairPoint);

        Vector3 nextPos = _playerRoot.transform.position + playerAim.direction * distance;
        Vector3 currPos = objectHeld.transform.position;

        objectHeld.GetComponent<Rigidbody>().velocity = (nextPos - currPos) * 10;

        if (Vector3.Distance(objectHeld.transform.position, _playerRoot.transform.position) > maxDistanceGrab)
        {
            DropObject();
        }
    }

    public void DropObject()
    {
        isObjectHeld = false;
        tryPickupObject = false;
        objectHeld.GetComponent<Rigidbody>().useGravity = true;
        objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
        objectHeld = null;
    }
    private void ThrowObject()
    {
        Debug.Log("AM THROWN");
        objectHeld.GetComponent<Rigidbody>().AddForce(_playerRoot.transform.forward * 60f);
        objectHeld.GetComponent<Rigidbody>().freezeRotation = false;
        objectHeld = null;
    }
}
