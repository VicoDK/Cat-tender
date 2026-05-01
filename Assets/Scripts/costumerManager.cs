using UnityEngine;


public class costumerManager : MonoBehaviour
{
    public GameObject costumerPrefab;   
    public Transform spawnPoint;
    public Transform barCenter;
    public Transform exitPoint;
    public BarManager barManager;
    public bool testbool = false;

    public void SpawnCostumer()
    {
        GameObject costumer = Instantiate(costumerPrefab, spawnPoint.position, Quaternion.identity);
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
