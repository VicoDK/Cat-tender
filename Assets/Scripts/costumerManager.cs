using UnityEngine;


public class costumerManager : MonoBehaviour
{
    public GameObject[] costumerPrefab;   
    public Transform spawnPoint;
    public Transform barCenter;
    public Transform exitPoint;
    public BarManager barManager;
    public bool testbool = false;
    public int custummerNumber;
    bool funded; 

    public void SpawnCostumer()
    {
        funded = false;
        while (!funded)
        {
            int number = Random.Range(0, costumerPrefab.Length);
            if (custummerNumber != number)
            {
                custummerNumber = number;
                funded = true;
            }
        }
        GameObject costumer = Instantiate(costumerPrefab[custummerNumber], spawnPoint.position, Quaternion.identity);
        costumer.GetComponent<costumer>().barCenter = barCenter;
        costumer.GetComponent<costumer>().exitPoint = exitPoint;
        costumer.GetComponent<costumer>().barManager = barManager;

    }

    public void Update()
    {
        if (testbool)
        {
            SpawnCostumer();
            testbool = false;
        }
    }

    



}
