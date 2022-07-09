using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Clickable))]
public class ExpansionArea : MonoBehaviour
{
    public event UnityAction<ExpansionArea> TriedToBuy;

    private Direction _direction;

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

    public void TryBuy()
    {
        TriedToBuy?.Invoke(this);
    }
}
