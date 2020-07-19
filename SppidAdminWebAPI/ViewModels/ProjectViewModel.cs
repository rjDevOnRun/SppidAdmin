using SppidAdminDTO.Models;
using SppidAdminWebAPI.DataRepository;
using SppidAdminWebAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace SppidAdminWebAPI.ViewModels
{
    public class ProjectViewModel
    {
        public static List<Project> GetProjects()
        {
            DataTable dt = ProjectRepository.GetProjectsFromDatabase();

            List<Project> projects = new List<Project>();

            projects = AssemblyHelpers.ConvertDataTable<Project>(dt);

            return projects;
        }
    }
}