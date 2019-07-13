using System.Linq;
using Abp.Application.Editions;
using TestApp.Editions;
using TestApp.EntityFramework;

namespace TestApp.Migrations.SeedData
{
    public class DefaultEditionsCreator
    {
        private readonly TestAppDbContext _context;

        public DefaultEditionsCreator(TestAppDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateEditions();
        }

        private void CreateEditions()
        {
            var defaultEdition = _context.Editions.FirstOrDefault(e => e.Name == EditionManager.DefaultEditionName);
            if (defaultEdition == null)
            {
                defaultEdition = new Edition { Name = EditionManager.DefaultEditionName, DisplayName = EditionManager.DefaultEditionName };
                _context.Editions.Add(defaultEdition);
                _context.SaveChanges();

                //TODO: Add desired features to the standard edition, if wanted!
            }   
        }
    }
}