using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//fileName : �����Ǵ� ������ �̸�
//menuName: ������ �����ϴ� �޴��� �̸�.  "/" �� ������ ��ΰ� �߰�.
//order : �޴� �߿��� �� ��° ��ġ�� ǥ�õ��� ���ϴ� ��.���� Ŭ ���� �������� ǥ��.
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
