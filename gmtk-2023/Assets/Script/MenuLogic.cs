using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuLogic : MonoBehaviour
{
    [SerializeField]
    private GameObject Button;

    [SerializeField]
    private MobTurnManager mobTurnManager;

    private void Start()
    {
        //mobTurnManager = TurnManager.GetComponent<MobTurnManager>();
    }
    public void deleteAllButton()
    {
        foreach (Button button in gameObject.GetComponentsInChildren<Button>())
        {
            Destroy(button.gameObject);
        }
    }

    public void SetMenu(Entity entity)
    {
        Debug.Log("Set Menu");
        
        deleteAllButton();

        int attackOptionNb = entity.Stats.Attacks.Count;
        
        float width = gameObject.GetComponent<RectTransform>().rect.width;
        float height = gameObject.GetComponent<RectTransform>().rect.height;

        if (attackOptionNb == 1)
        {
            GameObject button = Instantiate(Button, gameObject.transform);
            Button buttonComp = button.GetComponent<Button>();
            buttonComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[0]); });
            button.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[0].AttackName;
            RectTransform rt = button.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2((width / 2)-(rt.sizeDelta.x/2), (height / 2)- (rt.sizeDelta.y / 2));
        }
        else if (attackOptionNb == 2)
        {
            for (int i = 0; i < attackOptionNb; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                Button buttonComp = button.GetComponent<Button>();
                int x = i;
                buttonComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[x]); });
                button.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[i].AttackName;
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2(((width / 3)*(i+1)) - (rt.sizeDelta.x / 2), (height / 2) - (rt.sizeDelta.y / 2));
            }

        }
        else if (attackOptionNb == 3) { 
            for (int i =0; i<2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                Button buttonComp = button.GetComponent<Button>();
                int x = i;
                buttonComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[x]); });
                button.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[i].AttackName;
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 1.5f - (rt.sizeDelta.y / 2));
            }
            GameObject buttonBottom = Instantiate(Button, gameObject.transform);
            Button buttonBottomComp = buttonBottom.GetComponent<Button>();
            buttonBottomComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[2]); });
            buttonBottom.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[2].AttackName;
            RectTransform rtBottom = buttonBottom.GetComponent<RectTransform>();
            rtBottom.anchoredPosition = new Vector2((width / 2) - (rtBottom.sizeDelta.x / 2), (height / 3f) - (rtBottom.sizeDelta.y / 2));
        }
        else if (attackOptionNb == 4)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                Button buttonComp = button.GetComponent<Button>();
                int x = i;
                buttonComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[x]); });
                button.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[i].ToString();
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 1.5f - (rt.sizeDelta.y / 2));
            }
            for (int i = 0; i < 2; i++)
            {
                GameObject button = Instantiate(Button, gameObject.transform);
                Button buttonComp = button.GetComponent<Button>();
                int x = i;
                buttonComp.onClick.AddListener(() => { deleteAllButton(); mobTurnManager.Attack(entity.Stats.Attacks[x]); });
                button.GetComponentInChildren<TMP_Text>().text = entity.Stats.Attacks[i].ToString();
                RectTransform rt = button.GetComponent<RectTransform>();
                rt.anchoredPosition = new Vector2((width / 3) * (i + 1) - (rt.sizeDelta.x / 2), height / 3.6f - (rt.sizeDelta.y / 2));
            }
        }
    }
}
