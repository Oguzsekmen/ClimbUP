using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCharacterSelect : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModel;

    private void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject character in characterModel)
        {
            character.SetActive(false);
            characterModel[currentCharacterIndex].SetActive(true);
        }
    }
}
