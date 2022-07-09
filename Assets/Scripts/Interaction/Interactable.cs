using UnityEngine;

[RequireComponent(typeof(Collider))]
public abstract class Interactable : MonoBehaviour
{
    public abstract string GetInfo();
    public abstract void ShowInteraction();
    public abstract void HideInteraction();
}
