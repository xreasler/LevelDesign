using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDoor : MonoBehaviour
{


    public Transform _targetDoor;

    [Range(0, 6)] public int targetIndex;
    void Start()
    {
        
    }

    
    void Update()
    {
        OnOpen();
        if(targetIndex<0) targetIndex = 0;

       
    }

    public void OnAdd()
    {
        targetIndex++;
        Debug.Log("ADDING PUZZLEDOOR");
    }

    public void OnSubtract()
    {
        targetIndex--;
        Debug.Log("SUBTRACTING PUZZLEDOOR");
    }

    

    public void OnOpen()
    {
        if (targetIndex == 6)
        {
            _targetDoor.GetComponent<MiscSetup>().Open();
        }
        
        
    }
    
    
}
