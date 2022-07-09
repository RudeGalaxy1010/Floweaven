using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class Interaction : MonoBehaviour
{
    public event UnityAction<string> IntereactionStarted;
    public event UnityAction InteractionEnded;

    [SerializeField] private float _maxDistance;

    private Camera _camera;
    private Interactable _currentObject;
    private bool _isEnabled;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _isEnabled = true;
    }

    private void FixedUpdate()
    {
        if (_isEnabled == false)
        {
            return;
        }

        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, _maxDistance);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Interactable interactable))
        {
            if (interactable.Equals(_currentObject))
            {
                return;
            }
            else
            {
                ResetCurrentObject();
            }

            InteractWith(interactable);
        }
        else
        {
            ResetCurrentObject();
        }
    }

    private void InteractWith(Interactable interactable)
    {
        _currentObject = interactable;
        _currentObject.ShowInteraction();
        IntereactionStarted?.Invoke(interactable.GetInfo());
    }

    private void ResetCurrentObject()
    {
        if (_currentObject == null)
        {
            return;
        }

        _currentObject.HideInteraction();
        _currentObject = null;
        InteractionEnded?.Invoke();
    }
}
