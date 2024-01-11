using System;


namespace InControl
{
	// @cond nodoc
	[AutoDiscover]
	public class SNES30Profile : UnityInputDeviceProfile
	{
		public SNES30Profile()
		{
			Name = "8Bitdo SNES30";
			Meta = "8Bitdo SNES30 Gamepad";

			SupportedPlatforms = new[] {
				"Android"
			};

			JoystickNames = new[] {
				"8Bitdo SNES30 Gamepad",
			};

			ButtonMappings = new[] {
				new InputControlMapping {
					Handle = "DPad Up",
					Target = InputControlType.DPadUp,
					Source = KeyCodeButton( UnityEngine.KeyCode.UpArrow )
				},
				new InputControlMapping {
					Handle = "DPad Down",
					Target = InputControlType.DPadDown,
					Source = KeyCodeButton( UnityEngine.KeyCode.DownArrow )
				},
				new InputControlMapping {
					Handle = "DPad Left",
					Target = InputControlType.DPadLeft,
					Source = KeyCodeButton( UnityEngine.KeyCode.LeftArrow )
				},
				new InputControlMapping {
					Handle = "DPad Right",
					Target = InputControlType.DPadRight,
					Source = KeyCodeButton( UnityEngine.KeyCode.RightArrow )
				},
				new InputControlMapping {
					Handle = "A",
					Target = InputControlType.Action1,
					Source = Button0
				},
				new InputControlMapping {
					Handle = "B",
					Target = InputControlType.Action2,
					Source = Button1
				},
				new InputControlMapping {
					Handle = "X",
					Target = InputControlType.Action3,
					Source = Button2
				},
				new InputControlMapping {
					Handle = "Y",
					Target = InputControlType.Action4,
					Source = Button3
				},
				new InputControlMapping {
					Handle = "L",
					Target = InputControlType.LeftBumper,
					Source = Button4
				},
				new InputControlMapping {
					Handle = "R",
					Target = InputControlType.RightBumper,
					Source = Button5
				},
				new InputControlMapping {
					Handle = "Start",
					Target = InputControlType.Start,
					Source = Button10
				},
				new InputControlMapping {
					Handle = "Select",
					Target = InputControlType.Select,
					Source = Button11
				}
			};
		}
	}
}

