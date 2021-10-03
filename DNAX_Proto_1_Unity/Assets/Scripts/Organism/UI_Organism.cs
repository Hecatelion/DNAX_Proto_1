using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Organism : MonoBehaviour
{
	Organism organism;

	[SerializeField] Text hpText;
	[SerializeField] GameObject dna;
	[SerializeField] GameObject genePrefab;

	List<GameObject> genes;

    void Start()
    {
		organism = GetComponentInParent<Organism>();
		UpdateDNA();
	}

    void Update()
    {
		UpdateHP();
    }

	void UpdateHP()
	{
		int upRoundedHP = (int)((int)(organism.Stats.HpCur) + 0.99f);
		hpText.text = upRoundedHP.ToString(); // int cast will round down HpCur, to round up : (int) (x + 0.99f)
	}

	void UpdateDNA()
	{
		genes = new List<GameObject>();

		//delete last genes (foreach (gene) destroy)

		for (int i = 0; i < organism.Dna.Genes.Count; i++)
		{
			GameObject temp = Instantiate(genePrefab, dna.transform);
			temp.GetComponent<RectTransform>().localPosition = new Vector2(0, i * -genePrefab.GetComponent<RectTransform>().rect.height);
			temp.GetComponentInChildren<Text>().text = organism.Dna.Genes[i].ToString();
		}
	}
}
