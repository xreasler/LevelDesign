using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPuzzle : MonoBehaviour, IPushInteract
{


    private int currentIndex;
    [Header("Choose the target value of the correct puzzle painting")]
    [Range(0, 5)] public int target;

    public PuzzleDoor _puzzleDoor;
    [Header("Target rotation of object")]
    Rigidbody m_Rigidbody;
    Vector3 m_EulerAngleVelocity;
    
    float speed = 0.01f;
    float timeCount = 0.0f;

    private bool IsTripped = false;

    

    
    

    
    void Start()
    {
        
        _puzzleDoor = GameObject.Find("puzzleDoorHandler").GetComponent<PuzzleDoor>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 0, 3000);
        CatchUp();
    }

    
    void Update()
    {
        
    }

    public void Onspin()
    {
        currentIndex++;

        if (currentIndex == 6)
        {
            currentIndex = 0;
            Debug.Log("Reseting value of index");
        }
        if (currentIndex == target)
        {
          _puzzleDoor.OnAdd(); 
          Debug.Log("ADDING");
        }
        if (currentIndex == target + 1)
        {
            _puzzleDoor.OnSubtract(); 
            Debug.Log("SUBTRACTING");
        }
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);
        


    }

    public void CatchUp()
    {
        if (target == 0 && IsTripped == false)
        {
            _puzzleDoor.OnAdd();
            IsTripped = true;
        }
    }

    public void Interact()
    {
       //DOES STUFF
        Onspin(); 
    }

    // public void Testing()
    // {
    //     if (Input.GetKeyDown(KeyCode.Y))
    //     {
    //        Onspin(); 
    //     }
    // }
}
