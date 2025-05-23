﻿using Microsoft.AspNetCore.Mvc.Rendering;
using WISSEN.EDA.Models.Entities;
namespace WISSEN.EDA.Repositories
{
    public interface ICompanyRepository
    {
        Task<Company> GetByIdAsync(int id);
        Task<List<Company>> GetAllAsync();
        Task<string> AddAsync(Company company);
        Task UpdateAsync(Company company);
        Task DeleteAsync(int id);
    }
}
