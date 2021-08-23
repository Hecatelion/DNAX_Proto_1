using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System;

public class UI_GeneSelector : MonoBehaviour
{
	public e_GeneType gene;
	public Button btn;
	public Dropdown dd;

	Asteroid asteroid;

	void Start()
    {
		this.asteroid = GetComponentInParent<Asteroid>();
		this.dd.gameObject.SetActive(false);

		SetGene(e_GeneType.None);
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
		List<e_GeneType> genes = new List<e_GeneType>();
		genes.Add(e_GeneType.None);
		genes.AddRange(_genes);

		InitDropdown(_dropdown, (from g in genes select g.ToString()).ToList());
	}

	void SetGene(e_GeneType _g)
	{
		gene = _g;
		btn.GetComponentsInVeryChildren<Text>()[0].text = gene.ToString(); // add an exception : if (none) text = "empty"
	}

	// UI Functions

	public void BUTTON_OpenGeneSelection()
	{
		this.dd.gameObject.SetActive(true);

		InitDropdownFromGenes(this.dd, this.asteroid.GeneStorage);
		dd.SetValueFormString(gene.ToString());
	} 

	public void DROPDOWN_SelectGene()
	{
		SetGene((e_GeneType)Enum.Parse(typeof(e_GeneType), dd.captionText.text));

		this.dd.gameObject.SetActive(false);
	}
}
