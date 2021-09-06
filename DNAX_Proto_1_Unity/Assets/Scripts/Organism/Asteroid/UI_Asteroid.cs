using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class UI_Asteroid : MonoBehaviour
{
	[SerializeField] RectTransform geneSelectionRect;

	Asteroid asteroid;

	[SerializeField] GameObject geneSelectorPrefab;
	public List<UI_GeneSelector> uiGeneSelectors;
	[SerializeField] GameObject addCellButton;

	void Start()
    {
		uiGeneSelectors = new List<UI_GeneSelector>();

		asteroid = GetComponentInParent<Asteroid>();

		addCellButton.GetComponent<RectTransform>().localPosition = Vector2.zero;
	}

	void Update() 
	{ }

	void UpdateAddCellButtonAvailability()
	{
		addCellButton.SetActive(!(uiGeneSelectors.Count == asteroid.Storage.NbCells));
	}

	void UpdateGeneSelectorsPosition()
	{
		float height = geneSelectorPrefab.GetComponent<RectTransform>().rect.height;

		for (int i = 0; i < uiGeneSelectors.Count; i++)
		{
			RectTransform rt = uiGeneSelectors[i].gameObject.GetComponent<RectTransform>();
			rt.localPosition = Vector2.down * height * i;
		}

		addCellButton.GetComponent<RectTransform>().localPosition = Vector2.down * height * uiGeneSelectors.Count;
	}

	void UpdateUIPosition()
	{
		UpdateGeneSelectorsPosition();
		UpdateAddCellButtonAvailability();
	}

	void AddCell()
	{
		GameObject newGeneSelector = Instantiate(geneSelectorPrefab, geneSelectionRect);
		UI_GeneSelector uiNewGS = newGeneSelector.GetComponent<UI_GeneSelector>();
		uiNewGS.Init();
		uiGeneSelectors.Add(uiNewGS);

		UpdateUIPosition();
	}

	public void RemoveCell(UI_GeneSelector _gs)
	{
		uiGeneSelectors.Remove(_gs);

		UpdateUIPosition();
	}

	void RemoveAllCells()
	{
		foreach (var gs in uiGeneSelectors)
		{
			Destroy(gs.gameObject);
		}

		uiGeneSelectors.Clear();

		UpdateUIPosition();
	}

	DNA GetDNAFromUIGeneSelectors()
	{
		List<e_GeneType> genes = new List<e_GeneType>();

		foreach (var selector in uiGeneSelectors)
		{
			genes.Add(selector.gene);
		}

		return new DNA(genes);
	}

#region ButtonFunctions

	public void BUTTON_SpawnOrganism()
	{
		DNA dna = GetDNAFromUIGeneSelectors();
		asteroid.SpawnOrganism(dna);

		RemoveAllCells();
	}

	public void BUTTON_AddCell()
	{
		AddCell();
	}

#endregion
}
