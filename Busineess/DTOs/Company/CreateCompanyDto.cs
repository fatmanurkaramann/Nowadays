﻿using Busineess.DTOs.Project;

namespace Busineess.DTOs.Company
{
    public class CreateCompanyDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
