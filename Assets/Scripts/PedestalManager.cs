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

   // [SerializeField]
   // private Transform greenPedestalOrigin;

    [SerializeField]
    private Transform greenPedestalRaisedPos;

    [SerializeField]
    private Transform greenTransparentPedestalPos;


    [SerializeField]
    private GameObject greenTransparentPedestal;



    [SerializeField]
    private GameObject redPedestal;


    [SerializeField]
    private Transform redPedestalRaisedPos;

    [SerializeField]
    private Transform redTransparentPedestalPos;

    [SerializeField]
    private GameObject redTransparentPedestal;

   

    [SerializeField]
    private GameObject yellowPedestal;


    [SerializeField]
    private Transform yellowPedestalRaisedPos;

    [SerializeField]
    private Transform yellowTransparentPedestalPos;

    [SerializeField]
    private GameObject yellowTransparentPedestal;

    private GameObject activatedGreenTransparentPedestal;
    private GameObject activatedYellowTransparentPedestal;
    private GameObject activatedRedTransparentPedestal;

    private XRSocketInteractor greenSocketInteractor;
    private XRSocketInteractor redSocketInteractor;
    private XRSocketInteractor yellowSocketInteractor;

    public bool isGreen01Active = false;
    public bool isGreen02Active = false;

    public bool isRed01Active = false;
    public bool isRed02Active = false;

    public bool isYellow01Active = false;
    public bool isYellow02Active = false;

    bool isGreenPedestalInstantiated = false;
    bool isRedPedestalInstantiated = false;
    bool isYellowPedestalInstantiated = false;

    bool isGreenTransparentInstantiated = false;
    bool isRedTransparentInstantiated = false;
    bool isYellowTransparentInstantiated = false;

    StatueCompletionManager statueCompletionManager;

    private void Awake()
    {

        // Subscribe to the didConnectToRoom event
        //_realtime.didConnectToRoom += DidConnectToRoom;
    }
    // Start is called before the first frame update
    private void DidConnectToRoom(Realtime realtime)
    {
        // instatiating the 'activators' ie the spheres with which to interact
        // instatiating so that they can me made into realtime components by normal (if understood correctly)
        //greenPedestal = Realtime.Instantiate(greenPedestal.name);
       
        //greenPedestal.transform.position = greenPedestalOrigin.position;
        //greenPedestal.gameObject.GetComponent<RaisePedestal>().pedestalRaisedPosition = greenPedestalRaisedPos;
        //greenPedestal.transform.SetParent(greenPedestalRaisedPos);
        //greenPedestal.SetActive(false);

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


        statueCompletionManager = GetComponent<StatueCompletionManager>();


    }

    private void Update()
    {
        // checking if one activator is being interacted with and therefore showing the transparent pedestal
        if (isGreen01Active || isGreen02Active) // || isGreen02Active && !isGreen01Active)
        {
            if(!isGreenTransparentInstantiated)
                activatedGreenTransparentPedestal = Realtime.Instantiate(greenTransparentPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });
            //activatedGreenPedestal.transform.Translate(greenTransparentPedestalPos.localPosition);
            // activatedGreenPedestal.transform.SetParent(greenTransparentPedestalPos);
            activatedGreenTransparentPedestal.GetComponent<SyncPosition>().objectToFollow = greenTransparentPedestalPos;
            isGreenTransparentInstantiated = true;
            //greenTransparentPedestal.SetActive(true);

            

           // RealtimeView _realtimeview = activatedGreenTransparentPedestal.GetComponent<RealtimeView>();
           // _realtimeview.RequestOwnership();
        }
       // else
       // {
        //    if (activatedGreenTransparentPedestal != null)
       //         activatedGreenTransparentPedestal.SetActive(false);

       // }

        if (isRed01Active || isRed02Active) // || isRed02Active && !isRed01Active)
        {
            if (!isRedTransparentInstantiated)
                activatedRedTransparentPedestal = Realtime.Instantiate(redTransparentPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });

            activatedRedTransparentPedestal.GetComponent<SyncPosition>().objectToFollow = redTransparentPedestalPos;
            isRedTransparentInstantiated = true;
            //redTransparentPedestal.SetActive(true);

           // RealtimeView _realtimeview = activatedRedTransparentPedestal.GetComponent<RealtimeView>();
           // _realtimeview.RequestOwnership();
        }
       // else
       // {
        //    if (activatedRedTransparentPedestal != null)
        //        activatedRedTransparentPedestal.SetActive(false);

       // }

        if (isYellow01Active || isYellow02Active) // || isYellow02Active && !isYellow01Active)
        {
            if (!isYellowTransparentInstantiated)
            {

           
                activatedYellowTransparentPedestal = Realtime.Instantiate(yellowTransparentPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });

            activatedYellowTransparentPedestal.GetComponent<SyncPosition>().objectToFollow = yellowTransparentPedestalPos;
            isYellowTransparentInstantiated = true;
                //redTransparentPedestal.SetActive(true);
            }

            // RealtimeView _realtimeview = activatedYellowTransparentPedestal.GetComponent<RealtimeView>();
            // _realtimeview.RequestOwnership();
        }
       // else
        //{
        //    if (activatedYellowTransparentPedestal != null)
         //       activatedYellowTransparentPedestal.SetActive(false);

        //}
        // the below is monitoring the simultaneous activation of the two same-colure activators
        // ie if they are both true they give the hint of which pedestal relates to which statue color
        // (which statue should be brought onto which pedestal)

        if (isGreen01Active && isGreen02Active && isGreenTransparentInstantiated)
        {
            if(greenPedestal != null && !isGreenPedestalInstantiated)
            {
                greenPedestal = Realtime.Instantiate(greenPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });

                Debug.Log("Instantiating green pedestal!");

                isGreenPedestalInstantiated = true;
                //greenPedestal.transform.position = greenPedestalOrigin.position;
                //greenPedestal.gameObject.GetComponent<RaisePedestal>().pedestalRaisedPosition = greenPedestalRaisedPos;
                greenPedestal.GetComponent<SyncPosition>().objectToFollow = greenPedestalRaisedPos;
                //greenPedestal.transform.SetParent(greenPedestalRaisedPos);

                greenPedestal.SetActive(true);

                statueCompletionManager.greenSocket = greenPedestal.GetComponentInChildren<SocketWithTagCheck>();

                //RealtimeView _realtimeview = greenPedestal.GetComponent<RealtimeView>();
                //_realtimeview.RequestOwnership();


                //greenPedestal.GetComponent<RaisePedestal>().MakePedestalAppear();//.MoveUp();
                // greenPedestal.GetComponent<MeshRenderer>().material = greenPedestalActiveMaterial;
                greenSocketInteractor.socketActive = true;

            }
            
        }
        
        if(isRed01Active && isRed02Active && isRedTransparentInstantiated)
        {

            if (redPedestal != null && !isRedPedestalInstantiated)
            {
                redPedestal = Realtime.Instantiate(redPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });

                

                    Debug.Log("Instantiating red pedestal!");

                isRedPedestalInstantiated = true;
                //greenPedestal.transform.position = greenPedestalOrigin.position;
                //greenPedestal.gameObject.GetComponent<RaisePedestal>().pedestalRaisedPosition = greenPedestalRaisedPos;
                redPedestal.GetComponent<SyncPosition>().objectToFollow = redPedestalRaisedPos;
                //greenPedestal.transform.SetParent(greenPedestalRaisedPos);

                redPedestal.SetActive(true);

                statueCompletionManager.redSocket = redPedestal.GetComponentInChildren<SocketWithTagCheck>();

                // RealtimeView _realtimeview = redPedestal.GetComponent<RealtimeView>();
                // _realtimeview.RequestOwnership();


                //greenPedestal.GetComponent<RaisePedestal>().MakePedestalAppear();//.MoveUp();
                // greenPedestal.GetComponent<MeshRenderer>().material = greenPedestalActiveMaterial;
                redSocketInteractor.socketActive = true;

            }
        }
        
        if (isYellow01Active && isYellow02Active && isYellowTransparentInstantiated)
        {
            if (yellowPedestal != null && !isYellowPedestalInstantiated)
            {
                yellowPedestal = Realtime.Instantiate(yellowPedestal.name, new Realtime.InstantiateOptions
                {
                    ownedByClient = true,
                    preventOwnershipTakeover = true,
                    destroyWhenOwnerLeaves = true,
                    destroyWhenLastClientLeaves = true,

                });

                Debug.Log("Instantiating yellow pedestal!");

                isYellowPedestalInstantiated = true;
                //greenPedestal.transform.position = greenPedestalOrigin.position;
                //greenPedestal.gameObject.GetComponent<RaisePedestal>().pedestalRaisedPosition = greenPedestalRaisedPos;
                yellowPedestal.GetComponent<SyncPosition>().objectToFollow = yellowPedestalRaisedPos;
                //greenPedestal.transform.SetParent(greenPedestalRaisedPos);

                yellowPedestal.SetActive(true);

                statueCompletionManager.yellowSocket = yellowPedestal.GetComponentInChildren<SocketWithTagCheck>();


                // RealtimeView _realtimeview = yellowPedestal.GetComponent<RealtimeView>();
                // _realtimeview.RequestOwnership();

                //yellowPedestal.GetComponent<MeshRenderer>().material = yellowPedestalActiveMaterial;
                // yellowPedestal.GetComponent<RaisePedestal>().MoveUp();
                yellowSocketInteractor.socketActive = true;
            }
            
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


        /*
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
        */
    }


}
