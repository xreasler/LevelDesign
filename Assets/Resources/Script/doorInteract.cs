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


    public void Start()
    {
        isObjectHeld = false;
        tryPickupObject = false;
        objectHeld = null;
    }

    public void Update()
    {

        if(Input.GetKey(KeyCode.B))
        {
            if(!isObjectHeld){
                TryPickObject();
                tryPickupObject = true;
            } else 
            {
                Debug.Log("ATTEMPTING HOLD");
                HoldObject();
            }
        }else if(isObjectHeld){
            DropObject();
        }
        
    }

    public void TryPickObject()
    {
        RaycastHit hit;

        Vector3 crossHairPoint = new Vector3(Screen.width / 2f - 30f, Screen.height / 2f + 30f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(crossHairPoint);
        
        


        if (Physics.Raycast(ray, out hit, range))
        {
            Debug.Log("CASTING RAY");
            objectHeld = hit.collider.gameObject;
            if (tryPickupObject == true)
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
}
