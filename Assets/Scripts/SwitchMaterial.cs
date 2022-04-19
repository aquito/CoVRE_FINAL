using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SwitchMaterial : MonoBehaviour
{
    private Material originalMaterial; // for storing the initial material (eg if it needs to be changed back)
    
    [SerializeField]
    private Material newMaterial; // defining a material object for the new one

    

    [SerializeField]
    private VisualEffectAsset newFX;


    void Start()
    {
        originalMaterial = GetComponent<MeshRenderer>().material; // storing the existing material
    }
        
    public void Switch() // public method so that the puzzlemanager script can access this 
    {
        GetComponent<MeshRenderer>().material = newMaterial; // when called, switching to the new one
        GetComponent<VisualEffect>().visualEffectAsset = newFX;
        
    }
}
