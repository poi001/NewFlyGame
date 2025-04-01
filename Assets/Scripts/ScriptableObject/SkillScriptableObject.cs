using JetBrains.Annotations;
using UnityEngine;

//fileName : �����Ǵ� ������ �̸�
//menuName: ������ �����ϴ� �޴��� �̸�.  "/" �� ������ ��ΰ� �߰�.
//order : �޴� �߿��� �� ��° ��ġ�� ǥ�õ��� ���ϴ� ��.���� Ŭ ���� �������� ǥ��.
[CreateAssetMenu(fileName = "SkillSO", menuName = "NewFlyGame/SkillSO", order = 1)]
public class SkillScriptableObject : ScriptableObject
{
    [Header("Skill Info")]
    public string SkillName;
    public string Description;
    public Sprite Sprite;
}
