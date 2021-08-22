using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_GeneSelector : MonoBehaviour
{
	public e_GeneType gene;
	public Button btn;
	public Dropdown dd;

	Asteroid asteroid;

	UI_GeneSelector(Button _btn, Dropdown _dd, e_GeneType _gene = e_GeneType.None)
	{
		gene = _gene;
		btn = _btn;
	}

	void Start()
    {
		dd = GetComponentInChildren<Dropdown>();
    }

    void Update()
    {
        
    }

	void InitDropdown(Dropdown _dropdown, List<string> _items)
	{
		_dropdown.ClearOptions();
		_dropdown.AddOptions(_items);
	}

	void InitDropdownFromGenes(Dropdown _dropdown, List<e_GeneType> _genes)
	{
		InitDropdown(_dropdown, (from g in _genes select g.ToString()).ToList());
	}
}
