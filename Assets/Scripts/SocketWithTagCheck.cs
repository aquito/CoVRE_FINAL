using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketWithTagCheck: XRSocketInteractor
{
    public string targetTag = string.Empty;

    private AudioSource audioSource;
    public AudioClip audioClip;
    public bool isStatueInPlace = false;
  

    public override bool CanHover(IXRHoverInteractable interactable)
    {
        return base.CanHover(interactable) && MatchHoverUsingTag(interactable);
    }
     
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        audioSource = GetComponentInParent<AudioSource>();
        return base.CanSelect(interactable) && MatchSelectUsingTag(interactable);
    }

   private bool MatchHoverUsingTag(IXRHoverInteractable interactable)
    {
        return interactable.transform.CompareTag(targetTag);
    }

    private bool MatchSelectUsingTag(IXRSelectInteractable interactable)
    {
        
        audioSource.PlayOneShot(audioClip);

        isStatueInPlace = true;

        return interactable.transform.CompareTag(targetTag);
    }
}
