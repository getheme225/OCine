using AutoMapper;

namespace OCine.Common.CommonRepository.Interface
{
    public interface IAutoMapperConfig
    {
        void AutoMapperConfigure<T1>()where T1: Profile, new();

    }
}