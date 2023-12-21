using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorHandler : MonoBehaviour
{
    public static DoorHandler instance;
    private bool canOpenDoor;
    private string doorName;

    void Awake() {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool GetCanOpen()
    {
        return canOpenDoor;
    }

    public string GetDoorName()
    {
        return doorName;
    }

    public void SetCanOpen(bool status)
    {
        canOpenDoor = status;
    }

    public void SetDoorName(string name)
    {
        doorName = name;
    }

    public void ChangeRoom()
    {
        if(doorName == "")
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(GetDoorName());  
        }
    }
}
