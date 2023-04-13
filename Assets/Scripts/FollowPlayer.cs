using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

   public Transform player;
   public float offsetX = 0f;
   public float smoothTime = 0f; // time to reach position
   public float shakeMagnitude = 0f; // strength of shake effect

   private Transform parentTransform;
   private Vector3 velocity = Vector3.zero;
   
   private void Start()
   {
        parentTransform = transform.parent;
   }


    private void LateUpdate()
    {
        if (player != null)
        {
            float targetXPos = player.position.x + offsetX;

            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                targetXPos += Input.GetAxisRaw("Horizontal") * shakeMagnitude;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                targetXPos -= Input.GetAxisRaw("Horizontal") * shakeMagnitude;
            }
        
            //snoothly moves background to target
            float newXPos = Mathf.SmoothDamp(parentTransform.position.x, targetXPos, ref velocity.x, smoothTime);
            Vector3 newPos = new Vector3(newXPos, parentTransform.position.y, parentTransform.position.z);
            parentTransform.position = newPos;

        }
        
    }
}
