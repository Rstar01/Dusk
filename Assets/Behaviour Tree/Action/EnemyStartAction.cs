using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class EnemyStartAction : EnemyActionBase
{
    public SharedTransform Target;
    
    public ActionBaseObj Action;

    public bool Flip;

    public bool CheckFacing;
    
    private bool Fail;
    
    public override void OnStart()
    {
        this.Fail=(this.SelfCharacter.Value.Airbrone || this.SelfCharacter.Value.isDead);
        if (!this.Fail)
        {
            this.SelfCharacter.Value.StartAction(this.Action);
        }
        if(CheckFacing)
            this.SelfCharacter.Value.Facing = (this.Target.Value.transform.position.x - this.transform.position.x> 0) ? 1 : -1;
    }

    public override TaskStatus OnUpdate()
    {
        if (this.Fail)
        {
            return TaskStatus.Failure;
        }
        if (this.SelfCharacter.Value.isActing)
        {
            return TaskStatus.Running;
        }
        return TaskStatus.Success;
    }

    public override void OnEnd()
    {
        if (Flip && !(this.SelfCharacter.Value.isActing))
        {
            this.SelfCharacter.Value.Facing *= -1;
        }
    }
}
