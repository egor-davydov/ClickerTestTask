using System.Collections.Generic;
using UnityEngine;

namespace Fluxy
{
    public interface IFluxyTargetProvider
    {
        List<FluxyTarget> GetTargets();
    }

    [DisallowMultipleComponent]
    [RequireComponent(typeof(FluxyContainer))]
    public abstract class FluxyTargetProvider : MonoBehaviour, IFluxyTargetProvider
    {
        public abstract List<FluxyTarget> GetTargets();
    }
}
