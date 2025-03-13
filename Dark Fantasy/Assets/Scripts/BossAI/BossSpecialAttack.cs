using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttack : BossBaseState
{
    public BossSpecialAttack(BossStateMachine currentContext,BossStateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        if(_context.AnimatorIsPlaying()){
            SwitchState(_factory.Idle());
        }
    }

    public override void EnterState()
    {
        _exitState = false;
        //_context.Anim.CrossFade("specialAttack",1);
        _context.Anim.Play("specialAttack");
    }

    public override void ExitState()
    {
        //throw new System.NotImplementedException();
    }

    public override void UpdateState()
    {
        if(_exitState){
            return;
        }
        CheckSwitchState();
    }
}
