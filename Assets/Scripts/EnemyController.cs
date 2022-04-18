using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

   public enum STATE { LOOKFOR,GOTO,ATTACK,DEAD}
    public STATE currentState=STATE.LOOKFOR;
    public float enemySpeed;
    public float goToDistance;   
    public float attackDistance;
    public Transform target;
    public string playerTag;
    public float attackTime;
    public float currentTime;
    PlayerController playerController;
    

    // Start is called before the first frame update
  /* private  void Start()
    {
        StartCoroutine("Starts");
    }*/



    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Starts()
    {
        currentTime = attackTime;
        if(target != null)
        {
            playerController=target.GetComponent<PlayerController>();   
        }
        while(true)
        {
           switch(currentState)
            {
                case STATE.LOOKFOR:
                    LookFor();
                    break;
                    case STATE.GOTO:
                    GOTO();
                    break;
                case STATE.ATTACK:
                    ATTACK();
                    break;

                case STATE.DEAD:
                    DEAD();
                    break;

                default:
                    break;
            }
            yield return 0;
        }
       
    }

    public void LookFor()
    {
        if(Vector3.Distance(transform.position, target.position) < goToDistance)
        {
            currentState = STATE.GOTO;
        }
        Debug.Log("This a LOOKFOR Method");
    }

    public void GOTO()
    {

        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            transform.position =Vector3.MoveTowards(transform.position,target.transform.position,enemySpeed*Time.deltaTime);
        }
        else
        {
            currentState=STATE.ATTACK;
        }
        Debug.Log("GOTO METHOD");
    }

    public void ATTACK()
    {
        currentTime=currentTime-Time.deltaTime;
        if(currentTime < 0f)
        {
            playerController.health--;
            currentTime =attackTime;
        }
        if(playerController.health < 0)
        {
            currentState= STATE.DEAD;
        }
        if (Vector3.Distance(transform.position, target.position) < attackDistance)
        {
            currentState = STATE.GOTO;
        }
            Debug.Log("ATTACK METHOD");
    }

    public void DEAD()
    {
        Debug.Log("GAME OVER");
    }
}
