using UnityEngine;

[RequireComponent(typeof(ExpansionArea))]
public class ExpansionAreaInteraction : Interactable
{
    private ExpansionArea _expansionArea;
    private Renderer _renderer;

    private void Awake()
    {
        _expansionArea = GetComponent<ExpansionArea>();
        _renderer = GetComponent<Renderer>();
    }

    public override string GetInfo()
    {
        return $"Expand for {_expansionArea.GetCost()}";
    }

    public override void HideInteraction()
    {
        Color color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0);
        _renderer.material.color = color;
    }

    public override void ShowInteraction()
    {
        Color color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0.5f);
        _renderer.material.color = color;
    }
}
