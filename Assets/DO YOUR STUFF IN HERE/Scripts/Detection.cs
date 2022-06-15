using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public Enemy enemy;
    
    void OnTriggerEnter(Collider other) //This runs when the Hazard has been collided with another object
    {
        if(other.gameObject.CompareTag("Player")) //This makes sure that it was the player tha collided with the hazard and if it is then the script will run
        {
            Debug.Log("Player Detected"); //Tells the system to display the text in "..."
            enemy.enabled = true; //engages the attacking script
        }
    }
}