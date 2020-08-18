using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempOragnismBuilder : MonoBehaviour
{
    void Start()
    {
		DNA dna = new DNA(new List<e_GeneType> { e_GeneType.Photosynthesis, e_GeneType.None, e_GeneType.Photosynthesis });

		GameObject oragnismGO = Organism.InstantiateNewOrganism(dna);
    }
}
