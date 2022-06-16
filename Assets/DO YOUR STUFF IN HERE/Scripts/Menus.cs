using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menus : MonoBehaviour
{
    public GameObject GameUI;
    public GameObject MenuUI;
    public GameObject[] Player;
    public GameObject StartPosition;

    public void PlayButton()
    {
        MenuUI.SetActive(false);
        GameUI.SetActive(true);
        foreach(GameObject player in Player)
        {
            player.transform.position = StartPosition.transform.position;
        }
    }
}