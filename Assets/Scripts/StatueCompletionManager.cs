using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StatueCompletionManager : MonoBehaviour
{

    public bool isGreenAnubisInPlace = false;
    public bool isRedAnubisInPlace = false;
    public bool isYellowAnubisInPlace = false;

    public GameObject greenAnubis;
    public GameObject redAnubis;
    public GameObject yellowAnubis;

    public SocketWithTagCheck greenSocket;
    public SocketWithTagCheck redSocket;
    public SocketWithTagCheck yellowSocket;

    private AudioSource audioSource;
    public AudioClip audioClip;

    private bool isPuzzleSolved = false;

    public GameObject door;

    public GameObject spotLight;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if(greenSocket != null)
        {
            isGreenAnubisInPlace = greenSocket.GetComponent<SocketWithTagCheck>().isStatueInPlace;
        }
        

        if (isGreenAnubisInPlace)
        {

            greenAnubis.GetComponent<XRGrabInteractable>().enabled = false;
            // greenSocket.socketActive = false;
        }

        if (redSocket != null)
        {
            isRedAnubisInPlace = redSocket.GetComponent<SocketWithTagCheck>().isStatueInPlace;
        }


        if (isRedAnubisInPlace)
        {
            redAnubis.GetComponent<XRGrabInteractable>().enabled = false;
            // redSocket.socketActive = false;
        }

        if (yellowSocket != null)
        {
            isYellowAnubisInPlace = yellowSocket.GetComponent<SocketWithTagCheck>().isStatueInPlace;
        }


        if (isYellowAnubisInPlace)
        {
            yellowAnubis.GetComponent<XRGrabInteractable>().enabled = false;
            // yellowSocket.socketActive = false;
        }

        if (isGreenAnubisInPlace && isRedAnubisInPlace && isYellowAnubisInPlace)
        {
            if(!isPuzzleSolved)
            {
                Debug.Log("PUZZLE 2 SOLVED!");

                audioSource.PlayOneShot(audioClip);

                door.SetActive(false);

                spotLight.SetActive(true);

                isPuzzleSolved = true;
            }
            
        }
    }
}
