using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Singleton & Factory
public class TheSkillEffectManager : MonoBehaviour
{
	private static TheSkillEffectManager instance;

	int i = 3;

	[SerializeField] List<GameObject> skillEffectsPrefabs;

    void Start()
    {
        if (instance == null)
		{
			instance = this;
		}
		else
		{
			Destroy(this.gameObject);
		}
    }

    void Update()
    { }

	private void instance_CreateSkillEffect(e_SkillEffectTypes _effect) // +args : organism, target ? 
	{
		GameObject skillEffectPrefab = (from prefab in skillEffectsPrefabs where prefab.GetComponent<SkillEffect>().type == _effect select prefab).ToList()[0];

		if (!skillEffectPrefab)
		{
			Debug.LogError("Skill Effect Type : \"" + _effect.ToString() + "\" not found in TheSkillManager.\n" +
			"Please ensure present is referenced in the List");

			return;
		}

		GameObject skillEffectCreated = Instantiate(skillEffectPrefab, this.transform);
	}

	public static void CreateSkillEffect(e_SkillEffectTypes _effect)
	{
		instance.instance_CreateSkillEffect(_effect);
	}
}
