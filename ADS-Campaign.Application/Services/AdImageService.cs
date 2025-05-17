using ADS_Campaign.Application.DTOs.AdImage;
using ADS_Campaign.Application.Interfaces;
using ADS_Campaign.Application.Mapper;
using ADS_Campaign.Domain;

namespace ADS_Campaign.Application.Services
{
    public class AdImageService : IAdImageService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AdImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(AddAdImageDto imageDto)
        {
            await _unitOfWork.AdImageRepository.AddAsync(imageDto.Factory());
            await _unitOfWork.Save();
        }
    }
}
