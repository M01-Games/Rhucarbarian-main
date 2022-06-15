using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
        #region Variable
        //Variables (public can be changed in unity / private can ONLY be changed in script)
    public float playerHealth = 100f; //This is the players health when they start the game
    public HealthBar healthBar; //Finds the health bar and creates it a variable for this script
    public Score score;
        #endregion

        #region Methods
    void Start() 
    {
        healthBar.SetMaxHealth(playerHealth); //When the game is started the health bar will be eaqual to the players health
    }
    void Update()
    {
        healthBar.SetHealth(playerHealth); //During the game if the player loses health this wil set the health bar to the players current health at that frame
        if(playerHealth <= 0) //This checks if the player's health equals 0 if so then this part runs
        {
            Debug.Log("PlayerDEAD"); //Tells the system to display the text in "..."
            score.LevelEndFail();
        }
    }
    #endregion
}