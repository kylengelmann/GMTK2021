using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Screeeeeeeeean : MonoBehaviour
{
    public Text Hull;
    public Text Warp;
    void Update()
    {
        Hull.text = "HULL " + Mathf.RoundToInt(((float)GameManager.ship.Health / (float)GameManager.ship.MaxHealth) * 100f).ToString() + "%";
        Warp.text = "WARP " + Mathf.RoundToInt(FindObjectOfType<WinFail>().warpDrivePercent * 100f).ToString() + "%";
    }
}
