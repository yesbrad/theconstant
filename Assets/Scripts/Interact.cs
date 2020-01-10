using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] float maxDistance = 3;

    RaycastHit hit;
    Interactable currentInteractable;

    void Update()
    {
        UpdateDetection();
    }

    public void UpdateDetection ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {
                Interactable interactable = hit.transform.GetComponent<Interactable>();

                if (interactable)
                {
                    currentInteractable = interactable;
                    interactable.Interact();
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (currentInteractable)
            {
                currentInteractable.Drop();
                currentInteractable = null;
            }
        }
    }

}
