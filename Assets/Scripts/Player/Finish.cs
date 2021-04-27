using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public GameObject winnerScreen;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Time.timeScale = 0f;            
            FindObjectOfType<UIManager>().NextLevelScreen();
            FindObjectOfType<ParticleSystemPlay>().EffectStart();
            TimeControl.instance.GameOver();
           
        }
    }
    public void NextLevel()
    {
        Time.timeScale = 0f;
        FindObjectOfType<UIManager>().NextLevelScreen();
        FindObjectOfType<ParticleSystemPlay>().EffectStart();
        TimeControl.instance.GameOver();
    }
}
