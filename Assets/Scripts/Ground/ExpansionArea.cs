using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Interactable))]
public class ExpansionArea : MonoBehaviour
{
    public event UnityAction<ExpansionArea> Clicked;

    private Renderer _renderer;
    private Interactable _interactable;
    private Direction _direction;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _interactable = GetComponent<Interactable>();
    }

    private void OnEnable()
    {
        _interactable.MouseEnter += ShowInfo;
        _interactable.MouseExit += HideInfo;
        _interactable.MouseDown += TryBuy;
    }

    private void OnDisable()
    {
        _interactable.MouseEnter -= ShowInfo;
        _interactable.MouseExit -= HideInfo;
        _interactable.MouseDown -= TryBuy;
    }

    public Direction Direction => _direction;

    public void Init(Direction direction)
    {
        _direction = direction;
    }

    public int GetCost()
    {
        int size = -1;

        if (transform.localScale.x > 1)
        {
            size = (int)transform.localScale.x;
        }
        else
        {
            size = (int)transform.localScale.z;
        }

        return size * MoneyConstants.CostPerExpansionCell;
    }

    private void ShowInfo()
    {
        Color color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0.5f);
        _renderer.material.color = color;
    }

    private void HideInfo()
    {
        Color color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0);
        _renderer.material.color = color;
    }

    private void TryBuy()
    {
        Clicked?.Invoke(this);
    }
}
