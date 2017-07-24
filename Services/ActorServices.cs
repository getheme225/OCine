using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CommonComponent.Ninject;
using Ninject;
using OCine.BAL.DTO;
using OCine.BAL.Entity;
using OCine.Common.CommonRepository.Interface;
using OCine.Common.CommonService;
using Services.AutoMapperProfiles;
using Services.Interfaces;

namespace Services
{
    public class ActorServices : BaseService, IActorsServices
    {
        public ActorServices( [Named(ContextualBinding.OcineDb)] IUnitOfWork work, IAutoMapperConfig mapperConfig) : base(work, mapperConfig)
        {
            mapperConfig.AutoMapperConfigure<AutoMapperProfile>();
        }

        public IEnumerable<ActorDto> GetAllActor()
        {
            return GetAll<ActorDto, Actor>();
        }


        public ActorDto CreateActors(ActorDto actor )
        {
            var entity = new Actor
            {
                Name = actor.Name,
                Films = Mapper.Map<ICollection<Films>>(actor.FilmsDto)
                
            };
            Insert(entity);
            Work.Db.SaveChanges();
            return Mapper.Map<ActorDto>(entity);
        }

        public ActorDto UpdateActor(ActorDto actor)
        {
            var IsExist = Exists<Actor>(Mapper.Map<Actor>(actor));
            if (IsExist) return null;
            Update(Mapper.Map<Actor>(actor));
            Work.Db.SaveChanges();
            return actor;
        }
    }
}
