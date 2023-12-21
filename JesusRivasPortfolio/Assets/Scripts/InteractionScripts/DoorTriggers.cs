using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggers : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hi player, I am the door to " + gameObject.name);
            DoorHandler.instance.SetCanOpen(true);
            DoorHandler.instance.SetDoorName(gameObject.name);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Bye player, I am the door to " + gameObject.name);
            DoorHandler.instance.SetCanOpen(false);
            DoorHandler.instance.SetDoorName("");

        }
    }
}
