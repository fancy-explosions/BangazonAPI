﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BangazonAPI.Models
{
    public class Employee
    {

        public int Id { get; set; }

        public int DepartmentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool isSupervisor { get; set; }

        public List<TrainingProgram> TrainingPrograms { get; set; } = new List<TrainingProgram>();
    }
}