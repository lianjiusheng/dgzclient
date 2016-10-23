using UnityEngine;
using System.Collections;

public class BattleManager  {

    private BattleManager() { }

    private static BattleManager instance=new BattleManager();

    public Battle Current { get; set; }


    public static BattleManager getInstance() {
        return instance;
    }

    public static void createBattle() {

        HeroSkill skill1 = HeroSkill.create(1, "技能1");
        HeroSkill skill2 = HeroSkill.create(2, "技能2");

        Hero hero1 = Hero.create(1, "caimao", "英雄1", 1000, 50, 30, 20, skill1);
        Hero hero2 = Hero.create(2, "caocao", "英雄2", 1000, 50, 30, 20, skill2);

        Team team1 = Team.create(1, "caimao", "攻击方", "吴",new ArrayList());
        team1.addHero(hero1);

        Team team2 = Team.create(2, "caocao","防御方", "魏",new ArrayList());
        team1.addHero(hero1);

        Battle battle = new Battle();
        battle.BattleName = "来吧少年";
        battle.Scene = "101";
        battle.AttackCount = 1;
        battle.DefencerCount = 1;
        battle.Attacker = team1;
        battle.Defencer = team2;
        getInstance().Current = battle;
    }

}
