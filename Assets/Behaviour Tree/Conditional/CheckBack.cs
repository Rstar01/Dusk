using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class CheckBack : EnemyConditionalBase
{
    public SharedTransform Target;
    public float Range = 5f;

 

    public override TaskStatus OnUpdate()
    {
        float targetX = this.Target.Value.transform.position.x;
        float selfX = this.transform.position.x;
        
        if (this.Target.IsShared && Mathf.Abs(targetX - selfX) <= Range)
        {
            if ( targetX > selfX && this.SelfCharacter.Value.Facing!=1 ||
                 targetX < selfX && this.SelfCharacter.Value.Facing!=-1)
            {
                Debug.Log("CheckBack");
                return TaskStatus.Success;
            }
        }
        if(this.SelfCharacter.Value.isActing)
            return TaskStatus.Running;
        return TaskStatus.Failure;
    }
}
