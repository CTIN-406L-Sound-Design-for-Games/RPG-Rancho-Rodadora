using System.Collections;
using System.Collections.Generic;
using CreatorKitCode;
using UnityEngine;

namespace CreatorKitCodeInternal
{
    public class CharacterAudio : MonoBehaviour
    {
        public AudioClip[] FootstepClips;
        public AK.Wwise.Event FootstepEvent;
        public AudioClip[] VocalAttack;
        public AK.Wwise.Event VocalAttackEvent;

        public AudioClip[] VocalHit;

        public AK.Wwise.Event VocalHitEvent;

        public AudioClip[] DeathClips;
        public AK.Wwise.Event DeathEvent;

        public SFXManager.Use UseType;

        public void Attack(Vector3 position)
        {
            if (VocalAttack.Length == 0)
                return;

            SFXManager.PlaySound(UseType, new SFXManager.PlayData()
            {
                Clip = VocalAttack[Random.Range(0, VocalAttack.Length)],
                Position = position,
            });

            VocalAttackEvent.Post(this.gameObject);
        }

        public void Hit(Vector3 position)
        {
            if (VocalHit.Length == 0)
                return;

            SFXManager.PlaySound(UseType, new SFXManager.PlayData()
            {
                Clip = VocalHit[Random.Range(0, VocalHit.Length)],
                Position = position,
            });

            VocalHitEvent.Post(this.gameObject);
        }

        public void Step(Vector3 position)
        {
            if (FootstepClips.Length == 0)
                return;

            SFXManager.PlaySound(UseType, new SFXManager.PlayData()
            {
                Clip = FootstepClips[Random.Range(0, FootstepClips.Length)],
                Position = position,
                PitchMin = 0.8f,
                PitchMax = 1.2f,
                Volume = 0.3f
            });

            FootstepEvent.Post(this.gameObject);
        }

        public void Death(Vector3 position)
        {
            if (DeathClips.Length == 0)
                return;

            SFXManager.PlaySound(UseType, new SFXManager.PlayData()
            {
                Clip = DeathClips[Random.Range(0, DeathClips.Length)],
                Position = position
            });

            DeathEvent.Post(this.gameObject);
        }
    }
}