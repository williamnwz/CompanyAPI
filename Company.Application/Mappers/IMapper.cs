namespace Company.Application.Mappers
{
    public interface IMapper<Dest,Source>
    {
        Dest Convert(Source source);
    }
}
