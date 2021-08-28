// GENERATED AUTOMATICALLY FROM 'Assets/Res/InputSystem/PlayerControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""cde37b84-776c-4268-8975-3872cea764ae"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""PassThrough"",
                    ""id"": ""259d121c-8f11-428c-9077-964e7f6b4826"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""de011cf0-9f24-4bdb-bc0a-73851767ba7e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""accf196f-9124-4f73-9986-98f76bf35cff"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""d125911d-7583-438c-93e0-b935d247b925"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Reload"",
                    ""type"": ""Button"",
                    ""id"": ""34ff00f1-3153-45fd-83d0-823966959205"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleWeapon"",
                    ""type"": ""Value"",
                    ""id"": ""58b1d29f-6615-4f28-8a76-a76484efbb36"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""debugMenu"",
                    ""type"": ""Button"",
                    ""id"": ""df8350b1-c1e2-4af0-a50f-14022746f824"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""76dd2407-2c51-4b7b-a4f0-a4c079c9a728"",
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
                    ""id"": ""3a5070ca-232a-4825-b297-f88e55a29c57"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2e63bdb8-ef54-4035-8a59-46e7c234d1ee"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c3121aae-1132-4a7c-bc03-5cd4bd9b11d8"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9fbae38e-e76c-4400-b861-107ff1389f89"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""978856c7-5bfa-44a1-b561-31a9329d537a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49117b72-01dc-4fca-b5eb-f577b7ab2393"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ebda5cf-a468-419c-b580-2f7a342e2c33"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0f183556-6753-498d-993b-61638821652b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""Reload"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""536c3c0b-e100-4e99-a5e0-a5dbefb6707c"",
                    ""path"": ""<Mouse>/scroll/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""CycleWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b15c669b-e077-4cdf-a5bd-3480d7db959a"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KB"",
                    ""action"": ""debugMenu"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KB"",
            ""bindingGroup"": ""KB"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Aim = m_Player.FindAction("Aim", throwIfNotFound: true);
        m_Player_Fire = m_Player.FindAction("Fire", throwIfNotFound: true);
        m_Player_Reload = m_Player.FindAction("Reload", throwIfNotFound: true);
        m_Player_CycleWeapon = m_Player.FindAction("CycleWeapon", throwIfNotFound: true);
        m_Player_debugMenu = m_Player.FindAction("debugMenu", throwIfNotFound: true);
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Aim;
    private readonly InputAction m_Player_Fire;
    private readonly InputAction m_Player_Reload;
    private readonly InputAction m_Player_CycleWeapon;
    private readonly InputAction m_Player_debugMenu;
    public struct PlayerActions
    {
        private @PlayerControls m_Wrapper;
        public PlayerActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Aim => m_Wrapper.m_Player_Aim;
        public InputAction @Fire => m_Wrapper.m_Player_Fire;
        public InputAction @Reload => m_Wrapper.m_Player_Reload;
        public InputAction @CycleWeapon => m_Wrapper.m_Player_CycleWeapon;
        public InputAction @debugMenu => m_Wrapper.m_Player_debugMenu;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Aim.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAim;
                @Fire.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnFire;
                @Reload.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @Reload.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnReload;
                @CycleWeapon.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCycleWeapon;
                @CycleWeapon.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCycleWeapon;
                @CycleWeapon.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCycleWeapon;
                @debugMenu.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDebugMenu;
                @debugMenu.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDebugMenu;
                @debugMenu.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDebugMenu;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
                @Reload.started += instance.OnReload;
                @Reload.performed += instance.OnReload;
                @Reload.canceled += instance.OnReload;
                @CycleWeapon.started += instance.OnCycleWeapon;
                @CycleWeapon.performed += instance.OnCycleWeapon;
                @CycleWeapon.canceled += instance.OnCycleWeapon;
                @debugMenu.started += instance.OnDebugMenu;
                @debugMenu.performed += instance.OnDebugMenu;
                @debugMenu.canceled += instance.OnDebugMenu;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
    private int m_KBSchemeIndex = -1;
    public InputControlScheme KBScheme
    {
        get
        {
            if (m_KBSchemeIndex == -1) m_KBSchemeIndex = asset.FindControlSchemeIndex("KB");
            return asset.controlSchemes[m_KBSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
        void OnReload(InputAction.CallbackContext context);
        void OnCycleWeapon(InputAction.CallbackContext context);
        void OnDebugMenu(InputAction.CallbackContext context);
    }
}
