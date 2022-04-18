using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

   public enum STATE { LOOKFOR,GOTO,ATTACK}
    public STATE currentState=STATE.LOOKFOR;
    public float enemySpeed;
    public float goToDistance;   
    public float attackDistance;
    public Transform target;
    public string playerTag;

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
        Debug.Log("GOTO METHOD");
    }

    public void ATTACK()
    {
        Debug.Log("ATTACK METHOD");
    }
}
