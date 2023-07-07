using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField]
    private ScriptableCharacterStat playerStats;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public ScriptableCharacterStat GetStats() => playerStats;
}
