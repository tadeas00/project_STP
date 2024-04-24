using System;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Public variables
    public GameObject[] closedDoor; 
    public GameObject[] openedDoor;
    void Start()
    {
        if (closedDoor.Length == 0 || openedDoor.Length == 0)
        {
            Debug.LogError("Chyba: Nebyly zadány všechny potřebné objekty!");
            return;
        }
        foreach (GameObject sprite in openedDoor)
        {
            sprite.SetActive(false);
        }
    }
    public void OpenDoor()
    {
        foreach (GameObject sprite in openedDoor)
        {
            sprite.SetActive(true);
        }

        
        foreach (GameObject sprite in closedDoor)
        {
            sprite.SetActive(false);
        }
    }
}

