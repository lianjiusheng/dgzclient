using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroSkillController : MonoBehaviour {

    private Hero hero;

    public Image HeroHead;

    public Text SkillNameText;

    public void setHero(Hero hero) {
        this.hero = hero;
        HeroHead.sprite = Resources.Load<Sprite>("herohead50/" + hero.HeroHead);
        SkillNameText.text = hero.Skill.SkillName;
    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void useSkill() {
        Debug.Log("["+ hero.HeroName + "]使用技能[" + hero.Skill.SkillName + "]");
    }
}
