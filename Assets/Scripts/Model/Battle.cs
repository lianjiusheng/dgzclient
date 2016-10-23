using UnityEngine;
using System.Collections;

public class Battle {

    /// <summary>
    /// 战斗名称
    /// </summary>
    public string BattleName { get; set; }
    /// <summary>
    /// 场景
    /// </summary>
    public string Scene { get; set; }
    /// <summary>
    /// 攻击人数
    /// </summary>
    public int AttackCount { get; set; }
    /// <summary>
    /// 防御人数
    /// </summary>
    public int DefencerCount { get; set; }
    /// <summary>
    /// 战场状态
    /// </summary>
    public int Status { get; set; }


    public Team Attacker { get; set; }

    public Team Defencer { get; set; }

    /// <summary>
    /// 战斗初始
    /// </summary>
    public void init(){
        Debug.Log("Battle init...");

        

    }

    public void execute() {
        Debug.Log("Battle execute...");
    } 

}
