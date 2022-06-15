using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
        #region Variable
        //Variables (public can be changed in unity / private can ONLY be changed in script)
    public Slider slider; //This is the changeable slider for the healthbar
        #endregion

        #region Methods
	public void SetMaxHealth(float health)
	{
		slider.maxValue = health; //this sets the max value of the bar to the value of the health and it is ran once the game is started 
		slider.value = health; //this sets the bars value to the value of the players health
	}

    public void SetHealth(float health)
	{
		slider.value = health; //this sets the bars value to the value of the players health
	}
	    #endregion
}