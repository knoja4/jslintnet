﻿namespace EnvDTE
{
    using System;
    using EnvDTE80;

    internal static class ProjectsExtensions
    {
        public static Project FindByUniqueName(this Projects projects, string uniqueName)
        {
            foreach (Project project in projects)
            {
                Project match;

                if (TryFindByUniqueName(project, uniqueName, out match))
                {
                    return match;
                }
            }

            return null;
        }

        private static bool TryFindByUniqueName(Project project, string uniqueName, out Project match)
        {
            if (project.Kind != ProjectKinds.vsProjectKindSolutionFolder && project.UniqueName.Equals(uniqueName, StringComparison.OrdinalIgnoreCase))
            {
                match = project;
                return true;
            }

            foreach (ProjectItem item in project.ProjectItems)
            {
                if (item.SubProject != null && TryFindByUniqueName(item.SubProject, uniqueName, out match))
                {
                    return true;
                }
            }

            match = null;
            return false;
        }
    }
}
