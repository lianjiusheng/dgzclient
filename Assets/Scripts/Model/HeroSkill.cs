using UnityEngine;
using System.Collections;

public class HeroSkill{
    public int SkillId { get; set; }

    public string SkillName { get; set; } 

    public static HeroSkill create(int skillId,string skillName)
    {
        HeroSkill skill = new HeroSkill();
        skill.SkillId = skillId;
        skill.SkillName = skillName;
        return skill;
    }

}
