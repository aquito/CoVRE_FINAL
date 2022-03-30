using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPosition : MonoBehaviour
{
    
    public Transform objectToFollow; 
    

    // Update is called once per frame
    void Update()
    {
        if(objectToFollow !=null)
        this.gameObject.transform.position = objectToFollow.position;  //Translate(objectToFollow.position, Space.World);
    }
}
