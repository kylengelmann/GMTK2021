using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TurretControl : ShipController
{
    public float minAngle = -180f;
    public float maxAngle = 0f;

    public GameObject TurretBarrel;
    public GameObject PewLaser;

    public Transform PewLaserSpawn;

    public float Cooldown = .6f;
    float TimeLastShot;

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

    public override void OnClick(InputAction.CallbackContext context)
    {
        if (context.ReadValueAsButton())
        {
            Debug.Log("pew");
            Shoot();
        }
    }

    void Shoot()
    {
        if (TimeLastShot + Cooldown < Time.time)
        {
            TimeLastShot = Time.time;

            Instantiate(PewLaser, PewLaserSpawn.position, PewLaserSpawn.rotation);

            RaycastHit hit;

            Debug.DrawLine(TurretBarrel.transform.position, TurretBarrel.transform.position + 100f * TurretBarrel.transform.forward, Color.green, 5f);
            int layerMask = LayerMask.GetMask("Asteroid");
            if (Physics.Raycast(TurretBarrel.transform.position, TurretBarrel.transform.forward, out hit, 100f, layerMask))
            {
                Asteroid asteroid = hit.collider.gameObject.GetComponent<Asteroid>();
                if (asteroid)
                {
                    asteroid.OnShot();
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerUsing)
        {
            Vector3 mousePos = GameManager.playerController.GetMouseLocation();
            Vector3 aimDir = mousePos - transform.position;
            aimDir.z = 0f;
            if (aimDir.sqrMagnitude > Mathf.Epsilon)
            {
                Vector3 aimDirLocal = TurretBarrel.transform.parent.InverseTransformDirection(aimDir).normalized;
                float aSin = Mathf.Asin(-aimDirLocal.y);
                float aCos = Mathf.Acos(aimDirLocal.z);
                float angle = Mathf.Rad2Deg * (aSin > 0f ? aCos : -aCos);

                if (angle >= minAngle && angle <= maxAngle)
                {
                    TurretBarrel.transform.localRotation = Quaternion.AngleAxis(angle, Vector3.right);
                }
            }
        }
    }
}
