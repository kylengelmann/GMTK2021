using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public bool bIsTop;

    public ShipController controller;
    public Animator animator;

    private void OnCollisionEnter(Collision collision)
    {
        GameManager.ship.OnHit();
        animator.SetBool("Damage", true);
        Debug.Log("Ow");
    }
}
