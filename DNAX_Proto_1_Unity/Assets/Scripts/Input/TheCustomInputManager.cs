﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Singleton 
public class TheCustomInputManager : Singleton<TheCustomInputManager>
{
	[SerializeField] private List<CustomInputData> customInputDatas = new List<CustomInputData>();
	public List<CustomInput> customInputs; // make it prvt

	void Start()
	{
		customInputs = new List<CustomInput>();
		foreach (var data in customInputDatas)
		{
			customInputs.Add(new CustomInput(data));
		}
	}

	private void Update()
	{
		foreach (var customInput in customInputs)
		{
			customInput.Update();
		}
	}

	private CustomInput instance_GetInputOfType(e_CommandType _type)
	{
		List<CustomInput> correspondingOnes = (from customInput in customInputs where customInput.data.Type == _type select customInput).ToList();
		
		if (correspondingOnes.Count > 1)
		{
			Debug.LogError("More than 1 custom input corresponding to " + _type.ToString() + " found. \n" +
				"Please ensure TheCustomInputManager's list contains it only once.");
			return null;	
		}
		else if (correspondingOnes.Count < 1)
		{
			Debug.LogError("No custom input corresponding to " + _type.ToString() + " found. \n" +
				"Please ensure TheCustomInputManager's list contains it only once.");
			return null;
		}

		return correspondingOnes[0];
	}

	private void instance_Bind(Callback _funk, e_CommandType _type)
	{
		instance_GetInputOfType(_type).onInput += _funk;
	}

	private void instance_Bind(IBindable _bindable, e_CommandType _type)
	{
		instance_Bind(_bindable.RequestAction, _type);
	}

	private void instance_Unbind(Callback _funk, e_CommandType _type)
	{
		instance_GetInputOfType(_type).onInput -= _funk;
	}

	private void instance_Unbind(IBindable _bindable, e_CommandType _type)
	{
		instance_Unbind(_bindable.RequestAction, _type);
	}

	// --------------------------------
	// Singleton static functions

	public static void Bind(Callback _func, e_CommandType _type)
	{
		Instance.instance_Bind(_func, _type);
	}

	public static void Bind(IBindable _bindable, e_CommandType _type)
	{
		Instance.instance_Bind(_bindable, _type);
	}

	public static void Unbind(Callback _func, e_CommandType _type)
	{
		Instance.instance_Unbind(_func, _type);
	}

	public static void Unbind(IBindable _bindable, e_CommandType _type)
	{
		Instance.instance_Unbind(_bindable, _type);
	}
}
