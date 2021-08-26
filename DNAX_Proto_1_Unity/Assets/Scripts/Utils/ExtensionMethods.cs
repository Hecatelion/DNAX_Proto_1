using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public static class ExtensionMethods 
{
    public static List<T> GetComponentsInVeryChildren<T>(this Component _component)
		where T : Component
	{
		List <T> result =  _component.GetComponentsInChildren<T>().ToList();
		result.Remove(_component as T);

		return result;
	}

    public static List<T> GetComponentsInDirectChildren<T>(this Component _component)
		where T : Component
	{
		List<T> children =  _component.GetComponentsInChildren<T>().ToList();

		return (from child in children 
				where child.transform.parent == _component.transform 
				select child).ToList();
	}

	/*
	 * This made dropdown bug, after using the dd.value = ... the dd become unable to be set active true/false
	 * 
	public static void SetValueFromString(this Dropdown dd, string _optionName)
	{
		// returns a list of the text properties of the options
		//List<string> options = dd.options.Select(option => option.text).ToList();

		// returns the index of the given string
		//dd.value = options.IndexOf(_optionName);

		//dd.value = 1;
	}
	*/
}
