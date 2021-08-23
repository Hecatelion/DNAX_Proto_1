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
				select child).ToList(); //new List<T>();

		
		/*
		foreach (var child in children)
		{
			if (child.transform.parent == _component.transform)
			{
				result.Remove(_component as T);
			}
		}

		return result;
		*/
	}

	public static void SetValueFormString(this Dropdown dd, string _optionName)
	{
		// returns a list of the text properties of the options
		List<string> options = dd.options.Select(option => option.text).ToList();

		// returns the index of the given string
		dd.value = options.IndexOf(_optionName);
	}
}
