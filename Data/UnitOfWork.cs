namespace InterstellarApp.Data
{
    public class UnitOfWork
    {
        private readonly MyDbContext _context;

        // Varje repository är en prop. 
        public PlanetRepository PlanetRepo { get; }
        public VisitorRepository VisitRepo { get; }

        public UnitOfWork(MyDbContext context)
        {
            // Alla använder samma context 
            _context = context;
            PlanetRepo = new(context);
            VisitRepo = new(context);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
