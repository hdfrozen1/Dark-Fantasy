using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRushIn : BossBaseState
{
    public BossRushIn(BossStateMachine currentContext,BossStateFactory stateFactory):base(currentContext,stateFactory){
        
    }
    public override void CheckSwitchState()
    {
        if(_context.AnimatorIsPlaying(0.71f)){
            SwitchState(_factory.NormalAttack());
        }
    }

    public override void EnterState()
    {
        _exitState = false;
        //_context.Anim.CrossFade("rushInAttack",1);
        _context.Anim.Play("rushInAttack");
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
