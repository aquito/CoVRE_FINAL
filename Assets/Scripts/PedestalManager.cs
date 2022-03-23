using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Normal.Realtime;

public class PedestalManager : MonoBehaviour
{

    // this script oversees the completion of the puzzle whereas Puzzle2Manager is managing the activator spheres
    // and the individual color-coded puzzles
    // it might be though that some of the things this currently has needs to be moved into the Puzzle2Manager 
    // and this just oversees the completion

    public Realtime _realtime; // Wire this up in the Unity Editor

    [SerializeField]
    private GameObject greenPedestal;

    [SerializeField]
    private Transform greenPedestalOrigin;

    [SerializeField]
    private Transform greenPedestalRaisedPos;

    [SerializeField]
    private Transform greenTransparentPedestalPos;


    [SerializeField]
    private GameObject greenTransparentPedestal;



    [SerializeField]
    private GameObject redPedestal;

    [SerializeField]
    private GameObject redTransparentPedestal;

   

    [SerializeField]
    private GameObject yellowPedestal;

    [SerializeField]
    private GameObject yellowTransparentPedestal;

    private GameObject activatedGreenPedestal;

    private XRSocketInteractor greenSocketInteractor;
    private XRSocketInteractor redSocketInteractor;
    private XRSocketInteractor yellowSocketInteractor;

    public bool isGreen01Active;
    public bool isGreen02Active;

    public bool isRed01Active;
    public bool isRed02Active;

    public bool isYellow01Active;
    public bool isYellow02Active;

    bool isGreenTransparentInstantiated = false;

    private void Awake()
    {

        // Subscribe to the didConnectToRoom event
        _realtime.didConnectToRoom += DidConnectToRoom;
    }
    // Start is called before the first frame update
    private void DidConnectToRoom(Realtime realtime)
    {
        // instatiating the 'activators' ie the spheres with which to interact
        // instatiating so that they can me made into realtime components by normal (if understood correctly)
        greenPedestal = Realtime.Instantiate(greenPedestal.name, Realtime.InstantiateOptions.defaults);
        greenPedestal.transform.SetParent(greenPedestalOrigin);
        //greenPedestal.transform.position = greenPedestalOrigin.position;
        greenPedestal.gameObject.GetComponent<RaisePedestal>().pedestalRaisedPosition = greenPedestalRaisedPos;

        //greenTransparentPedestal



    }

    private void Start()
    {
       // defining these objects so that they can be changed/activated based on player interactions
        //greenPedestalDefaultMaterial = greenPedestal.GetComponent<MeshRenderer>().material;
        greenSocketInteractor = greenPedestal.GetComponentInChildren<XRSocketInteractor>();

       // redPedestalDefaultMaterial = redPedestal.GetComponent<MeshRenderer>().material;
        redSocketInteractor = redPedestal.GetComponentInChildren<XRSocketInteractor>();

       // yellowPedestalDefaultMaterial = yellowPedestal.GetComponent<MeshRenderer>().material;
        yellowSocketInteractor = yellowPedestal.GetComponentInChildren<XRSocketInteractor>();

     

       
    }

    private void Update()
    {
        // checking if one activator is being interacted with and therefore showing the transparent pedestal
        if (isGreen01Active && !isGreen02Active || isGreen02Active && !isGreen01Active)
        {
            if(!isGreenTransparentInstantiated)
            activatedGreenPedestal = Realtime.Instantiate(greenTransparentPedestal.name, ownedByClient: true);
            activatedGreenPedestal.transform.SetParent(greenTransparentPedestalPos);
            isGreenTransparentInstantiated = true;
            //greenTransparentPedestal.SetActive(true);
        }
        else
        {
            if (activatedGreenPedestal != null)
                activatedGreenPedestal.SetActive(false);

        }

        if (isRed01Active && !isRed02Active || isRed02Active && !isRed01Active)
        {
           redTransparentPedestal.SetActive(true);
        }
        else
        {
            redTransparentPedestal.SetActive(false);

        }

        if (isYellow01Active && !isYellow02Active || isYellow02Active && !isYellow01Active)
        {
            yellowTransparentPedestal.SetActive(true);
        }
        else
        {
            yellowTransparentPedestal.SetActive(false);

        }
        // the below is monitoring the simultaneous activation of the two same-colure activators
        // ie if they are both true they give the hint of which pedestal relates to which statue color
        // (which statue should be brought onto which pedestal)

        if (isGreen01Active && isGreen02Active)
        {
            greenPedestal.GetComponent<RaisePedestal>().MoveUp();
           // greenPedestal.GetComponent<MeshRenderer>().material = greenPedestalActiveMaterial;
            greenSocketInteractor.socketActive = true;
        }
        else if(isRed01Active && isRed02Active)
        {
            redPedestal.GetComponent<RaisePedestal>().MoveUp();
            //redPedestal.GetComponent<MeshRenderer>().material = redPedestalActiveMaterial;
            redSocketInteractor.socketActive = true;
        }
        else if(isYellow01Active && isYellow02Active)
        {

            //yellowPedestal.GetComponent<MeshRenderer>().material = yellowPedestalActiveMaterial;
            yellowPedestal.GetComponent<RaisePedestal>().MoveUp();
            yellowSocketInteractor.socketActive = true;
        }

        /*
        else
        {
           greenPedestal.GetComponent<MeshRenderer>().material = greenPedestalDefaultMaterial;
            greenSocketInteractor.socketActive = false;
            redPedestal.GetComponent<MeshRenderer>().material = redPedestalDefaultMaterial;
            redSocketInteractor.socketActive = false;
            yellowPedestal.GetComponent<MeshRenderer>().material = yellowPedestalDefaultMaterial;
            yellowSocketInteractor.socketActive = false;
        }
        */


        //For Debug purposes
        if (Input.GetKeyDown(KeyCode.G))
        {

            greenPedestal.GetComponent<RaisePedestal>().MoveUp();
            
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            redPedestal.GetComponent<RaisePedestal>().MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            yellowPedestal.GetComponent<RaisePedestal>().MoveUp();
        }

    }


}
