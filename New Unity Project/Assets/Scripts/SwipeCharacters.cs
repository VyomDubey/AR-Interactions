using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeCharacters : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject Player1, Player2;
    void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        Player2.SetActive(false);
    }

    public void NextCharacter()
    {
        Player1.SetActive(false);
        Player2.SetActive(true);
    }
    public void PreviousCharacter()
    {
        Player2.SetActive(false);
        Player1.SetActive(true);
    }
}
