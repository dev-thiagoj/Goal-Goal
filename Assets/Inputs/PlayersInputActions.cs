//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Inputs/PlayersInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayersInputActions : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayersInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayersInputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""047c8470-a9ad-4cb6-b0e0-61e4a6780b6a"",
            ""actions"": [
                {
                    ""name"": ""Move_Player01"",
                    ""type"": ""Value"",
                    ""id"": ""4cbdcac8-4bfc-433e-a55e-a08abfa3b831"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Move_Player02"",
                    ""type"": ""Value"",
                    ""id"": ""d89b9ed7-2e25-4315-a6f5-779b51d3cd06"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""58ebf9fc-af05-49f4-befa-4a134d8d75b9"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Player01"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71690523-a223-4335-9b92-b93d43ae11c6"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move_Player02"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move_Player01 = m_Gameplay.FindAction("Move_Player01", throwIfNotFound: true);
        m_Gameplay_Move_Player02 = m_Gameplay.FindAction("Move_Player02", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }
    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }
    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move_Player01;
    private readonly InputAction m_Gameplay_Move_Player02;
    public struct GameplayActions
    {
        private @PlayersInputActions m_Wrapper;
        public GameplayActions(@PlayersInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move_Player01 => m_Wrapper.m_Gameplay_Move_Player01;
        public InputAction @Move_Player02 => m_Wrapper.m_Gameplay_Move_Player02;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move_Player01.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player01;
                @Move_Player01.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player01;
                @Move_Player01.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player01;
                @Move_Player02.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player02;
                @Move_Player02.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player02;
                @Move_Player02.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove_Player02;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move_Player01.started += instance.OnMove_Player01;
                @Move_Player01.performed += instance.OnMove_Player01;
                @Move_Player01.canceled += instance.OnMove_Player01;
                @Move_Player02.started += instance.OnMove_Player02;
                @Move_Player02.performed += instance.OnMove_Player02;
                @Move_Player02.canceled += instance.OnMove_Player02;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMove_Player01(InputAction.CallbackContext context);
        void OnMove_Player02(InputAction.CallbackContext context);
    }
}
