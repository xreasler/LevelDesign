using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class PickUpObject : MonoBehaviour,  IPushInteract
{

    public FirstPersonController fPC;
    public PlayerInteract pI;
    
    public float RotationSpeed = 5;
    float smooth = 5.0f;
    private Vector3 originalRotation = new Vector3(0, 0, 0);

    private bool triggeredIn = false;
    private bool movedAndReady = false;
    
    public Transform _objectPos;
    public Vector3 OriginalPosition;

    public Transform targetPos;

    public GameObject canvas;
    public GameObject inspectCanvas;
    void Start()
    {
        OriginalPosition = transform.position; 
        inspectCanvas.SetActive(false);
    }

    
    void Update()
    {
        ReturnControl();
        if (movedAndReady)
        {
           
            transform.Rotate((Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse Y") * RotationSpeed * Time.deltaTime), 0, Space.World);
            
        }
        canvas = GameObject.Find("InteractUI");
    }

    public void Interact()
    {
        triggeredIn = true;
        pI.enabled = false;
        fPC.enabled = false;
        inspectCanvas.SetActive(true);
        Invoke("TurnOffUI", 2);
        
        StartCoroutine(MoveToPosition()); 
        
    }
    
        
           
            
    IEnumerator MoveToPosition()
    {

        float slideTime = 5f; 

        float t = 0;

         



        while (t < slideTime)

        {

            _objectPos.position = Vector3.Lerp(OriginalPosition, targetPos.position, t / slideTime);

            t += Time.deltaTime;

            movedAndReady = true;
            

            yield return null;

        }

    }
    IEnumerator MoveToBack()
    {

        float slideTime = 2f; 

        float t = 0;

         



        while (t < slideTime)

        {

            _objectPos.position = Vector3.Lerp(targetPos.position, OriginalPosition, t / slideTime);

            t += Time.deltaTime;

            yield return null;

        }

    }

    public void TurnOffUI()
    {
        
        
            canvas.SetActive(false);
        
    }
    
    

    public void ReturnControl()
    {
        if (Input.GetKeyDown(KeyCode.Backspace) && triggeredIn == true)
        {
            StartCoroutine(MoveToBack());
            triggeredIn = false;
            pI.enabled = true;
            fPC.enabled = true;
            movedAndReady = false;
            inspectCanvas.SetActive(false);
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

}
