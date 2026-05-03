using System.Collections.Generic;
using UnityEngine;


public class costumerManager : MonoBehaviour
{
    public GameObject[] costumerPrefab;   
    public Transform spawnPoint;
    public Transform barCenter;
    public Transform exitPoint;
    public BarManager barManager;

    public int custummerNumber;
    bool funded; 
    List<GameObject> custom = new List<GameObject>();

    public void SpawnCostumer()
    {
        // Pick a random customer that's different from the last one
        int number;
        do
        {
            number = Random.Range(0, costumerPrefab.Length);
        } while (number == custummerNumber && costumerPrefab.Length > 1);
        
        custummerNumber = number;
        
        GameObject costumer = Instantiate(costumerPrefab[custummerNumber], spawnPoint.position, Quaternion.identity);
        costumer.GetComponent<costumer>().barCenter = barCenter;
        costumer.GetComponent<costumer>().exitPoint = exitPoint;
        costumer.GetComponent<costumer>().barManager = barManager;
        custom.Add(costumer);

    }

    public void Reset()
    {
        foreach(GameObject cus in custom)
        {
            Destroy(cus);
        }
        SpawnCostumer();
    }







}
