using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Camera))]
public class Interaction : MonoBehaviour
{
    public event UnityAction<Interactable> IntereactionStarted;
    public event UnityAction InteractionEnded;
    public event UnityAction<Clickable> Clicked;
    public event UnityAction ClickCanceled;

    [SerializeField] private float _maxDistance;

    private Camera _camera;
    private Interactable _currentObject;
    private bool _isEnabled;

    private void Start()
    {
        _camera = GetComponent<Camera>();
        _isEnabled = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, _maxDistance);

            if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Clickable clickable))
            {
                clickable.Click();
                Clicked?.Invoke(clickable);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            ClickCanceled?.Invoke();
        }
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
        IntereactionStarted?.Invoke(interactable);
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
