using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Clickable))]
public class ExpansionArea : MonoBehaviour
{
    public event UnityAction<ExpansionArea> Clicked;

    private Renderer _renderer;
    private Clickable _interactable;
    private Direction _direction;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _interactable = GetComponent<Clickable>();
    }

    private void OnEnable()
    {
        _interactable.Cliked += TryBuy;
    }

    private void OnDisable()
    {
        _interactable.Cliked -= TryBuy;
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

    private void TryBuy()
    {
        Clicked?.Invoke(this);
    }
}
