using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Renderer rend;
    [SerializeField] Color airColor = Color.yellow;

    Color originalColor;

    void Awake()
    {
        if (rend == null) rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    public void SetAirState(bool isGrounded)
    {
        rend.material.color = isGrounded ? originalColor : airColor;
    }
}
