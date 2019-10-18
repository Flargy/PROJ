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
                },
                {
                    ""name"": ""Toss"",
                    ""type"": ""Button"",
                    ""id"": ""930456eb-2fd5-49bd-b692-cd82276a4bcc"",
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
                },
                {
                    ""name"": """",
                    ""id"": ""b4869036-4bf6-4dfb-ba3e-868128fa5c4c"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Toss"",
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
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""1ba6a6ec-31f3-453e-beda-89306f2aaf6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""961aa867-a4c9-457d-bf27-27716a00b9e8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""706631f6-4242-439c-994c-b2b9874965e7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
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
                    ""action"": ""Down"",
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
                    ""action"": ""Right"",
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
                    ""action"": ""Up"",
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
                    ""action"": ""Left"",
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
        m_Gameplay_Toss = m_Gameplay.FindAction("Toss", throwIfNotFound: true);
        // QTE
        m_QTE = asset.FindActionMap("QTE", throwIfNotFound: true);
        m_QTE_Down = m_QTE.FindAction("Down", throwIfNotFound: true);
        m_QTE_Right = m_QTE.FindAction("Right", throwIfNotFound: true);
        m_QTE_Up = m_QTE.FindAction("Up", throwIfNotFound: true);
        m_QTE_Left = m_QTE.FindAction("Left", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Toss;
    public struct GameplayActions
    {
        private PlayerController m_Wrapper;
        public GameplayActions(PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @Jump => m_Wrapper.m_Gameplay_Jump;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputAction @Toss => m_Wrapper.m_Gameplay_Toss;
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
                Toss.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToss;
                Toss.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToss;
                Toss.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnToss;
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
                Toss.started += instance.OnToss;
                Toss.performed += instance.OnToss;
                Toss.canceled += instance.OnToss;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // QTE
    private readonly InputActionMap m_QTE;
    private IQTEActions m_QTEActionsCallbackInterface;
    private readonly InputAction m_QTE_Down;
    private readonly InputAction m_QTE_Right;
    private readonly InputAction m_QTE_Up;
    private readonly InputAction m_QTE_Left;
    public struct QTEActions
    {
        private PlayerController m_Wrapper;
        public QTEActions(PlayerController wrapper) { m_Wrapper = wrapper; }
        public InputAction @Down => m_Wrapper.m_QTE_Down;
        public InputAction @Right => m_Wrapper.m_QTE_Right;
        public InputAction @Up => m_Wrapper.m_QTE_Up;
        public InputAction @Left => m_Wrapper.m_QTE_Left;
        public InputActionMap Get() { return m_Wrapper.m_QTE; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(QTEActions set) { return set.Get(); }
        public void SetCallbacks(IQTEActions instance)
        {
            if (m_Wrapper.m_QTEActionsCallbackInterface != null)
            {
                Down.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnDown;
                Down.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnDown;
                Down.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnDown;
                Right.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnRight;
                Right.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnRight;
                Right.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnRight;
                Up.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnUp;
                Up.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnUp;
                Up.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnUp;
                Left.started -= m_Wrapper.m_QTEActionsCallbackInterface.OnLeft;
                Left.performed -= m_Wrapper.m_QTEActionsCallbackInterface.OnLeft;
                Left.canceled -= m_Wrapper.m_QTEActionsCallbackInterface.OnLeft;
            }
            m_Wrapper.m_QTEActionsCallbackInterface = instance;
            if (instance != null)
            {
                Down.started += instance.OnDown;
                Down.performed += instance.OnDown;
                Down.canceled += instance.OnDown;
                Right.started += instance.OnRight;
                Right.performed += instance.OnRight;
                Right.canceled += instance.OnRight;
                Up.started += instance.OnUp;
                Up.performed += instance.OnUp;
                Up.canceled += instance.OnUp;
                Left.started += instance.OnLeft;
                Left.performed += instance.OnLeft;
                Left.canceled += instance.OnLeft;
            }
        }
    }
    public QTEActions @QTE => new QTEActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnToss(InputAction.CallbackContext context);
    }
    public interface IQTEActions
    {
        void OnDown(InputAction.CallbackContext context);
        void OnRight(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
    }
}
