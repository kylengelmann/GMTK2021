using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public bool bIsTop;

    public ShipController controller;
    public Animator animator;

    public bool bIsDamaged { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (!bIsDamaged)
        {
            bIsDamaged = true;
            GameManager.ship.OnHit();
            animator.SetBool("Damage", true);
            Debug.Log("Ow");

            if(controller)
            {
                controller.SetEnabled(false);
            }
        }
    }

    public void OnRepair()
    {
        if (bIsDamaged)
        {
            bIsDamaged = false;
            GameManager.ship.Repair();
            animator.SetBool("Damage", false);

            if (controller)
            {
                controller.SetEnabled(true);
            }
        }
    }
}
