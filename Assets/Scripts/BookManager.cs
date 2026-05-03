using UnityEngine;
using UnityEngine.UI;


public class BookManager : MonoBehaviour
{




    public GameObject[] pages;
    private int currentPage = 0;

    public bool isBookOpen = false;

    public Transform openBookPosition;
    public Transform closedBookPosition;

    public float openCloseSpeed = 2f;

    public Animator anim;
    public GameObject backButton;

    public void BookOpenClose()
    {
        isBookOpen = !isBookOpen;
    }

    public void Update()
    {
        if (isBookOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openBookPosition.position, Time.deltaTime * openCloseSpeed);
            backButton.SetActive(true);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedBookPosition.position, Time.deltaTime * openCloseSpeed);
            backButton.SetActive(false);

        }
    }

    public void PageChange(int direction)
    {
        
        if (currentPage + direction < 0 || currentPage + direction >= pages.Length)
        {
            return;
        }
        else
        {
            pages[currentPage].SetActive(false);
        }
        currentPage += direction;


        anim.SetTrigger("NextPage");

         pages[currentPage].SetActive(true);
        


        
    }

    public void Start()
    {
        pages[currentPage].SetActive(true);
    }

  



}
