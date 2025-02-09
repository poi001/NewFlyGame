using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fileName : 생성되는 에셋의 이름
//menuName: 에셋을 생성하는 메뉴의 이름.  "/" 를 넣으면 경로가 추가.
//order : 메뉴 중에서 몇 번째 위치에 표시될지 정하는 값.값이 클 수록 마지막에 표기.
[CreateAssetMenu(fileName = "StatSO", menuName = "NewFlyGame/StatSO/Defalut", order = 0)]
public class StatScriptableObject : ScriptableObject
{
    [Header("Stat Info")]
    public string characterName;
    public string description;
    public int maxSpeed;
    public float weight;
    public int maxHP;
    public int maxMP;
}
