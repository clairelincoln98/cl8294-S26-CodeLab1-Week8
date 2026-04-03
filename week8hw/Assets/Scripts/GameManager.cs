using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI locationNameDisplay;
    public TextMeshProUGUI locationDescriptionDisplay;
    public Location startingLocation;
    

    public Location currentLocation;

    public GameObject NorthButton;
    public GameObject EastButton;
    public GameObject SouthButton;
    public GameObject WestButton;

    public GameObject fireplace;
    public GameObject desk;
    public GameObject bath;
    public GameObject cabinent;
    public GameObject crack;
    
    public GameManager instance;
    public bool hasPliers;
    public bool isCut;
    public bool hasWater;
    public bool hasFlashlight;
    public bool hasKey;
  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        

        if (instance == null)
        {
            instance  = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
        //changes in code you make to SO persist after play mode
        Debug.Log("Current location:" + startingLocation);
        
       // locationNameDisplay.text = startingLocation.name;
       // locationDescriptionDisplay.text = startingLocation.description;
        
        startingLocation.UpdateLocationDisplay(this);
        currentLocation = startingLocation;
        
    }


    //North = 0
    //E = 1
    //W = 2
    //S = 3
    //LOCKED = 4
    //LOCKED2 = 5

    
    public void MoveDirection(int direction)
    {
        //TODO: make the location actually change when this function is called

        if (direction == 0) //north
        {
            currentLocation.northLocation.southLocation = currentLocation;
            currentLocation = currentLocation.northLocation;
            
        }

        if (direction == 1) //east
        {
            currentLocation.eastLocation.westLocation = currentLocation;
            currentLocation = currentLocation.eastLocation;
        }

        if (direction == 2) //west
        {
            currentLocation.westLocation.eastLocation = currentLocation;
            currentLocation = currentLocation.westLocation;
        }
        if (direction == 3) //south
        {
            currentLocation.southLocation.northLocation = currentLocation;
            currentLocation = currentLocation.southLocation;
        }

        currentLocation.UpdateLocationDisplay(this); 
        currentLocation.ChangeCameraColor();
        
    }

    public void ChangeBackgroundColor()
    {
        currentLocation.ChangeCameraColor();
    }

    public void ShowFireText()
    {
        currentLocation.ActivateFirePlace(this);
    }
    
    public void ShowDeskText()
    {
        currentLocation.ActivateDesk(this);
        hasPliers = true;
    }
    
    public void ShowWaterText()
    {
        currentLocation.ActivateWater(this);
        if (isCut)
        {
        hasWater = true;
        }
    }
    
    public void ShowCabinentText()
    {
        currentLocation.ActivateCabinent(this);
        if (hasKey)
        {
            hasFlashlight = true;
        }
    }
    
    public void ShowCrackText()
    {
        if (hasFlashlight)
        {
            currentLocation.ActivateCrack(this);
        }

    }
   
}
