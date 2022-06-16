using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
        #region Variable
        //Variables (pulic can be changed in unity / private can ONLY be changed in script)
    public int playerCash = 0; //The players current cash
    public int pendingPlayerCash = 0; //The players pending cash
    public GameObject cashDisplay; //The text within the gamestart menu
    public GameObject deliveryCashDisplay; //The text within the level UI
    public GameObject menuUI;
    public GameObject gameUI;
    public GameObject notEnoughCash; //The text that says "Not Enough Cash"
    public PlayerHealth playerHealth;

    //Cars and Cameras
    public Vehicle vehicleScript;
    public GameObject[] gulfKarto;
    public GameObject[] hundaCivik;
    public GameObject[] teyotoSopa;
    public GameObject[] nussanMoonline;
    public int gulfKartoPrice = 0;
    public int hundaCivikPrice = 500;
    public int teyotoSopaPrice = 750;
    public int nussanMoonlinePrice = 1000;
        #endregion

        #region Methods
    void Update() //Runs every frame
    {
        cashDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Cash: ¥" + playerCash; //Changes the text to display like "cash: 0"
        deliveryCashDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "Cash: ¥" + pendingPlayerCash; //Changes the text to display like "cash: 0"
    }

    public void GoodDestuctionCash() //The players reward for a successful delivery
    {
        pendingPlayerCash += 250; //Adds 100 to the players pending cash
    }
    public void BadDestuctionCash()
    {
        pendingPlayerCash -= 100;
    }

    public void LevelEndSuccess() //The outcome if the player gets home safely
    {
        Debug.Log("GameEndSuccess"); //Tells the system to display the text in "..."
        playerCash += pendingPlayerCash; //Sets the players current cash to the value of the pending cash
        pendingPlayerCash = 0; //Resets the pending cash, ready for the next time the player goes out for deliveries
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        playerHealth.playerHealth = 100f;
    }
    public void LevelEndFail() //The outcome if the player does not get home safely
    {
        Debug.Log("GameEndFail"); //Tells the system to display the text in "..."
        pendingPlayerCash = 0; //Resets the pending cash, ready for the next time the player goes out for deliveries
        menuUI.SetActive(true);
        gameUI.SetActive(false);
        playerHealth.playerHealth = 100f;
    }

    public void GulfKarto() //The timer upgrade the player can buy on the game start UI
    {
        if(playerCash < gulfKartoPrice) //Checks if the players current cash is less than 500 if so...
        {
            StartCoroutine(NotEnoughCash()); //Starts the NotEnoughCash protocall
        }
        else //If not
        {
        playerCash -= gulfKartoPrice; //Takes away 500 from the player current cash
        gulfKartoPrice = 0;
        vehicleScript.acceleration = 15f;
        foreach(GameObject gulfkarto in gulfKarto)
            {
            gulfkarto.SetActive(true);
            }
        foreach(GameObject hundacivik in hundaCivik)
            {
            hundacivik.SetActive(false);
            }
        foreach(GameObject teyotosopa in teyotoSopa)
            {
            teyotosopa.SetActive(false);
            }
        foreach(GameObject nussanmoonline in nussanMoonline)
            {
            nussanmoonline.SetActive(false);
            }
        }
    }
    public void HundaCivik() //The timer upgrade the player can buy on the game start UI
    {
        if(playerCash < hundaCivikPrice) //Checks if the players current cash is less than 500 if so...
        {
            StartCoroutine(NotEnoughCash()); //Starts the NotEnoughCash protocall
        }
        else //If not
        {
        playerCash -= hundaCivikPrice; //Takes away 500 from the player current cash
        hundaCivikPrice = 0;
        vehicleScript.acceleration = 20f;
        foreach(GameObject gulfkarto in gulfKarto)
            {
            gulfkarto.SetActive(false);
            }
        foreach(GameObject hundacivik in hundaCivik)
            {
            hundacivik.SetActive(true);
            }
        foreach(GameObject teyotosopa in teyotoSopa)
            {
            teyotosopa.SetActive(false);
            }
        foreach(GameObject nussanmoonline in nussanMoonline)
            {
            nussanmoonline.SetActive(false);
            }
        }
    }
    public void TeyotoSopa() //The timer upgrade the player can buy on the game start UI
    {
        if(playerCash < teyotoSopaPrice) //Checks if the players current cash is less than 500 if so...
        {
            StartCoroutine(NotEnoughCash()); //Starts the NotEnoughCash protocall
        }
        else //If not
        {
        playerCash -= teyotoSopaPrice; //Takes away 500 from the player current cash
        teyotoSopaPrice = 0;
        vehicleScript.acceleration = 25f;
        foreach(GameObject gulfkarto in gulfKarto)
            {
            gulfkarto.SetActive(false);
            }
        foreach(GameObject hundacivik in hundaCivik)
            {
            hundacivik.SetActive(false);
            }
        foreach(GameObject teyotosopa in teyotoSopa)
            {
            teyotosopa.SetActive(true);
            }
        foreach(GameObject nussanmoonline in nussanMoonline)
            {
            nussanmoonline.SetActive(false);
            }
        }
    }
    public void NussanMoonline() //The timer upgrade the player can buy on the game start UI
    {
        if(playerCash < nussanMoonlinePrice) //Checks if the players current cash is less than 500 if so...
        {
            StartCoroutine(NotEnoughCash()); //Starts the NotEnoughCash protocall
        }
        else //If not
        {
        playerCash -= nussanMoonlinePrice; //Takes away 500 from the player current cash
        nussanMoonlinePrice = 0;
        vehicleScript.acceleration = 30f;
        foreach(GameObject gulfkarto in gulfKarto)
            {
            gulfkarto.SetActive(false);
            }
        foreach(GameObject hundacivik in hundaCivik)
            {
            hundacivik.SetActive(false);
            }
        foreach(GameObject teyotosopa in teyotoSopa)
            {
            teyotosopa.SetActive(false);
            }
        foreach(GameObject nussanmoonline in nussanMoonline)
            {
            nussanmoonline.SetActive(true);
            }
        }
    }

    IEnumerator NotEnoughCash() //The NotEnoughCash protocall
    {
        notEnoughCash.SetActive(true); //Displays the text that says "Not Enough Cash"
        yield return new WaitForSeconds(2); //Waits 2 seconds
        notEnoughCash.SetActive(false); //Stops displaying the text that says "Not Enough Cash"
    }
        #endregion
}