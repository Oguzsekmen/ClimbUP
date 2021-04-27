using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectible
{
    bool OnCollect(PlayerControllerForFinalAnimations playerController);
}
