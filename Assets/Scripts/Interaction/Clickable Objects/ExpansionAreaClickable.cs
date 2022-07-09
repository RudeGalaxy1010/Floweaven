using UnityEngine;

[RequireComponent(typeof(ExpansionArea))]
public class ExpansionAreaClickable : Clickable
{
    private ExpansionArea _expansionArea;

    private void Awake()
    {
        _expansionArea = GetComponent<ExpansionArea>();
    }

    public override void Click()
    {
        _expansionArea.TryBuy();
    }
}
