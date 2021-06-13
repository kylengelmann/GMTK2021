using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public Transform InsidePlayerSpawn;
    public Transform OutsidePlayerSpawn;

    public Tether tether;

    [HideInInspector] public int Health;
    public int HitCount = 8;
    public int MaxHealth = 3;

    private void Start()
    {
        Health = MaxHealth;
    }

    public void OnHit()
    {
        Health--;
        HitCount--;
        if(Health <= 0)
        {
            Debug.Log("Dead");
        }
    }

    public void Repair()
    {
        Health = Mathf.Min(Health + 1, MaxHealth);
        HitCount++;
    }
}
