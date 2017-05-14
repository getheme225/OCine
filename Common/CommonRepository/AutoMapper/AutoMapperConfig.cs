using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AutoMapper;
using OCine.Common.CommonRepository.Interface;

namespace OCine.Common.CommonRepository.AutoMapper
{
   public class AutoMapperConfig:IAutoMapperConfig
    {
        public void AutoMapperConfigure<T1>() where T1 : Profile, new()
        {
           Mapper.Initialize(cfg => cfg.AddProfile(new T1()));
        }
    }
}
