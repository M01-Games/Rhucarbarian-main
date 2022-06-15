using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public int gunDamage; //How much damage the bullet will do
    public int gunRange; //How far the bullet can travel
    public float fireRate; //How fast the gun shoots the bullets
    public float nextFire; //How long it take for the next bullet to fire
    public GameObject firePoint; //The point where the gun will fire from
    public GameObject impactEffect; //The effect played when hitting an object
    public ParticleSystem muzzleFlash; //the flash when shoots
        #endregion

        #region Methods
    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time >= nextFire) //Checks if the player shoots and if so then runs this part
        {
            nextFire = Time.time + 1f/fireRate; //sets the weapon a fire rate cuasing their to be a delay once the player has shot
            Shoot(); //This runs the shooting task
        }
    }
    
    void Shoot() //This is the shooting taks
    {
        muzzleFlash.Play(); //this plays the firing effect
        RaycastHit hit; //this creates a stock of what the raycast has hit when it is used
        nextFire = Time.time + fireRate; //
        Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange); 
        //this creates a ray by using the position of the end of the barrel as the start of the ray, the direction which the barrel is pionting towards and the guns range as the rays range
        if(Physics.Raycast(firePoint.transform.position, firePoint.transform.forward, out hit, gunRange)) //hecks if the ray has hit any object if so...
        {
            Debug.Log(hit.transform.name); //Tells the system to display the name of the object
        }
        Desturction target = hit.transform.GetComponent<Desturction>(); //creates a local value from the objects scripts
        if(target != null) //checks if the object has the destruction system on it if so...
        {
            target.TakeDamage(gunDamage); //takes the weapons damage off of the object
        }
        
        GameObject impactObj = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); //this takes the postion the raycast hit and displays the impact effect towards the player
        Destroy(impactObj, 2f); //this deletes that effect after 2 seconds
    }
        #endregion
}