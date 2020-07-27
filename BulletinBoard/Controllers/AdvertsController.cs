using AutoMapper;
using BulletinBoard.Models.Adverts;
using Core.DTOs;
using Core.Interfaces.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BulletinBoard.Controllers
{
    public class AdvertsController : Controller
    {
        private IAdvertsManager advertsManager;

        public AdvertsController(IAdvertsManager advertsManager)
        {
            this.advertsManager = advertsManager;
        }

        public ActionResult Index()
        {
            AdvertDto[] advertDtos = advertsManager.GetAdverts();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<AdvertDto, AdvertResponse>()
                    .ForMember(ad => ad.Id, opt => opt.MapFrom(ar => ar.Id))
                    .ForMember(ad => ad.Title, opt => opt.MapFrom(ar => ar.Title))
                    .ForMember(ad => ad.Description, opt => opt.MapFrom(ar => ar.Description))
                    .ForMember(ad => ad.PublishDate, opt => opt.MapFrom(ar => ar.PublishDate))
                    .ForMember(ad => ad.Id, opt => opt.MapFrom(ar => ar.Id))
                );

            var mapper = new Mapper(config);
            AdvertResponse[] adverts = mapper.Map<AdvertDto[], AdvertResponse[]>(advertDtos);

            return View(adverts);
        }
    }
}