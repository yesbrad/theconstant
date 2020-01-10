using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookItem : Interactable
{
    bool isLooking;

    Vector3 pickupPosition;
    Vector3 pickupRotation;
    Vector3 rot;

    void Start()
    {
        pickupPosition = transform.position;
    }

    public void Update ()
    {
        if(isLooking)
        {
            transform.position = Vector3.Lerp(transform.position, PlayerConroller.instance.LookAtSocket.position, Time.deltaTime * GameManager.globalVariables.itemLookAtSpeed);
            rot.x += -Input.GetAxis("Mouse Y");
            rot.y += Input.GetAxis("Mouse X");
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pickupPosition, Time.deltaTime * GameManager.globalVariables.itemLookAtSpeed);
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(rot), Time.deltaTime * GameManager.globalVariables.itemLookAtRotateSpeed);
    }

    public override void Interact()
    {
        base.Interact();
        PlayerConroller.instance.SetLookAtObject(this.transform);
        pickupPosition = transform.position;
        pickupRotation = transform.rotation.eulerAngles;
        isLooking = true;
    }

    public override void Drop()
    {
        base.Drop();
        PlayerConroller.instance.SetLookAtObject(null);
        rot = pickupRotation;
        isLooking = false;
    }
}
