﻿using Microsoft.EntityFrameworkCore;
using shopecommerce.Domain.Commons;
using shopecommerce.Domain.Entities;
using shopecommerce.Domain.Interfaces;
using shopecommerce.Infrastructure.Data;

namespace shopecommerce.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EcommerceContext _context;
    public IUnitOfWork UnitOfWork => _context;

    public UserRepository(EcommerceContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<Users> GetByIdAsync(string id)
    {
        return (await _context.Users.FirstOrDefaultAsync(x => Equals(BaseGuidEx.GetGuid(id), BaseGuidEx.GetGuid(x.id))))!;
    }

    public async Task<Users> AddAsync(Users entity)
    {
        return (await _context.AddAsync(entity)).Entity;
    }

    public async Task UpdateAsync(Users entity)
    {
        _context.Update(entity);
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(Users entity)
    {
        _context.Remove(entity);
        await Task.CompletedTask;
    }
}