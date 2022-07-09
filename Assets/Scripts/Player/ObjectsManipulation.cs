using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class ObjectsManipulation : MonoBehaviour
{
    [SerializeField] private float _maxDistance;
    [SerializeField] private Interaction _interaction;
    [SerializeField] private Camera _camera;

    [SerializeField] private GameObject _testPrefab;

    private GameObject _obj;
    private BoxCollider _objCollider;

    private void OnEnable()
    {
        _interaction.Clicked += TryPlaceObject;
        _interaction.ClickCanceled += ResetObject;
    }

    private void OnDisable()
    {
        _interaction.Clicked -= TryPlaceObject;
        _interaction.ClickCanceled -= ResetObject;
    }

    private void FixedUpdate()
    {
        if (_obj == null)
        {
            return;
        }

        Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, _maxDistance);

        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Ground ground))
        {
            Vector3 offset = Vector3.up * _obj.transform.localScale.y / 2f;
            _obj.transform.position = hit.point + offset;
        }
    }

    public void TakeObject(GameObject obj)
    {
        if (_obj != null)
        {
            return;
        }

        _obj = Instantiate(obj, transform.position, Quaternion.identity, transform);

        if (_obj.TryGetComponent(out _objCollider))
        {
            _objCollider.enabled = false;
        }
        else
        {
            ResetObject();
        }
    }

    public void TryPlaceObject(Clickable clickable)
    {
        if (_obj == null)
        {
            return;
        }

        if (clickable.gameObject.TryGetComponent(out Ground ground))
        {
            _obj.transform.SetParent(null);
            _objCollider.enabled = true;
            _obj = null;
        }
    }

    private void ResetObject()
    {
        Destroy(_obj);
        _obj = null;
    }
}
