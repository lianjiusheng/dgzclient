using UnityEngine;
using System.Collections;

public class Hero{

    public int HeroId { get; set; }

    public string HeroHead { get; set; }

    public string HeroName { get; set; }

    public HeroSkill Skill { get; set; }

    public int Hp { get; set; }

    public int Atk { get; set; }

    public int Def { get; set; }

    public int Speed { get; set; }


    public static Hero create(int heroId, string heroHead, string heroName,int hp,int atk,int def,int speed,HeroSkill skill) {

        Hero hero = new Hero();

        hero.HeroId = heroId;
        hero.HeroHead = heroHead;
        hero.HeroName = heroName;
        hero.Hp = hp;
        hero.Atk = atk;
        hero.Def = def;
        hero.Speed = speed;
        hero.Skill = skill;

        return hero;
    }

}
