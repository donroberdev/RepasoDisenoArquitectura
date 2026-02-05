using UnityEngine;

public class ColorJumpFX_TeamPro : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    [SerializeField] private Color _jumpColor = Color.yellow;
    [SerializeField] private Color _original = Color.white;

    private void Awake()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        
    }

    public void SetJumpColor()
    {
        rend.material.color = _jumpColor;
    }

    public void RestoreColor()
    {
        rend.material.color = _original;
    }
}
