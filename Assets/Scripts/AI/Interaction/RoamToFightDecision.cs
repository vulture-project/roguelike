﻿using System;
using AI.Base;

namespace AI.Interaction
{
    public class RoamToFightDecision : ADecision
    {
        private bool _enemySpotted;

        public RoamToFightDecision(SpottingManager spottingManager)
        {
            spottingManager.EnemySpotted += OnEnemySpotted;
        }

        public override bool Decide()
        {
            if (_enemySpotted)
            {
                _enemySpotted = false;
                return true;
            }

            return false;
        }

        private void OnEnemySpotted(object sender, EventArgs args)
        {
            _enemySpotted = true;
        }
    }
}