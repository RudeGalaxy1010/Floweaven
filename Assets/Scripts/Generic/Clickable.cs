using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class Clickable : MonoBehaviour
{
    public event UnityAction Cliked;

    private void OnMouseDown()
    {
        Cliked?.Invoke();
    }
}
