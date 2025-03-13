using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossNormalAttackState : BossBaseState
{
    public BossNormalAttackState(BossStateMachine currentContext,BossStateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        if(_context.AnimatorIsPlaying(0.7f)){
            SwitchState(_factory.Idle());
        }
    }

    public override void EnterState()
    {
        _exitState = false;
        //_context.Anim.CrossFade("normalAttack",1);
        _context.Anim.Play("normalAttack");
    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        if(_exitState){
            return;
        }
        CheckSwitchState();
    }
}
