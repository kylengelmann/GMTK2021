using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairController : ShipController
{
    public Damagable damagable;

    float RepairTime = 5f;

    float timeTilDone;

    bool bWasDamaged = false;

    Collider trigger;

    private void Start()
    {
        trigger = GetComponent<Collider>();
        trigger.enabled = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<FloatyPlayerCharacter>())
        {
            other.gameObject.GetComponent<FloatyPlayerCharacter>().currentStation = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FloatyPlayerCharacter>() && other.GetComponent<FloatyPlayerCharacter>().currentStation == this)
        {
            other.gameObject.GetComponent<FloatyPlayerCharacter>().currentStation = null;
        }
    }


    public override void setPlayerUsing(bool newIsPlayerUsing)
    {
        base.setPlayerUsing(newIsPlayerUsing);

        
    }

    private void Update()
    {
        if(!bWasDamaged)
        {
            if(damagable.bIsDamaged)
            {
                timeTilDone = RepairTime;
                trigger.enabled = true;
            }
        }

        bWasDamaged = damagable.bIsDamaged;

        if(playerUsing)
        {
            timeTilDone -= Time.deltaTime;
            if(timeTilDone <= 0f)
            {
                damagable.OnRepair();
                trigger.enabled = false;
            }
        }
    }


}
