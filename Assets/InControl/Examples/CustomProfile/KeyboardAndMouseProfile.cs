using System;
using System.Collections;
using UnityEngine;
using InControl;


namespace CustomProfileExample
{
	// This custom profile is enabled by adding it to the Custom Profiles list
	// on the InControlManager component, or you can attach it yourself like so:
	// InputManager.AttachDevice( new UnityInputDevice( "KeyboardAndMouseProfile" ) );
	// 
	public class KeyboardAndMouseProfile : UnityInputDeviceProfile
	{
		public KeyboardAndMouseProfile()
		{
			Name = "Keyboard/Mouse";
			Meta = "A keyboard and mouse combination profile appropriate for FPS.";

			// This profile only works on desktops.
			SupportedPlatforms = new[]
			{
				"Windows",
				"Mac",
				"Linux"
			};

			Sensitivity = 1.0f;
			LowerDeadZone = 0.0f;
			UpperDeadZone = 1.0f;

			ButtonMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Fire / Interact",
					Target = InputControlType.Action4,
					Source = MouseButton0
				},
				new InputControlMapping
				{
					Handle = "Ready Weapon",
					Target = InputControlType.RightBumper,
					Source = MouseButton1
				},
				new InputControlMapping
				{
					Handle = "Run / Quick Turn",
					Target = InputControlType.Action2,
					Source = KeyCodeButton( KeyCode.LeftShift )
				},
				new InputControlMapping
				{
					Handle = "Switch Camera",
					Target = InputControlType.Action3,
					Source = KeyCodeButton( KeyCode.Space )
				},
				new InputControlMapping
				{
					Handle = "Switch Weapon",
					Target = InputControlType.Select,
					Source = KeyCodeButton( KeyCode.Tab )
				},
				new InputControlMapping
				{
					Handle = "Pause",
					Target = InputControlType.Start,
					Source = KeyCodeButton( KeyCode.Escape )
				},
			};

			AnalogMappings = new[]
			{
				new InputControlMapping
				{
					Handle = "Move Up",
					Target = InputControlType.DPadUp,
					Source = KeyCodeButton( KeyCode.W )
				},
				new InputControlMapping
				{
					Handle = "Move Down",
					Target = InputControlType.DPadDown,
					Source = KeyCodeButton( KeyCode.S )
				},
				new InputControlMapping
				{
					Handle = "Move Left",
					Target = InputControlType.DPadLeft,
					Source = KeyCodeButton( KeyCode.A )
				},
				new InputControlMapping
				{
					Handle = "Move Right",
					Target = InputControlType.DPadRight,
					Source = KeyCodeButton( KeyCode.D )
				},
				new InputControlMapping
				{
					Handle = "Look X",
					Target = InputControlType.RightStickX,
					Source = MouseXAxis,
					Raw    = true,
					Scale  = 0.1f
				},
				new InputControlMapping
				{
					Handle = "Look Y",
					Target = InputControlType.RightStickY,
					Source = MouseYAxis,
					Raw    = true,
					Scale  = 0.1f
				}
			};
		}
	}
}

