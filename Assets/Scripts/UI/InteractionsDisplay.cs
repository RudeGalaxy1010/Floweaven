using TMPro;
using UnityEngine;

public class InteractionsDisplay : MonoBehaviour
{
    [SerializeField] private Interaction _interaction;
    [SerializeField] private TMP_Text _text;

    private void Awake()
    {
        ResetText();
    }

    private void OnEnable()
    {
        _interaction.IntereactionStarted += SetText;
        _interaction.InteractionEnded += ResetText;
    }

    private void OnDisable()
    {
        _interaction.IntereactionStarted -= SetText;
        _interaction.InteractionEnded -= ResetText;
    }

    private void SetText(string message)
    {
        _text.text = message;
    }

    private void ResetText()
    {
        _text.text = "";
    }
}
