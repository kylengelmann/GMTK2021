using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinFail : MonoBehaviour
{
    public float warpDriveMinTime;
    public float warpDriveChargeTime;
    public float damageAmount;
    public float damageTimeIncrease;
    public float damageFactor;
    public float warpDrivePercent;
    public float currentTime;
    
    void OnPlayClicked()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        warpDriveChargeTime = Time.time + warpDriveMinTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Time.time;

        //update damageAmount
        damageAmount = 8 - GameManager.ship.HitCount;
        
        //update damageTimeIncrease
        damageTimeIncrease = damageAmount*damageFactor;
        
        //take into account current damage and add time to warpDriveChargeTime;
        warpDriveChargeTime = warpDriveChargeTime + damageTimeIncrease * Time.deltaTime;

        warpDrivePercent = currentTime / warpDriveChargeTime;

        if (currentTime > warpDriveChargeTime)
        {
            Win();
        }
    }
    void Win() //winning
    {
        
    }
    void Lose() //losing
    {

    }
}
