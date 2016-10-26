using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour {
    
    public int MaxSpeed;

    public int offset;

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




        if (Input.GetButtonDown("Fire1")) {


            //获取鼠标点击的屏幕左边转成世界坐标
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            float v = Input.mousePosition.x;

            float h = Input.mousePosition.y;

            Debug.Log("MOUSE CLICK ON SCREEN(" + v + "," + h + ")");

            Vector3 target = ray.origin;

            target.z = 0;

            Debug.Log("MOUSE CLICK ON WORLD (" + target.x + "," + target.y + ")");

            if (this.state != State.STATE_MOVE)
            {
                //非空闲状态，先设置为空闲状态
                animator.SetInteger("state", State.STATE_MOVE.GetHashCode());
                this.state = State.STATE_MOVE;
            }
            this.target = target;
        }


        if (this.state == State.STATE_MOVE) {

            //未设置目标
            if (target == null) {
                return; 
            }

            Vector3 currentPostion = transform.position;
            Vector3 targetPostion = target;

            //已抵达目的地
            if (target == currentPostion) {
                state = State.STATE_IDLE;
                return;    
            }

            Vector3 dis = targetPostion - currentPostion;

            float currentX = currentPostion.x;
            float currentY = currentPostion.y;

            float targetX = target.x;
            float targetY = target.y;

            Direct direction = 0;
            if (targetX < currentX)
            {
                //左侧
                if (targetY == currentY)
                {
                    direction = Direct.DIRECT_6;
                }
                else if (targetY > currentY)
                {
                    direction = Direct.DIRECT_7;
                }
                else
                {
                    direction = Direct.DIRECT_5;
                }

            }
            else if (targetX > currentX)
            {
                //右侧
                //左侧
                if (targetY == currentY)
                {
                    direction = Direct.DIRECT_2;
                }
                else if (targetY > currentY)
                {
                    direction = Direct.DIRECT_1;
                }
                else
                {
                    direction = Direct.DIRECT_3;
                }

            }
            else{
                 if (targetY > currentY)
                {
                    direction = Direct.DIRECT_8;
                }
                else if (targetY > currentY)
                {
                    direction = Direct.DIRECT_4;
                }
            }

            if (this.direct != direction)
            {
                //如果需要改变方向
                if (state != State.STATE_DIE)
                {
                    //非空闲状态，先设置为空闲状态
                    animator.SetInteger("state", State.STATE_IDLE.GetHashCode());
                    this.state = State.STATE_IDLE;
                }
                //改变方向
                animator.SetInteger("direct", direction.GetHashCode());
                this.direct = direction;

                //改为move状态
                animator.SetInteger("state", State.STATE_MOVE.GetHashCode());
                this.state = State.STATE_MOVE;

            }else {
                //不需要改变方向
                //移动
                //currentPostion += dis * Time.deltaTime*MaxSpeed;
                //transform.position=(currentPostion);
                iTween.MoveTo(gameObject, target, 10.0f);
            }
        }
	}

    public void moveTo(Vector3 target) {
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
