using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CharacterSelect : MonoBehaviour
{
    public int currentCharacterIndex;
    public int buttonInt;
    public GameObject[] characterModels;
    public CharacterBuy[] characters;
    public Button buyButton;
    public Button selectButton;
    public Text shopCoinText;
    public TextMeshProUGUI proUGUI;
    private void Start()
    {
        foreach (CharacterBuy character in characters)
        {
            //if (character.price==0)
            //{
            //    character.inUnLocked = true;
            //}
            //else
            //{
            //    character.inUnLocked = PlayerPrefs.GetInt(character.name, 0)==0 ? false : true;
            //}
        }
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject character in characterModels)
        {
            character.SetActive(false);
            characterModels[currentCharacterIndex].SetActive(true);
        }
        //PlayerPrefs.DeleteAll();         
    }
    private void Update()
    {
        UpdateUI();        
        shopCoinText.text= PlayerPrefs.GetInt("NumberOfCoins").ToString();
       //Debug.Log(PlayerPrefs.GetInt("SelectedCharacter", currentCharacterIndex));
    }
    public void ChangeNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex++;
        if (currentCharacterIndex==characterModels.Length)
        {
            currentCharacterIndex = 0;
        }
        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (!coinPrice.inUnLocked)
        {
            return;
        }
        if (PlayerPrefs.GetInt("SelectedCharacter", currentCharacterIndex) == currentCharacterIndex)
        {
            selectButton.interactable = false;
        }
        else
        {
            selectButton.interactable = true;
        }
    }
    public void ChangePrevious()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
        {
            currentCharacterIndex = characterModels.Length-1;
        }
        characterModels[currentCharacterIndex].SetActive(true);

        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (!coinPrice.inUnLocked)
        {
            return;
        }

        if (PlayerPrefs.GetInt("SelectedCharacter", currentCharacterIndex)==currentCharacterIndex)
        {
            selectButton.interactable = false;
        }
        else
        {
            selectButton.interactable = true;
        }
    }   
    public void SelectedButton()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
        selectButton.interactable = false;
        Debug.Log(PlayerPrefs.GetInt("SelectedCharacter", currentCharacterIndex));
    }
    private void OnEnable()
    {
        //SelectedButton();
        selectButton.interactable = false;
    }
    public void UnLockCharacter()
    {
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(coinPrice.name, 1);
        PlayerPrefs.SetInt("SelectedCharacter",currentCharacterIndex);
        coinPrice.inUnLocked = true;
        selectButton.interactable = false;
        //PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - coinPrice.price); /*>> Coin - Satın alınan öge fiyatı*/        
    }
    public void UpdateUI()
    {
        CharacterBuy coinPrice = characters[currentCharacterIndex];
        if (coinPrice.inUnLocked)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
            buyButton.GetComponentInChildren<Text>().text = /*"Buy -" +*/ coinPrice.price;

            //if (coinPrice.price < PlayerPrefs.GetInt("NumberOfCoins", 0))
            //{
            //    buyButton.interactable = true;
            //}
            //else
            //{
            //    buyButton.interactable = false;
            //}
        }
    }
}
