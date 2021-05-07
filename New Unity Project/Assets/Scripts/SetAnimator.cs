using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimator : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private Animator_Ovveride overrider;

    public void Set(int value)
    {
        overrider.SetAnimations(overrideControllers[value]);
    }
}
