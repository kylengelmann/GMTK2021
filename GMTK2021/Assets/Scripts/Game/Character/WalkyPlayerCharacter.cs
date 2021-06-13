using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkyPlayerCharacter : PlayerCharacter
{
    public float maxSpeed = 8f;
    public float WalkForceFalloffStartSpeed = 5f;
    public float WalkForce = 30f;
    public int stationImUsing; //1 is tether. 2 is pilot. 0 is nothing.
    public GameObject tetherLoc;
    public GameObject pilotLoc;



    public Animator anim;
    public float moveInputX;

    protected override void UpdateMovement(float deltaTime)
    {
        moveInputX = moveInput.x;
        float moveAxisMagnitude = moveInputX;

        Vector3 moveAxisDirection = moveInputX > 0f ? Vector3.right : Vector3.left;

        moveAxisMagnitude = Mathf.Abs(moveAxisMagnitude);
        moveAxisMagnitude = Mathf.Min(moveAxisMagnitude, 1f);

        float currentSpeed = Vector3.Dot(characterRigidbody.velocity, moveAxisDirection);
        float forceSpeedFalloff = (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed) > Mathf.Epsilon ? Mathf.Clamp01((currentSpeed - WalkForceFalloffStartSpeed) / (maxSpeed*moveAxisMagnitude - WalkForceFalloffStartSpeed)) : 1f;

        float forceMagnitude = Mathf.Lerp(WalkForce, 0f, forceSpeedFalloff);

        characterRigidbody.AddForce(moveAxisDirection *forceMagnitude, ForceMode.Acceleration);
    }

    protected override void Collidable(bool collidable)
    {
        Physics.IgnoreLayerCollision(6, 9, !collidable);
    }

    private void Update()
    {
        if(usingStation)
        {
            if(stationImUsing ==1)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                anim.SetBool("IsInteracting", true);
            }
            if(stationImUsing ==2)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
                anim.SetBool("isSitting", true);
            }
        }
        else if(currentStation == null && moveInputX != 0)
        {
            if (moveInputX > 0)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, -90, 0));
            }
            if (moveInputX < 0)
            {
                this.transform.rotation = Quaternion.Euler(new Vector3(0, 90, 0));
            }

            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("IsInteracting", false);
            anim.SetBool("isSitting", false);
        }
    }
}
