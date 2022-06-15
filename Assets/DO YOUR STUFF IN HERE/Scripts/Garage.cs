using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garage : MonoBehaviour
{
    public Score score;
    public GameObject menuUI;
    public GameObject gameUI; 

    void OnTriggerEnter(Collider other) //This runs when the Hazard has been collided with another object
    {
        if(other.gameObject.CompareTag("Player")) //This makes sure that it was the player tha collided with the hazard and if it is then the script will run
        {
            Debug.Log("GARAGE ENTERED"); //Tells the system to display the text in "..."
            score.LevelEndSuccess(); //Runs the level success result
            menuUI.SetActive(true);
            gameUI.SetActive(false);
        }
    }
}