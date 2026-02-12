namespace CQRSProject.CQRSPattern.Queries.CategoryQueries
{
    public class GetCategoriesByIdQuery
    {
        public int Id { get; set; }

        public GetCategoriesByIdQuery(int id)
        {
            Id = id;
        }
    }
}
