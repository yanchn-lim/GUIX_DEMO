using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMState
{
    public FSMState PreviousState { get; set; } = null;

    protected FSM mFsm;
    protected int mId;

    public int ID { get { return mId; } }

    public FSMState()
    {
        mId = -1;
    }
    public FSMState(FSM fsm)
    {
        mId = -1;
        mFsm = fsm;
    }
    public FSMState(FSM fsm, int id)
    {
        mId = id;
        mFsm = fsm;
    }


    public virtual void Enter() { }

    public virtual void Exit() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }
}

public class FSM
{
    protected Dictionary<int, FSMState> m_states = new Dictionary<int, FSMState>();

    public Dictionary<int, FSMState> States { get { return m_states; } }

    protected FSMState m_currentState;

    public FSM()
    {
    }

    public void Add(FSMState state)
    {
        m_states.Add(state.ID, state);
    }

    public void Add(int key, FSMState state)
    {
        m_states.Add(key, state);
    }

    public FSMState GetState(int key)
    {
        return m_states[key];
    }

    public void SetCurrentState(int key)
    {
        SetCurrentState(GetState(key));
    }

    public FSMState GetCurrentState()
    {
        return m_currentState;
    }

    public void SetCurrentState(FSMState state)
    {
        if (m_currentState != null)
        {
            m_currentState.Exit();
            state.PreviousState = m_currentState;
        }

        m_currentState = state;

        if (m_currentState != null)
        {
            m_currentState.Enter();
        }
    }

    public void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.Update();
        }
    }

    public void FixedUpdate()
    {
        if (m_currentState != null)
        {
            m_currentState.FixedUpdate();
        }
    }
}
