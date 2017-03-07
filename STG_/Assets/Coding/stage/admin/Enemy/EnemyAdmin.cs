using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="enemy")]
public class EnemyAdmin : ScriptableObject
{
    public GameObject enemyObject;
    public GameObject hiteffect;
    public EnemyStatesAdmin enemyStates;
    public BarrageAdmin[] useBarrages;

    public ThwSrptAdm_enm useScripts;
}
