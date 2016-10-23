using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleSceneController: MonoBehaviour {

    public SpriteRenderer bgRenderer        ;
    public Text attackCountText;
    public Text defencerCountText;
    public Text battleNameText;

    public HeroTopInfo attackInfo;

    public HeroTopInfo defencerInfo;

    public HeroSkillController heroSkill;


    // Use this for initialization
    void Start () {

        BattleManager.createBattle();

        Battle battle = BattleManager.getInstance().Current;

        battle.init();

        battleNameText.text = battle.BattleName;
        bgRenderer.sprite = Resources.Load<Sprite>(battle.Scene);

        attackCountText.text = battle.AttackCount + "队";
        defencerCountText.text = battle.DefencerCount + "队";

        attackInfo.setTeam(battle.Attacker);
        defencerInfo.setTeam(battle.Defencer);

        heroSkill.setHero((Hero)battle.Attacker.Heros[0]);

    }
	
	// Update is called once per frame
	void Update () {

        if (BattleManager.getInstance().Current!= null){
            BattleManager.getInstance().Current.execute();
        }
    }


    public void usePlayerSkill(int skillId) {
        Debug.Log("Use player  Skill:"+skillId);
    }

}
