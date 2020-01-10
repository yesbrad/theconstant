using UnityEngine;

public class Key : Interactable
{
    [SerializeField] ItemIDs grantItem;

    public override void Interact()
    {
        base.Interact();
        GameManager.instance.AddItem(grantItem);
        Destroy(this.gameObject);
    }
}
