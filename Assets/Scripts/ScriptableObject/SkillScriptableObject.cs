using UnityEngine;

//fileName : �����Ǵ� ������ �̸�
//menuName: ������ �����ϴ� �޴��� �̸�.  "/" �� ������ ��ΰ� �߰�.
//order : �޴� �߿��� �� ��° ��ġ�� ǥ�õ��� ���ϴ� ��.���� Ŭ ���� �������� ǥ��.
[CreateAssetMenu(fileName = "SkillSO", menuName = "NewFlyGame/SkillSO", order = 1)]
public class SkillScriptableObject : ScriptableObject
{
    [Header("Stat Info")]
    public string characterName;
    public string description;
    public int maxSpeed;
    public int startSpeed;
    public int weight;
    public int maxHP;
    public int maxMP;
}
