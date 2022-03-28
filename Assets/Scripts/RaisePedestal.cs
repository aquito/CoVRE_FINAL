using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class RaisePedestal : MonoBehaviour
{

    private Transform pedestalTransform; // transform of the object
    private Vector3 pedestalYlimit; // the highest position to lift the door to on the y axis
    
    public Transform pedestalRaisedPosition;

    private AudioSource audioSource;

    private bool isPedestalGoodToMove;

    private bool isPedestalRaised;

    public Realtime _realtime; // Wire this up in the Unity Editor

    private void Awake()
    {
        var player = GameObject.Find("Realtime + VR Player");

        _realtime = player.GetComponent<Realtime>();
        // Subscribe to the didConnectToRoom event
        _realtime.didConnectToRoom += DidConnectToRoom;
    }
    // Start is called before the first frame update
    private void DidConnectToRoom(Realtime realtime)
    {
        pedestalYlimit = pedestalRaisedPosition.position;

    }

        private void Start()
    {
        pedestalTransform = GetComponent<Transform>();
        audioSource = GetComponent<AudioSource>();
        pedestalYlimit = pedestalRaisedPosition.position;
        isPedestalGoodToMove = false;
        isPedestalRaised = false;
    }

    private void Update()
    {
        if (isPedestalGoodToMove && !isPedestalRaised)
        {
            
            /*
            // moving up from ground
            if (pedestalTransform.position.y < pedestalYlimit.y)
            {
                pedestalTransform.parent.Translate(0, 1f * Time.deltaTime, 0);
                

            }
            else
            {
                isPedestalRaised = true;
            }
            */

        }
    }

    public void MoveUp()
    {
        if (!isPedestalGoodToMove)
        {
            audioSource.Play();
            isPedestalGoodToMove = true;

            Debug.Log("Starting to move" + pedestalTransform.gameObject.name);
            Debug.Log("Moving it from " + pedestalTransform.position.y + " to " + pedestalYlimit.y);

        }

    }

    public void MakePedestalAppear()
    {
        if (!isPedestalGoodToMove && pedestalTransform != null)
        {
           
            // pedestalTransform.gameObject.SetActive(true);
           // pedestalTransform = GetComponent<Transform>();
            audioSource = GetComponent<AudioSource>();

           
            audioSource.Play();
            isPedestalGoodToMove = true;
        }

            
    }

}
