namespace STPGroup.Services.Infrastructure
{
    using AutoMapper;
    using STPGroup.Services.Infrastructure.Interfaces;

    public class MapperService : IMapperService
    {
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            var result = Mapper.Map<TDestination>(source);

            return result;
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            var result = Mapper.Map(source, destination);

            return result;
        }
    }
}
