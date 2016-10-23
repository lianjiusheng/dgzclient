using UnityEngine;
using System.Collections;

public class Team {

    public long LeaderId { get; set; }
    public string LeaderHead { get; set; }
    public string Country { get; set; }
    public string TeamName { get; set; }
    public ArrayList Heros { get; set; }


    public static Team create(long leaderId,string leaderHead,string teamName,string country,ArrayList heros)
    {
        Team team = new Team();
        team.LeaderId = leaderId;
        team.TeamName = teamName;
        team.Heros = heros;
        team.LeaderHead = leaderHead;
        team.Country = country;
        return team;
    }

    public void addHero(Hero hero) {
        ArrayList tmp = Heros;
        if (tmp != null)
        {
            tmp.Add(hero);
        }
        else
        {
            tmp = new ArrayList();
            tmp.Add(hero);
            Heros = tmp;
        }
    }

}
