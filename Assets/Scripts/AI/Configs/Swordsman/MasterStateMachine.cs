﻿using AI.Base;
using AI.Common.Events;
using AI.Common.Roam;
using AI.Configs.Swordsman.Fight;
using AI.Interaction;
using UnityEngine;
using Utils.Math;

namespace AI.Configs.Swordsman
{
    public class MasterStateMachine : StateMachine
    {
        private readonly FightStateMachine FightStateMachine;

        private readonly RoamStateMachine RoamStateMachine;

        public MasterStateMachine(GameObject agent, GameObject enemy,
            SpottingManager spottingManager,
            AnimationNotifier animationNotifier)
        {
            var movementNotifier = new MovementNotifier();

            RoamStateMachine = new RoamStateMachine(agent, new Range(1, 2), new Range(1, 2));
            FightStateMachine = new FightStateMachine(agent, movementNotifier,
                animationNotifier, enemy);

            MergeCore(this, RoamStateMachine);
            MergeCore(this, FightStateMachine);

            InitRoamToFightTransition(spottingManager);

            EntryState = RoamStateMachine.EntryState;
        }

        private void InitRoamToFightTransition(SpottingManager spottingManager)
        {
            var roamToFightDecision = new RoamToFightDecision(spottingManager);
            var roamToFightTransition = new Transition(roamToFightDecision,
                FightStateMachine.EntryState);
            RoamStateMachine.AddTransitionToAllStates(roamToFightTransition);
        }
    }
}