using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    Camera mainCam;
    public static int numberOfCoins;
    public Text coinText;
    public Text shopCoinText;
    public Text gameOverText;
    public int coinPoint;
    bool coinCollected = false;
    [SerializeField]
    float rotSpeed = 100f;
    Transform target;
    bool dummy = false;
    float timer = 0f;
    [SerializeField] Vector3 scaleRatio = new Vector3(0.01f, 0.01f, 0.01f);
    [SerializeField] Vector3 coinPosIncrement = new Vector3(8f, 14f, 0f);
    Vector3 basePos;
    [SerializeField] float animTime = 2f;
    private void Start()
    {
        mainCam = Camera.main;
    }
    private void Update()
    {
        coinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
        shopCoinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
        gameOverText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
        if (dummy)
        {
            timer += Time.unscaledDeltaTime;
            transform.position = Vector3.Lerp(basePos, new Vector3 (mainCam.transform.position.x, mainCam.transform.position.y,basePos.z) + coinPosIncrement, timer / animTime);
            transform.localScale = Vector3.Lerp(new Vector3(1f,1f,1f), scaleRatio, timer / animTime);
            transform.Rotate(0f, 0f, rotSpeed * Time.unscaledDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !coinCollected)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
            basePos = transform.position;
            //if (target== null) { target = GameObject.FindGameObjectWithTag("CoinTarget").transform; }
            coinCollected = true;
            dummy = true;
            numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins") + coinPoint;
            PlayerPrefs.SetInt("NumberOfCoins", numberOfCoins);
            coinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
            shopCoinText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
            gameOverText.text = PlayerPrefs.GetInt("NumberOfCoins").ToString();
            Destroy(gameObject, animTime * GameManager.gameSpeed);
        }
    }
}
