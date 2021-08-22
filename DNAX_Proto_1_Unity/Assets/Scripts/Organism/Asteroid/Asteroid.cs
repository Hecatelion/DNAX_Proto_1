using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
	GameObject uiGO;
	ClickableModel model;

	List<e_GeneType> geneStorage;
	public List<e_GeneType> GeneStorage { get=>geneStorage; }

    void Start()
    {
		this.uiGO = GetComponentInChildren<UI_Asteroid>().gameObject;
		this.model = GetComponentInChildren<ClickableModel>();

		this.uiGO.SetActive(false);
		this.model.onClick += OpenUI;

		geneStorage = new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.Heal, e_GeneType.Spikes };
    }

    void Update()
    { }

	private void OpenUI()
	{
		this.uiGO.SetActive(true);
	}
}
