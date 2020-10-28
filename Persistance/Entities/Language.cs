namespace ASP_pl.Persistance.Entities
{
    public class Language : IEntity
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        int IWithId.Id => LanguageId;
    }
}