using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float range;

    public GameObject canvas;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RayShoot();
        }  
        UIOnLook();
    }

    public void RayShoot()
    {
        RaycastHit hit;

        Vector3 crossHairPoint = new Vector3(Screen.width / 2f - 30f, Screen.height / 2f + 30f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(crossHairPoint);


        if (Physics.Raycast(ray, out hit, range))
        {


            IPushInteract currenTarget = hit.collider.gameObject.GetComponent<IPushInteract>();
            if (currenTarget != null)
            {
                currenTarget.Interact();

            }
        }
    }

    public void UIOnLook()
    {
        RaycastHit hit;

        Vector3 crossHairPoint = new Vector3(Screen.width / 2f - 30f, Screen.height / 2f + 30f, 0f);
        Ray ray = Camera.main.ScreenPointToRay(crossHairPoint);


        if (Physics.Raycast(ray, out hit, range))
        {


            IOnLookInteract Uitarget = hit.collider.gameObject.GetComponent<IOnLookInteract>();
            if (Uitarget != null)
            {
                Uitarget.OnLooking();
                Debug.Log("SENDING IONLOOK");

            }
            else canvas.SetActive(false);
        } 
    }
}
