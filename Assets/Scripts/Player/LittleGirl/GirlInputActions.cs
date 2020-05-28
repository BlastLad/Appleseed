// GENERATED AUTOMATICALLY FROM 'Assets/Input/GirlInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GirlInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GirlInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GirlInputActions"",
    ""maps"": [
        {
            ""name"": ""GirlMain"",
            ""id"": ""e0c555ca-959f-4d48-9fae-13ae49b012cf"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Button"",
                    ""id"": ""e94ad7c3-721f-4e34-ae34-a96b60e81189"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterRose"",
                    ""type"": ""Button"",
                    ""id"": ""6ce75e36-665f-4037-a610-d71650aa198e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""UseGadget"",
                    ""type"": ""Button"",
                    ""id"": ""bb31481b-a13c-4252-9a5e-28bb65944ba7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleLeft"",
                    ""type"": ""Button"",
                    ""id"": ""43af94da-d477-448b-9f8c-b58fa12864b3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CycleRight"",
                    ""type"": ""Button"",
                    ""id"": ""d70e5ba5-b2d7-4fce-96f7-8503ea952300"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""76994eec-43dc-4a8d-86b4-de98339ff6df"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""09a73a14-05d7-4b16-883f-09ccd54eb9cf"",
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
                    ""id"": ""5e3a38a4-ed4e-4b85-9179-0f4832e8b986"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""23fb1e64-d624-4c32-8773-dd2d36d45243"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""81e90921-4c05-49cd-a954-db8fd37fbd2f"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a7764e04-fba7-4b33-bd8e-2a8cf6f39c6e"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStickGamePad"",
                    ""id"": ""72018247-2d92-478c-81f4-c44f8d98829c"",
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
                    ""id"": ""721ceb83-0afb-4c73-b365-eb626c8b3da4"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fe5328b4-9f46-47a5-807f-1dfedbd2a87d"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f89032e6-fe52-4a82-b93d-ef9743ed8087"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""b08c8c48-e02b-47c6-a1e1-6d20aab20bdf"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyBoard"",
                    ""id"": ""8fa42400-8715-4e93-b988-918748c88717"",
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
                    ""id"": ""15c44e1a-0f68-448b-8b24-1ef35bc6d9c9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fd13ceea-d01a-4e87-9ccc-ed97a1b3ecb1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""0869bfca-5ef5-4e75-a6db-6dc7d9aeb64d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4fd5c4e1-e603-4905-85f6-257304ba7882"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""5dd94d72-edd5-43c0-8ea9-3fa110b484d0"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterRose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a6858e4-5cea-4aad-878c-41d40387b7c0"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterRose"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f5b2d585-ada7-45d0-a5a0-f5f5a88476ab"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseGadget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""20143902-b0e8-49cd-8cd2-f398ba561f2d"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""UseGadget"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e578a5c-0f09-43b4-86d7-a132c93cdfc9"",
                    ""path"": ""<XInputController>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""edefa0f4-98dd-450b-a62a-0fbaee4a3f03"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleLeft"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b9abc5a7-a485-411e-a708-8c41bf5c3e7e"",
                    ""path"": ""<XInputController>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""875577b7-d27d-4091-ae05-019c06e1a628"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CycleRight"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""037db17b-4a4f-4a13-9684-abc203dfd3a5"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c5e16683-5998-4fc7-9700-96faea6ce9e1"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GirlRose"",
            ""id"": ""aa8cee49-0023-4b15-a1ca-59e831c43753"",
            ""actions"": [
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""0c732595-ff6b-4262-a4d7-d2bb4d2ee591"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""3d426218-5a4a-4ae5-83c1-5dcc5e69a10d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterMain"",
                    ""type"": ""Button"",
                    ""id"": ""05eb53f4-afaf-4370-8b36-8d0fb7b95c33"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Fire"",
                    ""type"": ""Button"",
                    ""id"": ""df01f07d-1893-4108-8e2a-ed6d94a5e77a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""6bc588bd-b3fd-40ea-9e79-7bc0a29553a0"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""ec48f967-8eb8-4c29-a74f-f064850c6de5"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5aefb6c5-1979-4c12-b8d9-91a7d24803f9"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9bd97ab0-25df-447d-a75b-5fba10d5601a"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""49cf7a58-70d7-4bce-8d81-c4723afee8cd"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStickGamePad"",
                    ""id"": ""7a16145b-8078-48bb-b95a-3e8d249187dc"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""751348a5-d251-4838-9b4a-62257148034c"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b98b1b93-22a6-4442-98f5-4f47cc76970f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""c48873c4-3bfc-4089-a532-4de334d7b642"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""2ff58af2-a23f-4e6f-a5e5-75c660d8b2f9"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""84dad6e3-6d30-41c3-9750-efdf8ea35b27"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d4aefbe5-f155-48d0-a5cf-1c5fd50f95a5"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f16f4f7e-39fe-41dd-8ba6-51b88aceda96"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dbe48e09-1a16-4ed5-a912-8581f21daca8"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a256b1f-47ee-4e24-93f0-c2391fcd625f"",
                    ""path"": ""<XInputController>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""001811ca-743f-4a11-bb7c-39570a28d25c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Fire"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GirlAppleseedGadget"",
            ""id"": ""ac0b1597-e253-473e-acb6-d20985efda0a"",
            ""actions"": [
                {
                    ""name"": ""Target"",
                    ""type"": ""Button"",
                    ""id"": ""7198d02e-f0b8-4661-b365-731279e12476"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Throw"",
                    ""type"": ""Button"",
                    ""id"": ""80e5762c-39ec-4b6c-b7a0-648aaccbd774"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterMain"",
                    ""type"": ""Button"",
                    ""id"": ""bce3f65a-b96c-44e7-87b0-e8b1ff969304"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f61f0c23-b7fa-49de-b0f5-c562ab4083ab"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""LeftStick"",
                    ""id"": ""a33cba4f-e6a8-4956-ae9a-a0c25875c574"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""eecb5c81-2565-4083-9a5e-0c88a7d08559"",
                    ""path"": ""<XInputController>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""08d6cdc3-a434-4414-b9d2-72136b9a4dfe"",
                    ""path"": ""<XInputController>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""ad2a1981-80c9-4ab5-b1e1-e0059d0ae2b8"",
                    ""path"": ""<XInputController>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""a3050b15-510b-4905-a45f-c731445a4c09"",
                    ""path"": ""<XInputController>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""LeftStickGamePad"",
                    ""id"": ""4b468f88-8146-42ed-bdf0-f7450f30b8a3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e437f7eb-4fe8-498e-a38a-64a7db4508dd"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""158414ac-fc0c-43df-a308-681556f58b93"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9d54b386-d65e-4e17-8738-f4ad4127e65b"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""dcd7eec6-0ffd-4de4-b245-127fc1056ec8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Target"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""e784004d-2710-473e-8fb8-80f5b5198fdd"",
                    ""path"": ""<XInputController>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d2e8f365-5af5-4281-b23c-97e43f761df0"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throw"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a521b06-4d2e-42e8-a497-e13039940925"",
                    ""path"": ""<XInputController>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5503f5bc-febc-4ce3-8c6a-586e8f6c06ce"",
                    ""path"": ""<Gamepad>/select"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterMain"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""46c98ed3-728c-4335-b08c-07f100001a98"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""18ea515c-3dcf-4c89-844e-d8ba88e97d40"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GirlCaptured"",
            ""id"": ""5aac7f47-2bce-4e2f-a1d8-abc9ca666d0b"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""f096f779-61a7-4162-a896-f4765efecfef"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""8ab172c2-3e40-4470-9045-303d686bf28e"",
                    ""path"": ""<XInputController>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c069a4c3-3cb8-4374-add3-2762e8fbf0d6"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""GirlMounted"",
            ""id"": ""8e856c3f-9bc1-4347-8aaf-e9141e3b4c92"",
            ""actions"": [
                {
                    ""name"": ""Demount"",
                    ""type"": ""Button"",
                    ""id"": ""d235abae-2cd1-4922-a8b6-c314a54e3cd3"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": ""Press""
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""df718e39-4790-4f18-9f92-842201284467"",
                    ""path"": ""<XInputController>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Demount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcbc657d-86dd-4d0d-b55d-e7a9a8bacbc3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Demount"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // GirlMain
        m_GirlMain = asset.FindActionMap("GirlMain", throwIfNotFound: true);
        m_GirlMain_Movement = m_GirlMain.FindAction("Movement", throwIfNotFound: true);
        m_GirlMain_EnterRose = m_GirlMain.FindAction("EnterRose", throwIfNotFound: true);
        m_GirlMain_UseGadget = m_GirlMain.FindAction("UseGadget", throwIfNotFound: true);
        m_GirlMain_CycleLeft = m_GirlMain.FindAction("CycleLeft", throwIfNotFound: true);
        m_GirlMain_CycleRight = m_GirlMain.FindAction("CycleRight", throwIfNotFound: true);
        m_GirlMain_Pause = m_GirlMain.FindAction("Pause", throwIfNotFound: true);
        // GirlRose
        m_GirlRose = asset.FindActionMap("GirlRose", throwIfNotFound: true);
        m_GirlRose_Target = m_GirlRose.FindAction("Target", throwIfNotFound: true);
        m_GirlRose_Pause = m_GirlRose.FindAction("Pause", throwIfNotFound: true);
        m_GirlRose_EnterMain = m_GirlRose.FindAction("EnterMain", throwIfNotFound: true);
        m_GirlRose_Fire = m_GirlRose.FindAction("Fire", throwIfNotFound: true);
        // GirlAppleseedGadget
        m_GirlAppleseedGadget = asset.FindActionMap("GirlAppleseedGadget", throwIfNotFound: true);
        m_GirlAppleseedGadget_Target = m_GirlAppleseedGadget.FindAction("Target", throwIfNotFound: true);
        m_GirlAppleseedGadget_Throw = m_GirlAppleseedGadget.FindAction("Throw", throwIfNotFound: true);
        m_GirlAppleseedGadget_EnterMain = m_GirlAppleseedGadget.FindAction("EnterMain", throwIfNotFound: true);
        m_GirlAppleseedGadget_Pause = m_GirlAppleseedGadget.FindAction("Pause", throwIfNotFound: true);
        // GirlCaptured
        m_GirlCaptured = asset.FindActionMap("GirlCaptured", throwIfNotFound: true);
        m_GirlCaptured_Pause = m_GirlCaptured.FindAction("Pause", throwIfNotFound: true);
        // GirlMounted
        m_GirlMounted = asset.FindActionMap("GirlMounted", throwIfNotFound: true);
        m_GirlMounted_Demount = m_GirlMounted.FindAction("Demount", throwIfNotFound: true);
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

    // GirlMain
    private readonly InputActionMap m_GirlMain;
    private IGirlMainActions m_GirlMainActionsCallbackInterface;
    private readonly InputAction m_GirlMain_Movement;
    private readonly InputAction m_GirlMain_EnterRose;
    private readonly InputAction m_GirlMain_UseGadget;
    private readonly InputAction m_GirlMain_CycleLeft;
    private readonly InputAction m_GirlMain_CycleRight;
    private readonly InputAction m_GirlMain_Pause;
    public struct GirlMainActions
    {
        private @GirlInputActions m_Wrapper;
        public GirlMainActions(@GirlInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_GirlMain_Movement;
        public InputAction @EnterRose => m_Wrapper.m_GirlMain_EnterRose;
        public InputAction @UseGadget => m_Wrapper.m_GirlMain_UseGadget;
        public InputAction @CycleLeft => m_Wrapper.m_GirlMain_CycleLeft;
        public InputAction @CycleRight => m_Wrapper.m_GirlMain_CycleRight;
        public InputAction @Pause => m_Wrapper.m_GirlMain_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GirlMain; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GirlMainActions set) { return set.Get(); }
        public void SetCallbacks(IGirlMainActions instance)
        {
            if (m_Wrapper.m_GirlMainActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnMovement;
                @EnterRose.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnEnterRose;
                @EnterRose.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnEnterRose;
                @EnterRose.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnEnterRose;
                @UseGadget.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnUseGadget;
                @UseGadget.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnUseGadget;
                @UseGadget.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnUseGadget;
                @CycleLeft.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleLeft;
                @CycleLeft.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleLeft;
                @CycleRight.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleRight;
                @CycleRight.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleRight;
                @CycleRight.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnCycleRight;
                @Pause.started -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GirlMainActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GirlMainActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @EnterRose.started += instance.OnEnterRose;
                @EnterRose.performed += instance.OnEnterRose;
                @EnterRose.canceled += instance.OnEnterRose;
                @UseGadget.started += instance.OnUseGadget;
                @UseGadget.performed += instance.OnUseGadget;
                @UseGadget.canceled += instance.OnUseGadget;
                @CycleLeft.started += instance.OnCycleLeft;
                @CycleLeft.performed += instance.OnCycleLeft;
                @CycleLeft.canceled += instance.OnCycleLeft;
                @CycleRight.started += instance.OnCycleRight;
                @CycleRight.performed += instance.OnCycleRight;
                @CycleRight.canceled += instance.OnCycleRight;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GirlMainActions @GirlMain => new GirlMainActions(this);

    // GirlRose
    private readonly InputActionMap m_GirlRose;
    private IGirlRoseActions m_GirlRoseActionsCallbackInterface;
    private readonly InputAction m_GirlRose_Target;
    private readonly InputAction m_GirlRose_Pause;
    private readonly InputAction m_GirlRose_EnterMain;
    private readonly InputAction m_GirlRose_Fire;
    public struct GirlRoseActions
    {
        private @GirlInputActions m_Wrapper;
        public GirlRoseActions(@GirlInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Target => m_Wrapper.m_GirlRose_Target;
        public InputAction @Pause => m_Wrapper.m_GirlRose_Pause;
        public InputAction @EnterMain => m_Wrapper.m_GirlRose_EnterMain;
        public InputAction @Fire => m_Wrapper.m_GirlRose_Fire;
        public InputActionMap Get() { return m_Wrapper.m_GirlRose; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GirlRoseActions set) { return set.Get(); }
        public void SetCallbacks(IGirlRoseActions instance)
        {
            if (m_Wrapper.m_GirlRoseActionsCallbackInterface != null)
            {
                @Target.started -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnTarget;
                @Pause.started -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnPause;
                @EnterMain.started -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnEnterMain;
                @EnterMain.performed -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnEnterMain;
                @EnterMain.canceled -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnEnterMain;
                @Fire.started -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnFire;
                @Fire.performed -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnFire;
                @Fire.canceled -= m_Wrapper.m_GirlRoseActionsCallbackInterface.OnFire;
            }
            m_Wrapper.m_GirlRoseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
                @EnterMain.started += instance.OnEnterMain;
                @EnterMain.performed += instance.OnEnterMain;
                @EnterMain.canceled += instance.OnEnterMain;
                @Fire.started += instance.OnFire;
                @Fire.performed += instance.OnFire;
                @Fire.canceled += instance.OnFire;
            }
        }
    }
    public GirlRoseActions @GirlRose => new GirlRoseActions(this);

    // GirlAppleseedGadget
    private readonly InputActionMap m_GirlAppleseedGadget;
    private IGirlAppleseedGadgetActions m_GirlAppleseedGadgetActionsCallbackInterface;
    private readonly InputAction m_GirlAppleseedGadget_Target;
    private readonly InputAction m_GirlAppleseedGadget_Throw;
    private readonly InputAction m_GirlAppleseedGadget_EnterMain;
    private readonly InputAction m_GirlAppleseedGadget_Pause;
    public struct GirlAppleseedGadgetActions
    {
        private @GirlInputActions m_Wrapper;
        public GirlAppleseedGadgetActions(@GirlInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Target => m_Wrapper.m_GirlAppleseedGadget_Target;
        public InputAction @Throw => m_Wrapper.m_GirlAppleseedGadget_Throw;
        public InputAction @EnterMain => m_Wrapper.m_GirlAppleseedGadget_EnterMain;
        public InputAction @Pause => m_Wrapper.m_GirlAppleseedGadget_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GirlAppleseedGadget; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GirlAppleseedGadgetActions set) { return set.Get(); }
        public void SetCallbacks(IGirlAppleseedGadgetActions instance)
        {
            if (m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface != null)
            {
                @Target.started -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnTarget;
                @Target.performed -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnTarget;
                @Target.canceled -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnTarget;
                @Throw.started -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnThrow;
                @Throw.performed -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnThrow;
                @Throw.canceled -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnThrow;
                @EnterMain.started -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnEnterMain;
                @EnterMain.performed -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnEnterMain;
                @EnterMain.canceled -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnEnterMain;
                @Pause.started -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GirlAppleseedGadgetActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Target.started += instance.OnTarget;
                @Target.performed += instance.OnTarget;
                @Target.canceled += instance.OnTarget;
                @Throw.started += instance.OnThrow;
                @Throw.performed += instance.OnThrow;
                @Throw.canceled += instance.OnThrow;
                @EnterMain.started += instance.OnEnterMain;
                @EnterMain.performed += instance.OnEnterMain;
                @EnterMain.canceled += instance.OnEnterMain;
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GirlAppleseedGadgetActions @GirlAppleseedGadget => new GirlAppleseedGadgetActions(this);

    // GirlCaptured
    private readonly InputActionMap m_GirlCaptured;
    private IGirlCapturedActions m_GirlCapturedActionsCallbackInterface;
    private readonly InputAction m_GirlCaptured_Pause;
    public struct GirlCapturedActions
    {
        private @GirlInputActions m_Wrapper;
        public GirlCapturedActions(@GirlInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_GirlCaptured_Pause;
        public InputActionMap Get() { return m_Wrapper.m_GirlCaptured; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GirlCapturedActions set) { return set.Get(); }
        public void SetCallbacks(IGirlCapturedActions instance)
        {
            if (m_Wrapper.m_GirlCapturedActionsCallbackInterface != null)
            {
                @Pause.started -= m_Wrapper.m_GirlCapturedActionsCallbackInterface.OnPause;
                @Pause.performed -= m_Wrapper.m_GirlCapturedActionsCallbackInterface.OnPause;
                @Pause.canceled -= m_Wrapper.m_GirlCapturedActionsCallbackInterface.OnPause;
            }
            m_Wrapper.m_GirlCapturedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Pause.started += instance.OnPause;
                @Pause.performed += instance.OnPause;
                @Pause.canceled += instance.OnPause;
            }
        }
    }
    public GirlCapturedActions @GirlCaptured => new GirlCapturedActions(this);

    // GirlMounted
    private readonly InputActionMap m_GirlMounted;
    private IGirlMountedActions m_GirlMountedActionsCallbackInterface;
    private readonly InputAction m_GirlMounted_Demount;
    public struct GirlMountedActions
    {
        private @GirlInputActions m_Wrapper;
        public GirlMountedActions(@GirlInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Demount => m_Wrapper.m_GirlMounted_Demount;
        public InputActionMap Get() { return m_Wrapper.m_GirlMounted; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GirlMountedActions set) { return set.Get(); }
        public void SetCallbacks(IGirlMountedActions instance)
        {
            if (m_Wrapper.m_GirlMountedActionsCallbackInterface != null)
            {
                @Demount.started -= m_Wrapper.m_GirlMountedActionsCallbackInterface.OnDemount;
                @Demount.performed -= m_Wrapper.m_GirlMountedActionsCallbackInterface.OnDemount;
                @Demount.canceled -= m_Wrapper.m_GirlMountedActionsCallbackInterface.OnDemount;
            }
            m_Wrapper.m_GirlMountedActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Demount.started += instance.OnDemount;
                @Demount.performed += instance.OnDemount;
                @Demount.canceled += instance.OnDemount;
            }
        }
    }
    public GirlMountedActions @GirlMounted => new GirlMountedActions(this);
    public interface IGirlMainActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnEnterRose(InputAction.CallbackContext context);
        void OnUseGadget(InputAction.CallbackContext context);
        void OnCycleLeft(InputAction.CallbackContext context);
        void OnCycleRight(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IGirlRoseActions
    {
        void OnTarget(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
        void OnEnterMain(InputAction.CallbackContext context);
        void OnFire(InputAction.CallbackContext context);
    }
    public interface IGirlAppleseedGadgetActions
    {
        void OnTarget(InputAction.CallbackContext context);
        void OnThrow(InputAction.CallbackContext context);
        void OnEnterMain(InputAction.CallbackContext context);
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IGirlCapturedActions
    {
        void OnPause(InputAction.CallbackContext context);
    }
    public interface IGirlMountedActions
    {
        void OnDemount(InputAction.CallbackContext context);
    }
}
