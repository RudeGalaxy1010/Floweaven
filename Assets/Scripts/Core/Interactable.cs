using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Interactable : MonoBehaviour
{
    public event UnityAction MouseEnter;
    public event UnityAction MouseExit;
    public event UnityAction MouseDown;

    private void OnMouseEnter()
    {
        MouseEnter?.Invoke();
    }

    private void OnMouseExit()
    {
        MouseExit?.Invoke();
    }

    private void OnMouseDown()
    {
        MouseDown?.Invoke();
    }
}
