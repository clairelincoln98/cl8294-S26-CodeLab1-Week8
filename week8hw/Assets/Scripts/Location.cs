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
    public string cabinentText;
    public string crackText;
    public string description;
    public Location northLocation;
    public Location westLocation;
    public Location eastLocation;
    public Location southLocation;
    
    public Vector4 cameraColor;
    
    public bool isLivingroom;
    public bool isBedroom;
    public bool isBathroom;
    public bool isBasement;
    public bool isKitchen;
    
    public Location WestLocation
    {
        set
        {
            westLocation = value;
            value.eastLocation = this;
            
        }

        get
        {
            return westLocation;
        }
    }
    public void UpdateLocationDisplay(GameManager gm)
    {
        
        gm.locationNameDisplay.text = name;
        gm.locationDescriptionDisplay.text = description;
        gm.NorthButton.SetActive(northLocation != null);
        gm.EastButton.SetActive(eastLocation != null);
        gm.SouthButton.SetActive(southLocation != null);
        gm.WestButton.SetActive(westLocation != null);

        if (isLivingroom)
        {
            gm.fireplace.SetActive(true);
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
    }
    
    public void ChangeCameraColor()
    
    {
        if (Camera.main != null)
    {
        Camera.main.backgroundColor = cameraColor;
    }
    
    }


    public void ActivateFirePlace(GameManager gm)
    {
        gm.locationDescriptionDisplay.text = firePlaceText;
        if (gm.hasPliers)
        {
            gm.locationDescriptionDisplay.text =
                "I'm able to cut the screen open. But the fire is too hot to grab what's inside. I need to put this out somehow.";
            gm.isCut = true;
        }
        
        if (gm.isCut && gm.hasWater)
        {
            gm.locationDescriptionDisplay.text =
                "Great, now I can reach inside this digusting paste of dirty bath water and ash. It's...a key.";
            gm.hasKey = true;
        }
    }
    
    public void ActivateDesk(GameManager gm)
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
        if (gm.hasKey)
        {
            gm.locationDescriptionDisplay.text = cabinentText;
        }
        else
        {
            gm.locationDescriptionDisplay.text = "It's locked.";
        }


    }
    
    public void ActivateCrack(GameManager gm)
    {
       
        gm.locationDescriptionDisplay.text = crackText;
        
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

