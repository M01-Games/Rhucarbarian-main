using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desturction : MonoBehaviour
{
    public float health = 100f; //The amount of health the object has
    private int chance;
    public Score score;
    public ToggleOnOff toggleOnOff;


    void Update()
    {
        chance = Random.Range(0, 101); //Sets the chance to a random number from 1 to 100
    }


    public void TakeDamage(float amount) //Sees how much health it just lost by gettting attacked
    {
        health-= amount; //Takes the lost health away from the current health of this object
        if(health <= 0f) //Checks if the objects health is 0 or below and if so runs this part
        {
            if(chance <=50)
            {
                score.GoodDestuctionCash();
                Debug.Log("GOOD"); //Tells the system to display the text in "..."
            }
            else
            {
                score.BadDestuctionCash();
                Debug.Log("BAD"); //Tells the system to display the text in "..."
            }
            toggleOnOff.destroyedobject = this.gameObject;
            toggleOnOff.destroy();
            health = 100f;
        }
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player")) //This makes sure that it was the player tha collided with the hazard and if it is then the script will run
        {
            health-= 50f; //Takes the lost health away from the current health of this object
            if(health <= 0f) //Checks if the objects health is 0 or below and if so runs this part
            {
                if(chance <=50)
                {
                    score.GoodDestuctionCash();
                    Debug.Log("GOOD"); //Tells the system to display the text in "..."
                }
                else
                {
                    score.BadDestuctionCash();
                    Debug.Log("BAD"); //Tells the system to display the text in "..."
                }
                toggleOnOff.destroyedobject = this.gameObject;
                toggleOnOff.destroy();
                health = 100f;
            }
        }
    }
}