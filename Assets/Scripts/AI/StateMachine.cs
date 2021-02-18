using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine
{
    private IState _currentState;
    private Dictionary<Type, List<Transition>> _transitions = new Dictionary<Type, List<Transition>>();
    private List<Transition> _currentTransitions = new List<Transition>();
    private List<Transition> _anyTransitions = new List<Transition>();
    //Below I am setting the list capacity to zero which is pretty cool
    private static List<Transition> EmptyTransitions = new List<Transition>(0);


    public void Tick()
    {
        var transition = GetTransition();
        if(transition != null)
        {
            SetState(transition.To);
        }
            
            _currentState?.Tick();
        
    }

    public void SetState(IState state)
    {
        if(state == _currentState)
        {
            //If the state we are setting is the current running state, we return out of this method and move on
            return;
        }

        //else
            //If the current state is NOT the new state, run the current states OnExit method and set the current state to the new one
        _currentState?.OnExit();
        _currentState = state;

        _transitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
        if (_currentTransitions == null)
        {
            _currentTransitions = EmptyTransitions;
        }
        //Then do this

        _currentState.OnEnter();  
    }

    //Will add a new connection for <from> state .from -----predicate----> to 
    public void AddTransition(IState from, IState to, Func<bool> predicate)
    {
        if (_transitions.TryGetValue(from.GetType(), out var transitions) == false)
        {
            //If the _transitions dictionary "From" key does not have any values, create a new Transition list and make it the value to that from Key
            //In other words, if current state doesnt have something to transition to , creates a new State and condition for it to go to
            //[Concenptualization] think of the Mechanim, this is basically saying if (example) <from>Walk state has no  <predicate/condition> connections then create a new connection to a new <To> state
            
            transitions = new List<Transition>();
            _transitions[from.GetType()] = transitions;
        }
        //Then do this
        transitions.Add(new Transition(to, predicate));
    }

    public void AddAnyTransition(IState state, Func<bool> predicate)
    {
        _anyTransitions.Add(new Transition(state, predicate));
    }
    private Transition GetTransition()
    {
        foreach (var transition in _anyTransitions)
        {
            if(transition.Condition())
            {
                return transition;
            }
        }

        foreach (var transition in _currentTransitions)
        {
            if (transition.Condition())
            {
                return transition;
            }
        }

        return null;
    }


private class Transition
{
    public Func<bool> Condition {get; }
    public IState To {get; }

    public Transition(IState to, Func<bool> condition)
    {
        To = to;
        Condition = condition;
    }
}

}