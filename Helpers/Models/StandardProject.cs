using System;

namespace FreelanceTaskManager.Models
{
    /// <summary>
    /// Звичайний проєкт, для якого діє основний дедлайн.
    /// </summary>
    public sealed class StandardProject : Project
    {
        public override string ProjectCategory => "Звичайний";

        public override DateTime GetEffectiveDeadline()
        {
            return Deadline;
        }
    }
}
