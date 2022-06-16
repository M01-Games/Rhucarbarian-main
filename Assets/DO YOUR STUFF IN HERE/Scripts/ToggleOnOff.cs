using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOff : MonoBehaviour
{
    public GameObject destroyedobject;
    public float waitTime = 0.5f;

    public void destroy() 
    {
        StartCoroutine(buildingregen());
    }
    
    IEnumerator buildingregen() 
    {
        Debug.Log("Coroutine"); //Tells the system to display the text in "..."
        destroyedobject.SetActive(false); 
        yield return new WaitForSeconds(waitTime); //Waits 2 seconds
        destroyedobject.SetActive(true); 
    }
}