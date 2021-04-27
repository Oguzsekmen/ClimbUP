using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectingScore : MonoBehaviour
{
    public GameObject collectScore;
    public static int score;

    

    void Update()
    {
        collectScore.GetComponent<TMPro.TextMeshProUGUI>().text = score.ToString();
    }
}
