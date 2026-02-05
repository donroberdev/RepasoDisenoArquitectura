using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls_Pro : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }

    private readonly InputActionMap m_Player;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Jump;

    public PlayerControls_Pro()
    {
        asset = InputActionAsset.FromJson(@"
        {
            ""name"": ""PlayerControls_Pro"",
            ""maps"": [
                {
                    ""name"": ""Player"",
                    ""actions"": [
                        { ""name"": ""Move"", ""type"": ""Value"", ""expectedControlType"": ""Vector2"" },
                        { ""name"": ""Jump"", ""type"": ""Button"", ""expectedControlType"": ""Button"" }
                    ],
                    ""bindings"": [
                        {
                            ""name"": ""WASD"",
                            ""path"": ""2DVector"",
                            ""action"": ""Move"",
                            ""isComposite"": true
                        },
                        { ""name"": ""up"", ""path"": ""<Keyboard>/w"", ""action"": ""Move"", ""isPartOfComposite"": true },
                        { ""name"": ""down"", ""path"": ""<Keyboard>/s"", ""action"": ""Move"", ""isPartOfComposite"": true },
                        { ""name"": ""left"", ""path"": ""<Keyboard>/a"", ""action"": ""Move"", ""isPartOfComposite"": true },
                        { ""name"": ""right"", ""path"": ""<Keyboard>/d"", ""action"": ""Move"", ""isPartOfComposite"": true },

                        { ""path"": ""<Keyboard>/space"", ""action"": ""Jump"" }
                    ]
                }
            ]
        }");

        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Move = m_Player.FindAction("Move", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    // ✅ CAMBIO CLAVE: ahora es nullable para coincidir con IInputActionCollection.devices
    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set
        {
            // Si viene null, dejamos los devices por defecto (sin filtro explícito)
            if (value.HasValue)
                asset.devices = value.Value;
            else
                asset.devices = default;
        }
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action) => asset.Contains(action);

    public System.Collections.Generic.IEnumerator<InputAction> GetEnumerator() => asset.GetEnumerator();
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

    public void Enable() => asset.Enable();
    public void Disable() => asset.Disable();

    public PlayerActions Player => new PlayerActions(this);

    public struct PlayerActions
    {
        private readonly PlayerControls_Pro m_Wrapper;
        public PlayerActions(PlayerControls_Pro wrapper) { m_Wrapper = wrapper; }

        public InputAction Move => m_Wrapper.m_Player_Move;
        public InputAction Jump => m_Wrapper.m_Player_Jump;

        public InputActionMap Get() => m_Wrapper.m_Player;
        public void Enable() => Get().Enable();
        public void Disable() => Get().Disable();
        public bool enabled => Get().enabled;
    }
}
