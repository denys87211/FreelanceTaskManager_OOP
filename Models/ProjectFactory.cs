using System;

namespace FreelanceTaskManager.Models
{
    /// <summary>
    /// Централізує створення конкретного класу проєкту.
    /// </summary>
    public static class ProjectFactory
    {
        public static Project Create(DateTime? revisionDeadline)
        {
            return revisionDeadline.HasValue
                ? new RevisionProject()
                : new StandardProject();
        }
    }
}
