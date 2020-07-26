using AutoMapper;
using Core.DTOs;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AdvertsManager : ManagerBase
    {
        private IAdvertsRepository advertsRepository;

        public AdvertsManager(IAdvertsRepository advertsRepository, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void Add(AdvertDto advertDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AdvertDto, Advert>()
                   .ForMember(ad => ad.Title, opt => opt.MapFrom(cur => cur.Title))
                   .ForMember(ad => ad.Description, opt => opt.MapFrom(cur => cur.Description))
                   .ForMember(ad => ad.PublishDate, opt => opt.MapFrom(cur => cur.PublishDate))
                   .ForMember(ad => ad.User.Id, opt => opt.MapFrom(cur => cur.UserId))
               );

            var mapper = new Mapper(config);
            Advert advert = mapper.Map<AdvertDto, Advert>(advertDto);

            this.advertsRepository.Add(advert);
        }
    }
}
