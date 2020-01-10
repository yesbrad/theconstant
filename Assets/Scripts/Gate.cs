using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gate : Interactable
{
    public ItemIDs activationItem;

    Collider collider;
    Vector3 openAngle;
    bool isOpen;

    void Start()
    {
        collider = GetComponent<Collider>();
    }

    void Update()
    {
        if (isOpen) // TODO: Stop updating if its fully open
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(openAngle), Time.deltaTime * GameManager.globalVariables.gateOpenSpeed);
        }
    }

    public override void Interact()
    {
        base.Interact();

        if (GameManager.instance.HasItem(activationItem))
        {
            OpenGate();
        }
    }

    public void OpenGate()
    {
        if(!isOpen)
        {
            openAngle = transform.rotation.eulerAngles;
            openAngle.y += 90;
            isOpen = true;
            collider.enabled = false;
        }
    }
}
