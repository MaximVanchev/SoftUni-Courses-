﻿using FastFood.Core.ViewModels.Employees;
using FastFood.Services.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastFood.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Register(RegisterEmployeesDto dto);

        ICollection<ListAllEmployeeDto> All();
    }
}
