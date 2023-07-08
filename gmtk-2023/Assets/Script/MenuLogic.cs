using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Button;

    [SerializeField]
    private GameObject EntityObject;

    private void Start()
    {
        

    }

    public void setEntityObject(GameObject currentPlayer)
    {
        EntityObject = currentPlayer;
        
    }

    private void setMenu(Entity entity)
    {

        
        int attackOptionNb = entity.Stats.Attacks.Count;
        
        float width = gameObject.GetComponent<RectTransform>().rect.width;
        float height = gameObject.GetComponent<RectTransform>().rect.height;

        if (attackOptionNb == 1)
        {
            GameObject button = Instantiate(Button, gameObject.transform);
            RectTransform rt = button.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2((width / 2)-(rt.sizeDelta.x/2), (height / 2)- (rt.sizeDelta.y / 2));
        }
        else if (attackOptionNb == 2)
        {
            for (int i = 0; i < attackOptionNb; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2(((width / 3)*(i+1)) - (rt.sizeDelta.x / 2), (height / 2) - (rt.sizeDelta.y / 2));
            }

        }
        else if (attackOptionNb == 3) { 
            for (int i =0; i<2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 1.5f - (rt.sizeDelta.y / 2));
            }
            GameObject buttonBottom = Instantiate(Button, gameObject.transform);
            RectTransform rtBottom = buttonBottom.GetComponent<RectTransform>();
            rtBottom.anchoredPosition = new Vector2((width / 2) - (rtBottom.sizeDelta.x / 2), (height / 3f) - (rtBottom.sizeDelta.y / 2));
        }
        else if (attackOptionNb == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 1.5f - (rt.sizeDelta.y / 2));
            }
            for (int i = 0; i < 2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 3.6f - (rt.sizeDelta.y / 2));
            }
        }
    }
}
