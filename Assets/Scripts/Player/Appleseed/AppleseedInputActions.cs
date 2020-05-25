// GENERATED AUTOMATICALLY FROM 'Assets/Input/AppleseedInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @AppleseedInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @AppleseedInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""AppleseedInputActions"",
    ""maps"": [
        {
            ""name"": ""AppleseedMain"",
            ""id"": ""aedb78b3-e5fa-40ca-b3c4-e4844281b397"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""9645d725-a9ec-45e6-9ed2-bd9d3d9f615e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""f4aef677-7a58-4242-938a-5e47e00c654b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Mount"",
                    ""type"": ""Button"",
                    ""id"": ""99cd3bd2-b536-49f7-84e8-afc1ebed90bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlayDead"",
                    ""type"": ""Button"",
                    ""id"": ""5787a42e-ea35-4d61-9e6b-ac6c9aab3c44"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""RightStick"",
                    ""id"": ""d074d2d9-32f9-44a5-b907-b4689781d3ed"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""40517298-c9aa-41cf-bce7-e39d381fe199"",
                    ""path"": ""<XInputController>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3f9ec6c0-0750-49f0-b1ac-7706f497a757"",
                    ""path"": ""<XInputController>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4cb35415-8138-4691-91a4-82949c1663c5"",
                    ""path"": ""<XInputController>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""0c8403cc-6e4d-4915-9cd7-7db257398de7"",
                    ""path"": ""<XInputController>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""RightStickGamePad"",
                    ""id"": ""cb912baf-8228-40cb-a0bd-a56d429ac315"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""71ea864a-99d0-4b8c-b3f4-ee1b2cd9f175"",
                    ""path"": ""<Gamepad>/rightStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2d742664-908f-41d2-a46c-6af897d28f89"",
                    ""path"": ""<Gamepad>/rightStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f41f6f2e-2fc8-4031-b9c0-035d13e90b88"",
                    ""path"": ""<Gamepad>/rightStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9345b700-a016-4808-8ab6-e4582ec2348e"",
                    ""path"": ""<Gamepad>/rightStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""ea95d824-25ec-48b7-8211-ff5433759c45"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""efa0f681-c923-4ca7-9c34-7cfd18dedcbb"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5dfdcf8c-c935-4dcf-aa05-9e1b6e9dae23"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1d7c8baf-2924-4bec-9092-08b50a1a81cf"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a7b00f46-571e-4246-925a-a5ed3d4f8936"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7800777e-ac08-49cf-94bf-ea7266a2ce0e"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9e97a2c-dcfb-495d-b0eb-b3729a02f462"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e1f6baa6-1b46-4876-877b-18c151a6aa85"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a0525e11-c264-4763-9f11-0a74c174e27b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Mount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6d05b146-dac6-43d3-b4fc-0538140082a1"",
                    ""path"": ""<XInputController>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayDead"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bb41136d-0944-421e-9f65-268c633a150f"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""PlayDead"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // AppleseedMain
        m_AppleseedMain = asset.FindActionMap("AppleseedMain", throwIfNotFound: true);
        m_AppleseedMain_Movement = m_AppleseedMain.FindAction("Movement", throwIfNotFound: true);
        m_AppleseedMain_Attack = m_AppleseedMain.FindAction("Attack", throwIfNotFound: true);
        m_AppleseedMain_Mount = m_AppleseedMain.FindAction("Mount", throwIfNotFound: true);
        m_AppleseedMain_PlayDead = m_AppleseedMain.FindAction("PlayDead", throwIfNotFound: true);
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

    // AppleseedMain
    private readonly InputActionMap m_AppleseedMain;
    private IAppleseedMainActions m_AppleseedMainActionsCallbackInterface;
    private readonly InputAction m_AppleseedMain_Movement;
    private readonly InputAction m_AppleseedMain_Attack;
    private readonly InputAction m_AppleseedMain_Mount;
    private readonly InputAction m_AppleseedMain_PlayDead;
    public struct AppleseedMainActions
    {
        private @AppleseedInputActions m_Wrapper;
        public AppleseedMainActions(@AppleseedInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_AppleseedMain_Movement;
        public InputAction @Attack => m_Wrapper.m_AppleseedMain_Attack;
        public InputAction @Mount => m_Wrapper.m_AppleseedMain_Mount;
        public InputAction @PlayDead => m_Wrapper.m_AppleseedMain_PlayDead;
        public InputActionMap Get() { return m_Wrapper.m_AppleseedMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(AppleseedMainActions set) { return set.Get(); }
        public void SetCallbacks(IAppleseedMainActions instance)
        {
            if (m_Wrapper.m_AppleseedMainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMovement;
                @Attack.started -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnAttack;
                @Mount.started -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMount;
                @Mount.performed -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMount;
                @Mount.canceled -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnMount;
                @PlayDead.started -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnPlayDead;
                @PlayDead.performed -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnPlayDead;
                @PlayDead.canceled -= m_Wrapper.m_AppleseedMainActionsCallbackInterface.OnPlayDead;
            }
            m_Wrapper.m_AppleseedMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
                @Mount.started += instance.OnMount;
                @Mount.performed += instance.OnMount;
                @Mount.canceled += instance.OnMount;
                @PlayDead.started += instance.OnPlayDead;
                @PlayDead.performed += instance.OnPlayDead;
                @PlayDead.canceled += instance.OnPlayDead;
            }
        }
    }
    public AppleseedMainActions @AppleseedMain => new AppleseedMainActions(this);
    public interface IAppleseedMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnMount(InputAction.CallbackContext context);
        void OnPlayDead(InputAction.CallbackContext context);
    }
}
