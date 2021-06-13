// GENERATED AUTOMATICALLY FROM 'Assets/DataAssets/Input/GMTKControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GMTKControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GMTKControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GMTKControls"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""dd6954e3-6642-4afd-a705-fb7e7474a713"",
            ""actions"": [
                {
                    ""name"": ""Start"",
                    ""type"": ""Value"",
                    ""id"": ""c116f491-edd0-4042-bf4d-164a9a0d9c6e"",
                    ""expectedControlType"": ""Digital"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ef302c0a-b65b-48d8-a374-d460b5b5b3e1"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Start"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Gameplay"",
            ""id"": ""36612db9-f0c4-45e0-8e18-823297c424e4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""f03b020b-9df8-4920-88b7-998ce9776701"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Click"",
                    ""type"": ""Button"",
                    ""id"": ""96321006-5e76-45ad-863c-afafac545fd6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""5772587a-a501-4b8e-9a2e-0cb519644611"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7f573d11-5b80-4b4f-9fd6-eeabf1def323"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5a2dc907-a3bb-4b79-b33f-04313997fb17"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""4cc51d33-14be-409f-9fd2-f314bb76da0e"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""86823359-33c0-460b-b063-334054a9c3a3"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""50ff9c31-ad0e-4c72-b721-42eb02081416"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""InsideGameplay"",
            ""id"": ""c022e761-a810-479d-8328-c13d8c62fa9b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""460fa833-cfe4-49c9-a812-3f0328debb46"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InsideInteract"",
                    ""type"": ""Button"",
                    ""id"": ""237d051a-725f-47c3-a0a9-ba178380b4b1"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""17ac8f84-1237-4eb0-b935-88945200e195"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""1af88507-4bd2-46e6-93b2-c7e9ad19f792"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9349a848-7027-471c-924f-9040d3877ae0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""656e4f13-52f1-4a89-bc14-b924147441d7"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""beabcbdf-6049-4ceb-a355-98354ba90c1e"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3857f1ee-207a-4feb-8d88-b55f245b8287"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InsideInteract"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""OutsideGameplay"",
            ""id"": ""ea81b52c-4c95-4547-adbe-8fc64b60cfc9"",
            ""actions"": [
                {
                    ""name"": ""Click"",
                    ""type"": ""Value"",
                    ""id"": ""01f61bf6-2187-4ad2-808e-eba20f5959fd"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e43d21cd-ee8e-455d-baf1-360b488b2748"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Click"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PauseMenu"",
            ""id"": ""5de3114a-d3d1-4236-bd64-59fd5d0fbbbf"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""906c1378-2c6f-4dea-b29b-b4ffbf2553de"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""85050137-c93c-4da7-ba28-6543e2ec3c6e"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Menu
        m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
        m_Menu_Start = m_Menu.FindAction("Start", throwIfNotFound: true);
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Click = m_Gameplay.FindAction("Click", throwIfNotFound: true);
        // InsideGameplay
        m_InsideGameplay = asset.FindActionMap("InsideGameplay", throwIfNotFound: true);
        m_InsideGameplay_Move = m_InsideGameplay.FindAction("Move", throwIfNotFound: true);
        m_InsideGameplay_InsideInteract = m_InsideGameplay.FindAction("InsideInteract", throwIfNotFound: true);
        // OutsideGameplay
        m_OutsideGameplay = asset.FindActionMap("OutsideGameplay", throwIfNotFound: true);
        m_OutsideGameplay_Click = m_OutsideGameplay.FindAction("Click", throwIfNotFound: true);
        // PauseMenu
        m_PauseMenu = asset.FindActionMap("PauseMenu", throwIfNotFound: true);
        m_PauseMenu_Pause = m_PauseMenu.FindAction("Pause", throwIfNotFound: true);
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

    // Menu
    private readonly InputActionMap m_Menu;
    private IMenuActions m_MenuActionsCallbackInterface;
    private readonly InputAction m_Menu_Start;
    public struct MenuActions
    {
        private @GMTKControls m_Wrapper;
        public MenuActions(@GMTKControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Start => m_Wrapper.m_Menu_Start;
        public InputActionMap Get() { return m_Wrapper.m_Menu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
        public void SetCallbacks(IMenuActions instance)
        {
            if (m_Wrapper.m_MenuActionsCallbackInterface != null)
            {
                @Start.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
                @Start.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
                @Start.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnStart;
            }
            m_Wrapper.m_MenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Start.started += instance.OnStart;
                @Start.performed += instance.OnStart;
                @Start.canceled += instance.OnStart;
            }
        }
    }
    public MenuActions @Menu => new MenuActions(this);

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Click;
    public struct GameplayActions
    {
        private @GMTKControls m_Wrapper;
        public GameplayActions(@GMTKControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Click => m_Wrapper.m_Gameplay_Click;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Click.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // InsideGameplay
    private readonly InputActionMap m_InsideGameplay;
    private IInsideGameplayActions m_InsideGameplayActionsCallbackInterface;
    private readonly InputAction m_InsideGameplay_Move;
    private readonly InputAction m_InsideGameplay_InsideInteract;
    public struct InsideGameplayActions
    {
        private @GMTKControls m_Wrapper;
        public InsideGameplayActions(@GMTKControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_InsideGameplay_Move;
        public InputAction @InsideInteract => m_Wrapper.m_InsideGameplay_InsideInteract;
        public InputActionMap Get() { return m_Wrapper.m_InsideGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(InsideGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IInsideGameplayActions instance)
        {
            if (m_Wrapper.m_InsideGameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnMove;
                @InsideInteract.started -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnInsideInteract;
                @InsideInteract.performed -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnInsideInteract;
                @InsideInteract.canceled -= m_Wrapper.m_InsideGameplayActionsCallbackInterface.OnInsideInteract;
            }
            m_Wrapper.m_InsideGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @InsideInteract.started += instance.OnInsideInteract;
                @InsideInteract.performed += instance.OnInsideInteract;
                @InsideInteract.canceled += instance.OnInsideInteract;
            }
        }
    }
    public InsideGameplayActions @InsideGameplay => new InsideGameplayActions(this);

    // OutsideGameplay
    private readonly InputActionMap m_OutsideGameplay;
    private IOutsideGameplayActions m_OutsideGameplayActionsCallbackInterface;
    private readonly InputAction m_OutsideGameplay_Click;
    public struct OutsideGameplayActions
    {
        private @GMTKControls m_Wrapper;
        public OutsideGameplayActions(@GMTKControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Click => m_Wrapper.m_OutsideGameplay_Click;
        public InputActionMap Get() { return m_Wrapper.m_OutsideGameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(OutsideGameplayActions set) { return set.Get(); }
        public void SetCallbacks(IOutsideGameplayActions instance)
        {
            if (m_Wrapper.m_OutsideGameplayActionsCallbackInterface != null)
            {
                @Click.started -= m_Wrapper.m_OutsideGameplayActionsCallbackInterface.OnClick;
                @Click.performed -= m_Wrapper.m_OutsideGameplayActionsCallbackInterface.OnClick;
                @Click.canceled -= m_Wrapper.m_OutsideGameplayActionsCallbackInterface.OnClick;
            }
            m_Wrapper.m_OutsideGameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Click.started += instance.OnClick;
                @Click.performed += instance.OnClick;
                @Click.canceled += instance.OnClick;
            }
        }
    }
    public OutsideGameplayActions @OutsideGameplay => new OutsideGameplayActions(this);

    // PauseMenu
    private readonly InputActionMap m_PauseMenu;
    private IPauseMenuActions m_PauseMenuActionsCallbackInterface;
    private readonly InputAction m_PauseMenu_Pause;
    public struct PauseMenuActions
    {
        private @GMTKControls m_Wrapper;
        public PauseMenuActions(@GMTKControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_PauseMenu_Pause;
        public InputActionMap Get() { return m_Wrapper.m_PauseMenu; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PauseMenuActions set) { return set.Get(); }
        public void SetCallbacks(IPauseMenuActions instance)
        {
            if (m_Wrapper.m_PauseMenuActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_PauseMenuActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_PauseMenuActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public PauseMenuActions @PauseMenu => new PauseMenuActions(this);
    public interface IMenuActions
    {
        void OnStart(InputAction.CallbackContext context);
    }
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IInsideGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnInsideInteract(InputAction.CallbackContext context);
    }
    public interface IOutsideGameplayActions
    {
        void OnClick(InputAction.CallbackContext context);
    }
    public interface IPauseMenuActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
}
