// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/PlayerController.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerController : IInputActionCollection, IDisposable
{
    private InputActionAsset asset;
    public PlayerController()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerController"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""5674b4e8-1d73-480b-a0ea-494e4ded920b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""c5108b8a-26aa-4fc4-92c6-477325b009cb"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bad24792-e118-435b-af34-155a10cb74ab"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""b03d1bb4-8012-4927-86c3-c2361782eddb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""dd976ea9-8b81-4eae-a2fd-6d864cdcb373"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e704ff1-1967-429f-b5eb-51ae26cf8589"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0557ff5a-6fe0-4811-a8a4-d759cf87fc30"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""QTE"",
            ""id"": ""aacd3b51-d0b1-4e5a-b57e-d3bee2768d4c"",
            ""actions"": [
                {
                    ""name"": ""Rat"",
                    ""type"": ""Button"",
                    ""id"": ""1ba6a6ec-31f3-453e-beda-89306f2aaf6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Bunny"",
                    ""type"": ""Button"",
                    ""id"": ""961aa867-a4c9-457d-bf27-27716a00b9e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""706631f6-4242-439c-994c-b2b9874965e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dragon"",
                    ""type"": ""Button"",
                    ""id"": ""ea804d83-7d78-4a7d-bf0d-bc2f4c968c17"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""40b33ab2-d655-4ecc-b706-553312a33ce2"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rat"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a479ab95-372e-4300-830a-f8181d364029"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Bunny"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3402eaff-b183-4c98-a4b9-17b0b4335186"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82b05d0d-5cba-4939-b92b-ebe73205c5ba"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dragon"",
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
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_Jump = m_Gameplay.FindAction("Jump", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
        // QTE
        m_QTE = asset.FindActionMap("QTE", throwIfNotFound: true);
        m_QTE_Rat = m_QTE.FindAction("Rat", throwIfNotFound: true);
        m_QTE_Bunny = m_QTE.FindAction("Bunny", throwIfNotFound: true);
        m_QTE_Newaction = m_QTE.FindAction("New action", throwIfNotFound: true);
        m_QTE_Dragon = m_QTE.FindAction("Dragon", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_Jump;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private PlayerController m_Wrapper;
        public GameplayActions(PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                Jump.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Jump.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJump;
                Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Jump.started += instance.OnJump;
                Jump.performed += instance.OnJump;
                Jump.canceled += instance.OnJump;
                Interact.started += instance.OnInteract;
                Interact.performed += instance.OnInteract;
                Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // QTE
    private readonly InputActionMap m_QTE;
    private IQTEActions m_QTEActionsCallbackInterface;
    private readonly InputAction m_QTE_Rat;
    private readonly InputAction m_QTE_Bunny;
    private readonly InputAction m_QTE_Newaction;
    private readonly InputAction m_QTE_Dragon;
    public struct QTEActions
    {
        private PlayerController m_Wrapper;
        public QTEActions(PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Rat => m_Wrapper.m_QTE_Rat;
        public InputAction @Bunny => m_Wrapper.m_QTE_Bunny;
        public InputAction @Newaction => m_Wrapper.m_QTE_Newaction;
        public InputAction @Dragon => m_Wrapper.m_QTE_Dragon;
        public InputActionMap Get() { return m_Wrapper.m_QTE; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QTEActions set) { return set.Get(); }
        public void SetCallbacks(IQTEActions instance)
        {
            if (m_Wrapper.m_QTEActionsCallbackInterface != null)
            {
                Rat.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnRat;
                Rat.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnRat;
                Rat.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnRat;
                Bunny.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnBunny;
                Bunny.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnBunny;
                Bunny.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnBunny;
                Newaction.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnNewaction;
                Dragon.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnDragon;
                Dragon.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnDragon;
                Dragon.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnDragon;
            }
            m_Wrapper.m_QTEActionsCallbackInterface = instance;
            if (instance != null)
            {
                Rat.started += instance.OnRat;
                Rat.performed += instance.OnRat;
                Rat.canceled += instance.OnRat;
                Bunny.started += instance.OnBunny;
                Bunny.performed += instance.OnBunny;
                Bunny.canceled += instance.OnBunny;
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
                Dragon.started += instance.OnDragon;
                Dragon.performed += instance.OnDragon;
                Dragon.canceled += instance.OnDragon;
            }
        }
    }
    public QTEActions @QTE => new QTEActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
    public interface IQTEActions
    {
        void OnRat(InputAction.CallbackContext context);
        void OnBunny(InputAction.CallbackContext context);
        void OnNewaction(InputAction.CallbackContext context);
        void OnDragon(InputAction.CallbackContext context);
    }
}
