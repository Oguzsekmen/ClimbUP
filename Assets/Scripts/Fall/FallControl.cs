using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class FallControl : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image gradientColor;
    //public GameObject[] hands;
    public GameObject handler;
    float time;
    bool isGameStarted = false;
    [SerializeField] float fallDistance;
    HandsMovementController movementController;

    private void Start()
    {
        StartCoroutine(StartGame());
    }
    void Update()
    {

        BreakTime();
    }


    void BreakTime()
    {
        if (!isGameStarted) { return; }
        //Debug.Log(!FlyControl.FlyStatu);
        //Debug.Log(Pavement.isGameStarted);
        if (!FlyControl.FlyStatu && Pavement.isGameStarted)
        {
            time = time + Time.deltaTime;
            if (Input.GetButton("Fire1"))
            {
                time = 0;
            }

            if (time >= 5)
            {
                SlideFall(fallDistance);
            }
            Bar(time);
        }

    }

    public void Fall(float fallDistance)
    {
        Vector3 handlerPos = handler.transform.position + new Vector3(0f, -fallDistance, 0f);
        handler.transform.DOMove(handlerPos, 1f);
    }

    public void SlideFall(float fallDistance)
    {
        handler.transform.position = handler.transform.position - Time.unscaledDeltaTime * fallDistance * Vector3.down;
    }

    void Bar(float sliderTime)
    {
        slider.value = sliderTime;
        gradientColor.color = gradient.Evaluate(slider.normalizedValue);
    }
    IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3.5f);
        isGameStarted = true;
        TimeControl.instance.BeginGame();
    }
}
