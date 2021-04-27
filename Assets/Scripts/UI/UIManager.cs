using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    public LevelBar levelBar;
    public GameObject settingScreen;   
    public GameObject mainScreen;
    public GameObject aboutScreen;
    public GameObject backGroundImage;
    public GameObject gameOverScreen;
    public GameObject mainMenuScreen;
    public GameObject pauseScreen;
    public GameObject winnerScreen;
    public GameObject inGame;
    public GameObject inGameScene;
    public GameObject shopScreen;
    public GameObject gameTutorialScreen;
    public GameObject characterDancing;
    public GameObject selectedCharacter;
    public GameObject attentionImage;
    public void Start()
    {
        Time.timeScale = 1f;
        //mainMenuScreen.SetActive(true);
        
        if (GameRestart.restartBool==true)
        {
            StartGame();            
            GameRestart.restartBool = false;
        }
    }
    public void Awake()
    {
        instance = this;
    }
    private void Update()
    {
        //Debug.Log(Time.timeScale);
    }
   
    public void Setting()
    {
        StartCoroutine(SettingButtonAnimDelay());
    }
    public void SettingtoMenu()
    {
        //mainScreen.SetActive(true);
        //settingScreen.SetActive(false);
        //characterDancing.SetActive(true);
        SceneManager.LoadScene(0);
    }    
    public void Exit()
    {
        Debug.Log("Çıkış Yapılıyor");
        Application.Quit();
    }
    public void StartGame()
    {
        attentionImage.SetActive(false);
        Time.timeScale = GameManager.gameSpeed;
        InGame();
        //gameTutorialScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        //Game Start
        //TimeControl.instance.BeginGame();
        //SceneManager.LoadScene(1);
        Debug.Log("oyun başlıyor.");
        Pavement.isGameStarted = true;
    }
    public void InGame()
    {
        Time.timeScale = GameManager.gameSpeed;
        pauseScreen.SetActive(false);
        backGroundImage.SetActive(false);
        mainScreen.SetActive(false);
        settingScreen.SetActive(false);
        characterDancing.SetActive(false);
        inGame.SetActive(true);
        inGameScene.SetActive(true);
        gameTutorialScreen.SetActive(false);
    }
    IEnumerator SettingButtonAnimDelay()
    {
        yield return new WaitForSecondsRealtime(.3f);
        mainScreen.SetActive(false);
        settingScreen.SetActive(true);
        characterDancing.SetActive(false);
    }
    public void NextLevel()
    {
        Debug.Log("Next Level!");
        SceneManager.LoadScene(1);
        inGame.SetActive(true);
        inGameScene.SetActive(true);
        TimeControl.instance.BeginGame();
        levelBar.SetLevelText();
        GameRestart.restartBool = true;
        //PlayerPrefs.DeleteKey("HighScore");
       
    }
    public void GameOverScreenToMain()
    {
        //inGame.SetActive(false);
        //gameOverScreen.SetActive(false);
        //mainMenuScreen.SetActive(true);
        //inGameScene.SetActive(false);
        //mainScreen.SetActive(true);
        //backGroundImage.SetActive(true);
        //characterDancing.SetActive(true);
        //Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        inGame.SetActive(false);
        pauseScreen.SetActive(true);
    }
    public void PauseScreenToMenu()
    {
        //Time.timeScale = 1f;
        //inGame.SetActive(false);
        //pauseScreen.SetActive(false);
        //mainMenuScreen.SetActive(true);
        //mainScreen.SetActive(true);
        //backGroundImage.SetActive(true);
        //characterDancing.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void ShopScene()
    {
        selectedCharacter.SetActive(true);
        shopScreen.SetActive(true);
        mainMenuScreen.SetActive(false);    
    }
    public void ShopScreenToMenu()
    {
        //selectedCharacter.SetActive(false);
        //shopScreen.SetActive(false);
        //mainMenuScreen.SetActive(true);
        SceneManager.LoadScene(0);
    }
    public void GameOverScene()
    {
        Time.timeScale = 0f;
        gameOverScreen.SetActive(true);
        inGame.SetActive(false);
        TimeControl.instance.GameOver();      
    }
    public void NextToMainMenu()
    {
        //winnerScreen.SetActive(false);
        //mainMenuScreen.SetActive(true);
        SceneManager.LoadScene(0);
        Pavement.isGameStarted = false;

    }
    public void NextLevelScreen()
    {
        Pavement.isGameStarted = false;

        winnerScreen.SetActive(true);
        inGame.SetActive(false);
    }
    public void GameOverRestart()
    {
        Pavement.isGameStarted = false;

        GameRestart.restartBool = true;
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }
    public void AboutScreen()
    {
        mainScreen.SetActive(false);
        aboutScreen.SetActive(true);
        characterDancing.SetActive(false);
    }
    public void AboutScreenToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void AttantionImageTrue()
    {
        attentionImage.SetActive(true);
    }
    public void AttentionImageFalse()
    {
        attentionImage.SetActive(false);
    }
    
}
 
