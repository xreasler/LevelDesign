using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OnCanvasInteract : MonoBehaviour, IOnLookInteract
{



    

    public TMP_Text txtguide;
    public GameObject canvas;
    public GameObject parentHelper;
    public int indexNumber;

    private bool IsUIShowing;

    [TextArea] public string input;
    
    

    

    void Start()
    {
        
        parentHelper = GameObject.Find("HELPER");
        canvas.SetActive(false);
        IsUIShowing = false;

    }


    void Update()
    {

        
        txtguide.ForceMeshUpdate(true);
        
        




    }
    
    public void OnLooking()
    {
        txtguide.SetText(input);

        txtguide.ForceMeshUpdate(true);
        canvas.SetActive(true);  
    }

    






}
