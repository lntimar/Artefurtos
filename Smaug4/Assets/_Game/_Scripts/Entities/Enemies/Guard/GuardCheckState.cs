using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardCheckState : GuardState
{
    #region Vari�veis Globais
    private Vector3 _checkPos;
    private GuardBehaviour _guardBehaviour;
    #endregion

    #region Fun��es Pr�prias
    public GuardCheckState(Vector3 checkPos, GuardBehaviour guardBehaviour)
    {
        this._checkPos = checkPos;
        this._guardBehaviour = guardBehaviour;
    }

    public override void Execute()
    {
        base.Execute();
        base.StateMachine.Agent.SetDestination(_checkPos);

        if (HasReachPoint())
            _guardBehaviour.ReachedCheckPos();
    }
    #endregion
}
