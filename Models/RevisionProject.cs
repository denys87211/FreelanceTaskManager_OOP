using System;

namespace FreelanceTaskManager.Models
{
    /// <summary>
    /// Проєкт, повернений замовником на доопрацювання.
    /// </summary>
    public sealed class RevisionProject : Project
    {
        public override string ProjectCategory => "На доопрацюванні";

        public override DateTime GetEffectiveDeadline()
        {
            return RevisionDeadline ?? Deadline;
        }
    }
}
