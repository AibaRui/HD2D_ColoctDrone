using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class PlayerDronnStateMachine : StateMachine
{

    #region State
    [SerializeField]
    private DronnIdleState _stateIdle = default;

    [SerializeField] private DronnMoveState _moveState = default;

    //[SerializeField]
    //private WalkState _stateWalk = default;
    //[SerializeField]
    //private RunState _stateRun = default;
    //[SerializeField]
    //private JumpState _stateJump = default;
    //[SerializeField]
    //private UpAirState _stateUpAir = default;
    //[SerializeField]
    //private DownAirState _stateDownAir = default;
    //[SerializeField]
    //private SwingState _stateSwing = default;
    //[SerializeField]
    //private ZipState _stateZip = default;
    //[SerializeField]
    //private StateWallIdle _stateWallIdle = default;
    //[SerializeField]
    //private StateWallRun _stateWallRun = default;
    //[SerializeField]
    //private GrappleState _stateGrapple = default;
    //[SerializeField]
    //private SetUpState _stateGrappleSetUp = default;
    //[SerializeField]
    //private AttackState _stateAttack = default;
    //[SerializeField]
    //private AvoidState _stateAvoid = default;
    //[SerializeField]
    //private WallRunUpZipState _stateWallRunUpZip = default;
    //[SerializeField]
    //private StateWallStep _stateWallRunStep = default;

    private PlayerDronnControl _playerController = null;
    public PlayerDronnControl PlayerController => _playerController;
    public DronnIdleState StateIdle => _stateIdle;
    public DronnMoveState MoveState => _moveState;

    //public WalkState StateWalk => _stateWalk;
    //public JumpState StateJump => _stateJump;
    //public UpAirState StateUpAir => _stateUpAir;

    //public SwingState StateSwing => _stateSwing;

    //public DownAirState StateDownAir => _stateDownAir;
    //public RunState StateRun => _stateRun;
    //public ZipState StateZip => _stateZip;
    //public PlayerControl PlayerController => _playerController;
    //public StateWallIdle StateWallIdle => _stateWallIdle;
    //public StateWallRun StateWallRun => _stateWallRun;
    //public GrappleState StateGrapple => _stateGrapple;
    //public SetUpState StateGrappleSetUp => _stateGrappleSetUp;
    //public AttackState AttackState => _stateAttack;
    //public AvoidState AvoidState => _stateAvoid;
    //public WallRunUpZipState WallRunUpZipState => _stateWallRunUpZip;
    //public StateWallStep WallRunStep => _stateWallRunStep;


    #endregion
    [SerializeField]
    //private GroundCheck _groundCheck;
    //public GroundCheck GroundCheck => _groundCheck;

    public void Init(PlayerDronnControl playerController)
    {
        _playerController = playerController;
        Initialize(_stateIdle);
    }

    protected override void StateInit()
    {
        _stateIdle.Init(this);
        _moveState.Init(this);
        //_stateWalk.Init(this);
        //_stateJump.Init(this);
        //_stateUpAir.Init(this);
        //_stateDownAir.Init(this);
        //_stateSwing.Init(this);
        //_stateRun.Init(this);
        //_stateZip.Init(this);
        //_stateWallIdle.Init(this);
        //_stateWallRun.Init(this);
        //_stateGrapple.Init(this);
        //_stateGrappleSetUp.Init(this);
        //_stateAttack.Init(this);
        //_stateAvoid.Init(this);
        //_stateWallRunUpZip.Init(this);
        //_stateWallRunStep.Init(this);
    }

}
