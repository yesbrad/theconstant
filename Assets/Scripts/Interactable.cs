using UnityEngine;

public class Interactable : MonoBehaviour
{
    public virtual void Interact ()
    {
    }

    public virtual void Drop()
    {
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.matrix = transform.localToWorldMatrix;
        Gizmos.DrawSphere(Vector3.up * 3, 1);
    }
}