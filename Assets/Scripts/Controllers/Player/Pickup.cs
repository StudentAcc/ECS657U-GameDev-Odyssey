using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickUpRange = 5;
    public float moveForce = 250;
    public Transform holdParent;
    private GameObject heldObj;
    bool pickup;
    public bool pickedup;
    PlayerInputActions controls;

    void Awake() {
        controls = new PlayerInputActions();
    }

    void Update()
    {
        // if (controls.Player.Pickup.triggered
        if(pickup)
        {
            if (heldObj == null)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, pickUpRange))
                {
                    PickupObject(hit.transform.gameObject);
                }
            }
            else
            {
                DropObject();
            }
            pickup = false;
        }

        if (heldObj != null)
        {
            MoveObject(); 
        }
    }

    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f)
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * moveForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        if (pickObj.GetComponent<Rigidbody>() && pickObj.tag == "ShipPart") 
        {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
            pickedup = true;
        }
    }

    void DropObject()
    {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1;

        heldObj.transform.parent = null;
        heldObj = null;
        pickedup = false;
    }

    public void OnPickupPressed()
    {
        pickup = true;
    }
    
    // private void OnEnable() {
    //     controls.Player.Pickup.Enable();
    // }

    // private void OnDisable() {
    //     controls.Player.Pickup.Disable();
    // }

}
