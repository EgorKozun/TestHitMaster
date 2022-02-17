using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform Player;
   Vector3 Target;

   public float TrackingSpeed;

    
    void Update()
    {
        if(Player)
        {
            Vector3 currentPosition = Vector3.Lerp(transform.position, Target, TrackingSpeed * Time.deltaTime);
            transform.position = currentPosition;
            
            Target = new Vector3(transform.position.x, transform.position.y, Player.transform.position.z - 3f);
        }
    }
}
