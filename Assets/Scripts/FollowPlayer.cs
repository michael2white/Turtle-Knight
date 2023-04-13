using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

   public Transform player;
   public float offsetX = 0f;

   private Transform parentTransform;
   
   private void Start()
   {
        parentTransform = transform.parent;
   }


    private void LateUpdate()
    {
        if (player != null)
        {
            float newXPos = player.position.x + offsetX;
            Vector3 newPos = new Vector3(newXPos, parentTransform.position.y, parentTransform.position.z);
            parentTransform.position = newPos;

        }
        
    }
}
