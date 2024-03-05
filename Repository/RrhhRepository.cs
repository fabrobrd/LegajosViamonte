using Legajos.Domain.Repository;

namespace Legajos.Repository
{
    public class RrhhRepository
    {
        private readonly Irrhh rrhhrepository;

        public RrhhRepository()
        {
            rrhhrepository = new RrhhDapperRepository();
        }
    }
}
