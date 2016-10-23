using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HeroTopInfo : MonoBehaviour {

    public Text HeroName;
    public Image Head;
    public Image Contry;

    private Team team;

    public void setTeam(Team team) {
        this.team=team;
        setHeroName(team.TeamName);
        setHeadImg(team.LeaderHead);
        setCountry(team.Country);
    }

    public void setHeroName(string name) {
        this.HeroName.text = name;
    }

    public void setHeadImg(string headImg) {
        this.Head.sprite = Resources.Load<Sprite>("herohead50/"+ headImg);
    }

    public void setCountry(string country) {
        this.Contry.sprite= Resources.Load<Sprite>("battle/" + country);

    }
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
