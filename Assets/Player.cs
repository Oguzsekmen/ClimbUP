using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int currentCharacterIndex;
    GameObject[] characters;
    private void Awake()
    {
        characters = new GameObject[18];
        
        for (int i = 0; i < 18; i++)
        {
            characters[i] = this.transform.GetChild(i).gameObject;
        }        
    }
    private void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);        
        foreach (GameObject character in characters)
        {
            character.SetActive(false);
           
        }
        characters[currentCharacterIndex].SetActive(true);
    }
    private void OnEnable()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject character in characters)
        {
            character.SetActive(false);

        }
        characters[currentCharacterIndex].SetActive(true);
    }
}
