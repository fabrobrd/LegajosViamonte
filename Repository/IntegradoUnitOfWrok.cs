using Dapper;
using System.Runtime.CompilerServices;

namespace Legajos.Repository
{
    public class IntegradoUnitOfWrok
    {
        public IntegradoUnitOfWrok()
        {
            SqlMapper.AddTypeHandler(new TrimmedStringHandler());
        }

    }
}
