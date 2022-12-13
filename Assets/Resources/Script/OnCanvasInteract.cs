using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnCanvasInteract : MonoBehaviour, IOnLookInteract
{



    

    public TMP_Text txtguide;
    public GameObject canvas;
    public GameObject parentHelper;
    public int indexNumber;
    
    
    public Sprite[] pictures = new Sprite[2];
    public GameObject currentSprite;
    public Image choosenImage;
    
    [Header("Choosen Image")]
    [Range(0,2)]
    public int choosenValue;

    
        

    private bool IsUIShowing;

    [TextArea] public string input;


    public void Awake()
    {
        currentSprite = GameObject.Find("InteractUIcurrentPicture");
        currentSprite.GetComponent<Image>();
    }


    void Start()
    {

        
        parentHelper = GameObject.Find("HELPER");
        canvas.SetActive(false);
        IsUIShowing = false;
        pictures[0] = Resources.Load<Sprite>("Texture/Interact");
        pictures[1] = Resources.Load<Sprite>("Texture/Search");
        pictures[2] = Resources.Load<Sprite>("Texture/Use");
        



    }


    void Update()
    {

        
        txtguide.ForceMeshUpdate(true);
        
        




    }
    
    public void OnLooking()
    {
        
        txtguide.SetText(input);
        currentSprite.GetComponent<Image>().sprite = pictures[choosenValue];
        txtguide.ForceMeshUpdate(true);
        canvas.SetActive(true);  
    }

    






}
