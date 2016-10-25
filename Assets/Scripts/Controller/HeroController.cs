using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {
    
    public int MaxSpeed;

    private Direct direct;
    private State state;
    public string spritName;
    private Animator animator;

    private Vector3 target;

    public enum State {
        STATE_IDLE=0,
        STATE_MOVE=1,
        STATE_ATTACK=2,
        STATE_WIN=3,
        STATE_DIE=4,
    }

    public enum Direct
    {
        DIRECT_1 = 1,
        DIRECT_2 = 2,
        DIRECT_3 = 3,
        DIRECT_4 = 4,
        DIRECT_5 = 5,
        DIRECT_6 = 6,
        DIRECT_7 = 7,
        DIRECT_8 = 8,
    }

    

    // Use this for initialization
    void Start () {
        state = State.STATE_IDLE;
        direct = Direct.DIRECT_1;
        animator = gameObject.GetComponent<Animator>();
        playAnimation();
    }
	
	// Update is called once per frame
	void Update () {



        if (this.state == State.STATE_MOVE) {

            //未设置目标
            if (target == null) {
                return; 
            }

            Vector3 currentPostion = transform.position;

            //以抵达目标
            if (target == currentPostion) {
                state = State.STATE_IDLE;
                return;    
            }

            Vector3 distance = target - currentPostion;

            






            int Xspeed = 0;
            int Yspeed = 0;


           
            

        }
	}

    public void moveTo(Vector2 target) {
        this.target = target;

    }


    public void playAnimation() {
        animator.SetInteger("direct",direct.GetHashCode());
        animator.SetInteger("state", state.GetHashCode());
    }

    private string getAnimationName() {
        return spritName + "_" + getStateName() + "_" + this.direct.GetHashCode();
    }

    private string getStateName() {


        switch (this.state)
        {
            case State.STATE_IDLE:
                return "idle";
            case State.STATE_MOVE:
                return "move";
            case State.STATE_ATTACK:
                return "attack";
            case State.STATE_DIE:
                return "die";
            case State.STATE_WIN:
                return "win";
            default:
                return "idle";
        }
    }
}
