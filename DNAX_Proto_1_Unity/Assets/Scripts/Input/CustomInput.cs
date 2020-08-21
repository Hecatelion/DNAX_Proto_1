using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomInput
{
	public CustomInputData data;
	public Callback onInput = () => { };

	public CustomInput(CustomInputData _data)
	{
		data = _data;
	}

	public void Update()
	{
		if (IsPerformed())
		{
			onInput();
		}
	}

	public bool IsPerformed()
	{
		foreach (var key in data.keysToPress)
		{
			if (!Input.GetKeyDown(key))
			{
				return false;
			}
		}

		foreach (var key in data.keysToHold)
		{
			if (!Input.GetKey(key))
			{
				return false;
			}
		}

		foreach (var key in data.keysToNotTouch)
		{
			if (Input.GetKey(key) || Input.GetKeyDown(key))
			{
				return false;
			}
		}

		return true;
	}
}
