using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ScriptableCharacterStat : ScriptableObject
{
    [SerializeField]
    private Sprite baseSprite;

    [SerializeField]
    private int _life;

    public int getHealth()
    {
        return _life;
    }
    public void setHealth(int life)
    {
        _life = life;
    }

}
