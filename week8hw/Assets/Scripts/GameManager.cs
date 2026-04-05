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
    public GameObject frontdoor;
    
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


    //key for which int matches with which direction (parameters for button to act upon)
    //North = 0
    //E = 1
    //W = 2
    //S = 3
    //LOCKED = 4
    //LOCKED2 = 5

    
    public void MoveDirection(int direction)
    {

        if (direction == 0) //north
        {
            currentLocation.northLocation.southLocation = currentLocation; //sets the south location of this location's north location to the current position
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
        currentLocation.ChangeCameraColor(); //calls on location to change the camera color based on the current location's values
        
    }

    public void ChangeBackgroundColor() //calls a function in Location script that updates the text
    {
        currentLocation.ChangeCameraColor();
    }

    public void ShowFireText() //calls a function in Location script that updates the text
    {
        currentLocation.ActivateFirePlace(this);
    }
    
    public void ShowDeskText() //calls a function in Location script that updates the text
    {
        currentLocation.ActivateDesk(this);
        hasPliers = true;
    }
    
    public void ShowWaterText() //calls a function in Location script that updates the text
    {
        currentLocation.ActivateWater(this);
        if (isCut)
        {
        hasWater = true;
        }
    }
    
    public void ShowCabinentText() //calls a function in Location script that updates the text
    {
        currentLocation.ActivateCabinent(this);
        if (hasKey) //checks if the player got the key
        {
            hasFlashlight = true; //marks that the player now has a flashlight
        }
    }
    
    public void ShowCrackText()
    {
        if (hasFlashlight)
        {
            currentLocation.ActivateCrack(this);
        }
        
        

    }
   
    
    public void ShowDoorText()
    {
      
        currentLocation.ActivateDoor(this);
            
    }
}
