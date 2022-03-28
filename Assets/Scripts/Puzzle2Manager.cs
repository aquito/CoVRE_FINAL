using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Puzzle2Manager : MonoBehaviour
{
    public Realtime _realtime; // Wire this up in the Unity Editor

    [SerializeField]
    GameObject greenActivator; // the sphere prefabs

    [SerializeField]
    GameObject redActivator;

    [SerializeField]
    GameObject yellowActivator;

    [SerializeField]
    Transform greenActivator01Slot; // where the prefabs will be instantiated in floor 2
    [SerializeField]
    Transform greenActivator02Slot;

    [SerializeField]
    Transform redActivator01Slot;
    [SerializeField]
    Transform redActivator02Slot;

    [SerializeField]
    Transform yellowActivator01Slot;
    [SerializeField]
    Transform yellowActivator02Slot;

    [SerializeField]
    PedestalManager pedestalManager;

    private GameObject green01;
    private GameObject green02;

    private GameObject red01;
    private GameObject red02;

    private GameObject yellow01;
    private GameObject yellow02;

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
        green01 = Realtime.Instantiate(greenActivator.name);
        green01.transform.Translate(greenActivator01Slot.position);
        green01.transform.SetParent(greenActivator01Slot);

        green02 = Realtime.Instantiate(greenActivator.name);
        green02.transform.Translate(greenActivator02Slot.position);
        green02.transform.SetParent(greenActivator02Slot);

        red01 = Realtime.Instantiate(redActivator.name, ownedByClient: true);
        red01.transform.Translate(redActivator01Slot.position);
        red01.transform.SetParent(redActivator01Slot);

        red02 = Realtime.Instantiate(redActivator.name, ownedByClient: true);
        red02.transform.Translate(redActivator02Slot.position);
        red02.transform.SetParent(redActivator02Slot);

        yellow01 = Realtime.Instantiate(yellowActivator.name, ownedByClient: true);
        yellow01.transform.Translate(yellowActivator01Slot.position);
        yellow01.transform.SetParent(yellowActivator01Slot);

        yellow02 = Realtime.Instantiate(yellowActivator.name, ownedByClient: true);
        yellow02.transform.Translate(yellowActivator02Slot.position);
        yellow02.transform.SetParent(yellowActivator02Slot);

    }

    // Update is called once per frame
    void Update()
    {
        //  monitoring of the individual two activators re pedestal
       

        if(green01 != null && green02 != null)
        {
            if(green01.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isGreen01Active = true;

            }
            else
            {
                //pedestalManager.GetComponent<PedestalManager>().isGreen01Active = false;
            }

            if (green02.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isGreen02Active = true;

            }
            else
            {
                //pedestalManager.GetComponent<PedestalManager>().isGreen02Active = false;
            }

        }

        if (red01 != null && red02 != null)
        {
            if (red01.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isRed01Active = true;

            }

            if (red02.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isRed02Active = true;

            }

        }

        if (yellow01 != null && yellow02 != null)
        {
            if (yellow01.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isYellow01Active = true;

            }

            if (yellow02.GetComponent<SwitchActivatorMaterial>().isSwitchActive)
            {
                pedestalManager.GetComponent<PedestalManager>().isYellow02Active = true;

            }

        }

        /*
        //For Debug purposes
        if (Input.GetKeyDown(KeyCode.G))
        {

            //green01.GetComponent<SwitchActivatorMaterial>().Switch();
            // green02.GetComponent<SwitchActivatorMaterial>().Switch();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            red01.GetComponent<SwitchActivatorMaterial>().Switch();
            red02.GetComponent<SwitchActivatorMaterial>().Switch();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            yellow01.GetComponent<SwitchActivatorMaterial>().Switch();
            yellow02.GetComponent<SwitchActivatorMaterial>().Switch();
        }
        */

    }

    
}
