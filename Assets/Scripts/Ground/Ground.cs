using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] private ExpansionArea _expansionAreaPrefab;
    private ExpansionArea[] _expansionAreas;

    private void Awake()
    {
        CreateExpansionAreas();
    }

    private void OnEnable()
    {
        Subscribe();
    }

    private void OnDisable()
    {
        Unsubscribe();
    }

    private void Subscribe()
    {
        foreach (var area in _expansionAreas)
        {
            area.Clicked += TryBuy;
        }
    }

    private void Unsubscribe()
    {
        foreach (var area in _expansionAreas)
        {
            area.Clicked -= TryBuy;
        }
    }

    private void CreateExpansionAreas()
    {
        _expansionAreas = new ExpansionArea[4];

        Vector3 forwardAreaPosition = transform.position + transform.forward * (transform.localScale.z + _expansionAreaPrefab.transform.localScale.z) / 2f;
        _expansionAreas[0] = Instantiate(_expansionAreaPrefab, forwardAreaPosition, Quaternion.identity);
        _expansionAreas[0].transform.localScale = new Vector3(transform.localScale.x, _expansionAreas[0].transform.localScale.y, _expansionAreas[0].transform.localScale.z);
        _expansionAreas[0].Init(Direction.Forward);

        Vector3 backwardAreaPosition = transform.position - transform.forward * (transform.localScale.z + _expansionAreaPrefab.transform.localScale.z) / 2f;
        _expansionAreas[1] = Instantiate(_expansionAreaPrefab, backwardAreaPosition, Quaternion.identity);
        _expansionAreas[1].transform.localScale = new Vector3(transform.localScale.x, _expansionAreas[1].transform.localScale.y, _expansionAreas[1].transform.localScale.z);
        _expansionAreas[1].Init(Direction.Backward);

        Vector3 rightAreaPosition = transform.position + transform.right * (transform.localScale.x + _expansionAreaPrefab.transform.localScale.x) / 2f;
        _expansionAreas[2] = Instantiate(_expansionAreaPrefab, rightAreaPosition, Quaternion.identity);
        _expansionAreas[2].transform.localScale = new Vector3(_expansionAreas[2].transform.localScale.x, _expansionAreas[2].transform.localScale.y, transform.localScale.z);
        _expansionAreas[2].Init(Direction.Right);

        Vector3 leftAreaPosition = transform.position - transform.right * (transform.localScale.x + _expansionAreaPrefab.transform.localScale.x) / 2f;
        _expansionAreas[3] = Instantiate(_expansionAreaPrefab, leftAreaPosition, Quaternion.identity);
        _expansionAreas[3].transform.localScale = new Vector3(_expansionAreas[3].transform.localScale.x, _expansionAreas[3].transform.localScale.y, transform.localScale.z);
        _expansionAreas[3].Init(Direction.Left);
    }

    private void DestroyExpansionAreas()
    {
        int areasCount = _expansionAreas.Length;
        for (int i = 0; i < areasCount; i++)
        {
            Destroy(_expansionAreas[i].gameObject);
        }
    }

    private void TryBuy(ExpansionArea area)
    {
        // Checks
        Unsubscribe();
        DestroyExpansionAreas();
        Expand(area.Direction);
        CreateExpansionAreas();
        Subscribe();
    }

    private void Expand(Direction direction)
    {
        switch (direction)
        {
            case Direction.Forward:
            case Direction.Backward:
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z + 1);
                break;
            case Direction.Right:
            case Direction.Left:
                transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
                break;
        }

        switch (direction)
        {
            case Direction.Forward:
                transform.position += Vector3.forward * 0.5f;
                break;
            case Direction.Backward:
                transform.position -= Vector3.forward * 0.5f;
                break;
            case Direction.Right:
                transform.position += Vector3.right * 0.5f;
                break;
            case Direction.Left:
                transform.position -= Vector3.right * 0.5f;
                break;
        }
    }
}
