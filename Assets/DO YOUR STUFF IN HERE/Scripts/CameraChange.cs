using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public int selectedWeapon = 0; //this is the weapon select value
        #endregion

        #region Methods
    void Start()
    {
        SelectWeapon(); //the selection task
    }

    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;

        if(Input.GetKeyDown(KeyCode.C))
        {
            selectedWeapon += 1;
            if(selectedWeapon >= 3)
            {
                selectedWeapon = 0;
            }
        }
      
        if(previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon(); //the selection task
        }
    }

    void SelectWeapon() //the selection task
    {
        int i = 0; //the first weapon
        foreach (Transform weapon in transform) //this sets the weapon list up from all the childern of the weaponholder from the hiaraky from unity
        {
            if(i == selectedWeapon) //checks if the value of i is the same as the value of which weapon is selected if so...
            weapon.gameObject.SetActive(true); //toggels the weapon on
            else //if they are not the same value...
            weapon.gameObject.SetActive(false); //toggles the weapon off
            i++; //this adds 1 to the value of i meaning the weapon is switched to the next
        }
    }        
        #endregion
}