using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [System.Serializable] public class CriteiaList 
    {
        public string CockTailName;
        public bool Umbrella;
        public string Prompt;
        

    }

    public string[] CockTailNames;

    public string[] Promts;

    public CriteiaList CriteiaCall()
    {
        return new CriteiaList { CockTailName = CockTailNames[Random.Range(0, CockTailNames.Length)], Umbrella = Random.value > 0.8f, Prompt = Promts[Random.Range(0, Promts.Length)] };
    } 
}
