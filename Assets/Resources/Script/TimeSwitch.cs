using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSwitch : MonoBehaviour
{

    public GameObject past;
    public GameObject flashCanvas;
    


    public bool _isPast;
    
    
    void Start()
    {
       past.SetActive(false);
       flashCanvas.SetActive(false);
       _isPast = false;
    }

    
    void Update()
    {
          SwitchTimeInput();
          
    }

    public void SwitchTimeInput()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            _isPast = !_isPast;

            // if (_isPast)
            // {
            //     Debug.Log("ON");
            // }
            // else
            // {
            //     Debug.Log("OFF");
            // }
            
            IsSwitchingTime();



        }
    }

    public void IsSwitchingTime()
    {
        
        Invoke("enableFlash", 0);
        if (_isPast)
        {
            
            past.SetActive(true);
            Debug.Log("Is past"); 
        }

        if (_isPast == false)
        {
            past.SetActive(false);
            
            Debug.Log("Is present");
        }
    }

    public void enableFlash()
    {
        flashCanvas.SetActive(true);
        Invoke("disableFlash", 1);
    }

    public void disableFlash()
    {
        flashCanvas.SetActive(false);
    }
    

}
