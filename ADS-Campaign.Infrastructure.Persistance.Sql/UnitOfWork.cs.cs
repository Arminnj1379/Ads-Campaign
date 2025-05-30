﻿using ADS_Campaign.Domain;
using ADS_Campaign.Domain.Entities.AdImages;
using ADS_Campaign.Domain.Entities.Ads;
using ADS_Campaign.Domain.Entities.ApplicationUser;
using ADS_Campaign.Domain.Entities.Categories;

namespace ADS_Campaign.Infrastructure.Persistance.Sql
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IUserRepository UserRepository { get; }
        public IAdRepository AdRepository { get; }
        public ICategoryRepository CategoryRepository { get; }
        public IAdImageRepository AdImageRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IUserRepository userRepository, IAdRepository adRepository, ICategoryRepository categoryRepository, IAdImageRepository adImageRepository)
        {
            _context = context;
            UserRepository = userRepository;
            AdRepository = adRepository;
            CategoryRepository = categoryRepository;
            AdImageRepository = adImageRepository;
        }
        public async Task<int> Save() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();

    }
}
