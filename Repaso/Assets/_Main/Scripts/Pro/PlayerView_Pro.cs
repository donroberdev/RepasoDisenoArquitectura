using UnityEngine;

public class PlayerView_Pro : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private Color airColor = Color.yellow;

    private Color _originalColor;

    private void Awake()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        _originalColor = rend.material.color;
    }

    public void SetAirState(bool grounded)
    {
        rend.material.color = grounded ? _originalColor : airColor;
    }
}
