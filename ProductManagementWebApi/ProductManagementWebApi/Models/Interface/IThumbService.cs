namespace ProductManagementWebApi.Models.Interface
{
    public interface IThumbService
    {
        public Task<List<Thumb>> GetAllThumbAsync();

    }
}
