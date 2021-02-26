// GENERATED AUTOMATICALLY FROM 'Assets/InputAction/PlayerInputAction.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputAction : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputAction()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputAction"",
    ""maps"": [
        {
            ""name"": ""PlayerInputActionMap"",
            ""id"": ""78a19fd5-8cbd-4a41-ab23-df06e97cce7e"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""ec36e4fb-b26e-4075-92af-c52c5dfccad2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopMoving"",
                    ""type"": ""Button"",
                    ""id"": ""6e9bbc6a-6c32-4b4f-87d1-fd24553d6a22"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""ffeb790a-e2e9-4065-b0ed-db514405c572"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""StopRotating"",
                    ""type"": ""Button"",
                    ""id"": ""d655f287-a440-4295-9994-69e0715b1fdb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RotateCamera"",
                    ""type"": ""Value"",
                    ""id"": ""a2a16dea-7c5b-41a8-b3cc-f981d6a811c6"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""94f258da-56d9-4df2-b3eb-e6b756874131"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b78a1b06-64c7-48c2-8c74-91fc367d187f"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateCamera"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a26a7ea0-9526-45e4-8c8b-9d78feee2454"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b10ef712-6872-44b8-a784-25d0702f04b6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d8ee2b75-dd6e-4f4d-9d4a-19033bb1a935"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopMoving"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2bcd786d-5a66-4e3b-86f5-7848a67b9af6"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""200876d4-68ec-4bd8-adc4-d7d3b86bbb59"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": ""Press(behavior=1)"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""StopRotating"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // PlayerInputActionMap
        m_PlayerInputActionMap = asset.FindActionMap("PlayerInputActionMap", throwIfNotFound: true);
        m_PlayerInputActionMap_Move = m_PlayerInputActionMap.FindAction("Move", throwIfNotFound: true);
        m_PlayerInputActionMap_StopMoving = m_PlayerInputActionMap.FindAction("StopMoving", throwIfNotFound: true);
        m_PlayerInputActionMap_Rotate = m_PlayerInputActionMap.FindAction("Rotate", throwIfNotFound: true);
        m_PlayerInputActionMap_StopRotating = m_PlayerInputActionMap.FindAction("StopRotating", throwIfNotFound: true);
        m_PlayerInputActionMap_RotateCamera = m_PlayerInputActionMap.FindAction("RotateCamera", throwIfNotFound: true);
        m_PlayerInputActionMap_Attack = m_PlayerInputActionMap.FindAction("Attack", throwIfNotFound: true);
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

    // PlayerInputActionMap
    private readonly InputActionMap m_PlayerInputActionMap;
    private IPlayerInputActionMapActions m_PlayerInputActionMapActionsCallbackInterface;
    private readonly InputAction m_PlayerInputActionMap_Move;
    private readonly InputAction m_PlayerInputActionMap_StopMoving;
    private readonly InputAction m_PlayerInputActionMap_Rotate;
    private readonly InputAction m_PlayerInputActionMap_StopRotating;
    private readonly InputAction m_PlayerInputActionMap_RotateCamera;
    private readonly InputAction m_PlayerInputActionMap_Attack;
    public struct PlayerInputActionMapActions
    {
        private @PlayerInputAction m_Wrapper;
        public PlayerInputActionMapActions(@PlayerInputAction wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_PlayerInputActionMap_Move;
        public InputAction @StopMoving => m_Wrapper.m_PlayerInputActionMap_StopMoving;
        public InputAction @Rotate => m_Wrapper.m_PlayerInputActionMap_Rotate;
        public InputAction @StopRotating => m_Wrapper.m_PlayerInputActionMap_StopRotating;
        public InputAction @RotateCamera => m_Wrapper.m_PlayerInputActionMap_RotateCamera;
        public InputAction @Attack => m_Wrapper.m_PlayerInputActionMap_Attack;
        public InputActionMap Get() { return m_Wrapper.m_PlayerInputActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerInputActionMapActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerInputActionMapActions instance)
        {
            if (m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnMove;
                @StopMoving.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopMoving;
                @StopMoving.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopMoving;
                @StopMoving.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopMoving;
                @Rotate.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotate;
                @Rotate.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotate;
                @Rotate.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotate;
                @StopRotating.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopRotating;
                @StopRotating.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopRotating;
                @StopRotating.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnStopRotating;
                @RotateCamera.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotateCamera;
                @RotateCamera.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnRotateCamera;
                @Attack.started -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnAttack;
                @Attack.performed -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnAttack;
                @Attack.canceled -= m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface.OnAttack;
            }
            m_Wrapper.m_PlayerInputActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @StopMoving.started += instance.OnStopMoving;
                @StopMoving.performed += instance.OnStopMoving;
                @StopMoving.canceled += instance.OnStopMoving;
                @Rotate.started += instance.OnRotate;
                @Rotate.performed += instance.OnRotate;
                @Rotate.canceled += instance.OnRotate;
                @StopRotating.started += instance.OnStopRotating;
                @StopRotating.performed += instance.OnStopRotating;
                @StopRotating.canceled += instance.OnStopRotating;
                @RotateCamera.started += instance.OnRotateCamera;
                @RotateCamera.performed += instance.OnRotateCamera;
                @RotateCamera.canceled += instance.OnRotateCamera;
                @Attack.started += instance.OnAttack;
                @Attack.performed += instance.OnAttack;
                @Attack.canceled += instance.OnAttack;
            }
        }
    }
    public PlayerInputActionMapActions @PlayerInputActionMap => new PlayerInputActionMapActions(this);
    public interface IPlayerInputActionMapActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnStopMoving(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
        void OnStopRotating(InputAction.CallbackContext context);
        void OnRotateCamera(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
    }
}
