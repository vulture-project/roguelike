﻿using UnityEngine;
using System;

namespace AI.Common.Animations
{
    public class BaseAnimationNotifier : MonoBehaviour
    {
        public event EventHandler AttackStartedEvent;
        public event EventHandler AttackFinishedEvent;
 
        public event EventHandler HitStartedEvent;
        public event EventHandler RecoveredFromHitEvent;

        public event EventHandler StartedDyingEvent;
        public event EventHandler DiedEvent;

        public void AttackStarted()
        {
            AttackStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void AttackFinished()
        {
            AttackFinishedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void HitStarted()
        {
            HitStartedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void RecoveredFromHit()
        {
            RecoveredFromHitEvent?.Invoke(this, EventArgs.Empty);
        }

        public void StartedDying()
        {
            // Debug.Log("started dying in notifier");
            StartedDyingEvent?.Invoke(this, EventArgs.Empty);
        }

        public void Died()
        {
            // Debug.Log("Died in notifier");
            DiedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}