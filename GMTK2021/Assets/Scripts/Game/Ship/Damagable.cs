using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public bool bIsTop;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Ow");
    }
}
