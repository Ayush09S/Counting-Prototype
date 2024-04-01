using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLeft = 60f;
    public TextMeshProUGUI timerText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Menus.isGameActive)
        {
            if (timeLeft > 0f)
            {
                timeLeft -= Time.deltaTime;
            }
            timerText.text = $"Timer: {Mathf.Round(timeLeft)}";
        }
    }
}
