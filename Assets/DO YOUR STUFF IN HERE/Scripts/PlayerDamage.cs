using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public float damageAmount = 25f;

    void OnTriggerEnter(Collider other) //This runs when the Hazard has been collided with another object
    {
        if(other.gameObject.CompareTag("Player")) //This makes sure that it was the player tha collided with the hazard and if it is then the script will run
        {
            Debug.Log("PLAYER HIT"); //Tells the system to display the text in "..."
            playerHealth.playerHealth -= damageAmount;
        }
    }
}