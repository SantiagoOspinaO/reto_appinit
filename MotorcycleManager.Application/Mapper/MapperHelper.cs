using AutoMapper;
using MotorcycleManager.Application.Motorcycles.Request;
using MotorcycleManager.Domain.Models;

namespace MotorcycleManager.Application.Mapper
{
    public class MapperHelper
    {
        public static MapperHelper Instance { get; } = new MapperHelper();

        public IMapper GetConfigureMapper()
        {
            var config = new MapperConfiguration(conf =>
            {
                conf.CreateMap<MotorcycleEntity, MotorcycleRequest>().ReverseMap();
                conf.CreateMap<MotorcycleEntity, MotorcycleRequest>().ReverseMap();
            });
            return config.CreateMapper();
        }
    }
}
