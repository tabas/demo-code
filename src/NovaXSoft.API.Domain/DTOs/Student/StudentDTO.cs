﻿using System;

namespace NovaXSoft.API.Domain.DTOs.Student
{
    public class StudentDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
