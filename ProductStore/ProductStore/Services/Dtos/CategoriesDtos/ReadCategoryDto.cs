using ProductStore.Services.Dtos.ReadProductDtos;

namespace ProductStore.Services.Dtos.CategoriesDtos
{
    public class ReadCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ReadProductDto> Products { get; set; } = new();
    }
}
