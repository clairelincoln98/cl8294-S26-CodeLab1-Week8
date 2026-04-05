using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Location", menuName = "Scriptable Objects/Location")]
public class Location : ScriptableObject
{
    
    
    //scriptable object is something that can store data in fields
    public string name;
    public string firePlaceText;
    public string deskText;
    public string waterText;
    public string cabinentText; //
    public string crackText; //description of entrance in basement 
    public string description; //description of room
    public Location northLocation; //locations
    public Location westLocation;
    public Location eastLocation;
    public Location southLocation;
    
    public Vector4 cameraColor;
    
    public bool isLivingroom; //bools that determine which room we're in
    public bool isBedroom;
    public bool isBathroom;
    public bool isBasement;
    public bool isKitchen;
    public bool isStairway;
    
    public void UpdateLocationDisplay(GameManager gm)
    {
        
        gm.locationNameDisplay.text = name;
        gm.locationDescriptionDisplay.text = description;
        gm.NorthButton.SetActive(northLocation != null); //calling the game manager to set the button active
        gm.EastButton.SetActive(eastLocation != null);
        gm.SouthButton.SetActive(southLocation != null);
        gm.WestButton.SetActive(westLocation != null);

        if (isLivingroom) //checks which location this is
        {
            gm.fireplace.SetActive(true); //set's the button referenced in GM to active (if this is living room, the fireplace button should be there)
        }
        else
        {
            gm.fireplace.SetActive(false);
        }
        
        if (isBedroom)
        {
            gm.desk.SetActive(true);
        }
        else
        {
            gm.desk.SetActive(false);
        }
        
        if (isBathroom)
        {
            gm.bath.SetActive(true);
        }
        else
        {
            gm.bath.SetActive(false);
        }
        
        if (isKitchen)
        {
            gm.cabinent.SetActive(true);
        }
        else
        {
            gm.cabinent.SetActive(false);
        }
        
        if (isBasement && gm.hasFlashlight)
        {
            gm.crack.SetActive(true);
        }
        else
        {
            gm.crack.SetActive(false);
        }
        
        if (isStairway)
        {
            gm.frontdoor.SetActive(true);
        }
        else
        {
            gm.frontdoor.SetActive(false);
        }
    }
    
    public void ChangeCameraColor()
    
    {
        if (Camera.main != null) //checks if there is a camera
    {
        Camera.main.backgroundColor = cameraColor; //changes the background color of camera (background color of room)
    }
    
    }


    public void ActivateFirePlace(GameManager gm) //changes the text in gameManager to the fireplace text
    {
        gm.locationDescriptionDisplay.text = firePlaceText; 
        if (gm.hasPliers) //changes the fireplace text based on whether or not the player has already received the pliers
        {
            gm.locationDescriptionDisplay.text =
                "I'm able to cut the screen open. But the fire is too hot to grab what's inside. I need to put this out somehow.";
            gm.isCut = true; //sets isCut to true now that the player has clicked on the fireplace with pliers
        }
        
        if (gm.isCut && gm.hasWater) //checking if the fireplace is open and if the player has the water to put out the fire
        {
            gm.locationDescriptionDisplay.text =
                "Great, now I can reach inside this digusting paste of dirty bath water and ash. It's...a key.";
            gm.hasKey = true; 
        }
    }
    
    public void ActivateDesk(GameManager gm) //changes the description text to whatever the desk tesk is
    {
        gm.locationDescriptionDisplay.text = deskText;
    }
    
    public void ActivateWater(GameManager gm)
    {
        if (gm.isCut)
        {
            gm.locationDescriptionDisplay.text = waterText;
        }
        
        else
        {
            gm.locationDescriptionDisplay.text = "I can't stand this smell.";
        }
        
    }
    
    
    public void ActivateCabinent(GameManager gm)
    {
        if (gm.hasKey) //checks if hasKey is true
        {
            gm.locationDescriptionDisplay.text = cabinentText; //reveals what's inside the cabinent
        }
        else
        {
            gm.locationDescriptionDisplay.text = "It's locked."; //reveals that cabinent is locked
        }


    }
    
    public void ActivateCrack(GameManager gm)
    {
       
        gm.locationDescriptionDisplay.text = crackText;
        
    }
    
    public void ActivateDoor(GameManager gm) 
    {

        gm.locationDescriptionDisplay.text = "It's boarded up."; //sets the door text, no conditions will change this text right now
    }


    
    // public Vector4 CameraColor;
    // {
    //     set
    //     {
    //         cameraColor = value;
    //
    //     }
    //     
    //     get
    //     {
    //         return cameraColor;
    //     }
    // }
}

