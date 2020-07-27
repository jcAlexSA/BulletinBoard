using AutoMapper;
using Core.DTOs;
using Core.Interfaces.Managers;
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
    public class AdvertsManager : ManagerBase, IAdvertsManager
    {
        private IAdvertsRepository advertsRepository;

        public AdvertsManager(IAdvertsRepository ar, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            this.advertsRepository = ar;
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

        public AdvertDto[] GetAdverts()
        {
            Advert[] adverts = this.advertsRepository.GetAdverts();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Advert, AdvertDto>()
                   .ForMember(a => a.Title, opt => opt.MapFrom(ad => ad.Title))
                   .ForMember(a => a.Description, opt => opt.MapFrom(ad => ad.Description))
                   .ForMember(a => a.PublishDate, opt => opt.MapFrom(ad => ad.PublishDate))
                   .ForMember(a => a.UserId, opt => opt.MapFrom(ad => ad.User.Id))
               );

            var mapper = new Mapper(config);
            AdvertDto[] advertDtos = mapper.Map<Advert[], AdvertDto[]>(adverts);

            return advertDtos;
        }
    }
}
