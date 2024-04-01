using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Counter : MonoBehaviour
{
    public TextMeshProUGUI CounterText;
    public Collider countingColliderTop;
    public Collider countingColliderBottom;
    private bool isHoldingBall;
    public static int Count = 0; // Count ammount

    public static bool ballHitTop;
    public static bool ballHitBottom;
    public bool ballCountEnable;

    private void Start()
    {

    }

    private void Update()
    {
        isHoldingBall = HoldBall.isHolding;

        if (ballHitTop && ballHitBottom && !isHoldingBall)
        {
            // Every object that enters the box through the collider adds 1 to the count
            Count += 1;
            CounterText.text = "Count : " + Count;
            ballHitBottom = false;
            ballHitTop = false;
        }
    }
}
