using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour 
	where T : Singleton<T>
{
	private static readonly string TypeName = "Singleton<" + typeof(T).ToString() + ">";

	private static T instance;

	protected virtual void Awake()
	{
		if (instance != null)
		{
			Debug.Log("instance initialized twice. There might is 2 of it in scene, or maybe a DontDestroyOnLoad() instruction. \nSecond" + TypeName + " destroyed.");
			Destroy(this.gameObject);
		}
		else
		{
			instance = (T)this;
		}

		/*
		Debug.Assert(instance == null,
			TypeName + "instance initialized twice. There might is 2 of it in scene, or maybe a DontDestroyOnLoad() instruction");
		*/
	}

	public static T Instance
	{
		get
		{
			Debug.Assert(instance != null, 
				TypeName + "instance not initialized once. It might be missing or not initialized yet.");
			return instance;
		}
	}

	public static bool InstanceExists
	{
		get => instance != null;
	}
}
