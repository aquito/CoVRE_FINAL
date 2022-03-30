using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncPosition : MonoBehaviour
{
    
    public Transform objectToFollow;

    private void Start()
    {
        this.gameObject.transform.position = objectToFollow.position;
    }
    // Update is called once per frame
    void Update()
    {
        if (objectToFollow != null)
        {
            this.gameObject.transform.position = objectToFollow.position;
        }
        
    }
}
