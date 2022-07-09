using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract string GetInfo();
    public abstract void ShowInteraction();
    public abstract void HideInteraction();
}
