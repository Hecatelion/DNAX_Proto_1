using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CustomInput
{
	[SerializeField] private e_CommandType type;
	public e_CommandType Type { get => type; }

	[SerializeField] List<KeyCode> keysToPress;
	[SerializeField] List<KeyCode> keysToHold;

	public Callback onInput = () => { };

	public void Update()
	{
		if (IsPerformed())
		{
			onInput();
		}
	}

	public bool IsPerformed()
	{
		foreach (var key in keysToPress)
		{
			if (!Input.GetKeyDown(key))
			{
				return false;
			}
		}

		foreach (var key in keysToHold)
		{
			if (!Input.GetKey(key))
			{
				return false;
			}
		}

		return true;
	}
}
