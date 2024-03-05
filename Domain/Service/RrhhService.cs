using Legajos.Domain.Model;
using Legajos.Repository;
using Microsoft.IdentityModel.Tokens;

namespace Legajos.Domain.Service
{
    public class RrhhService
    {
       
        public async Task<int> SavePerson(Rrhh rrhhmodel)
        {
            VerifyDataExist(rrhhmodel);

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = await dapperRepository.AddPerson(rrhhmodel.Legajo, rrhhmodel.Nombre, rrhhmodel.Nivel, rrhhmodel.Passwd,
                                                            rrhhmodel.Cuil, rrhhmodel.If_Activo, rrhhmodel.If_Del, rrhhmodel.F_Alta);
            return resultdapper;
        }

        public async Task<int> UnsubscribePerson(int legajo)
        {

            if (legajo == 0)
                throw new ArgumentException($"'Debe ingresar un legajo válido para actualizar", nameof(legajo));

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = await dapperRepository.UnsubscribePerson(legajo);
            return resultdapper;

        }
        public async Task<int> SubscribePerson(int legajo)
        {

            if (legajo == 0)
                throw new ArgumentException($"'Debe ingresar un legajo válido para actualizar", nameof(legajo));

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = await dapperRepository.SubscribePerson(legajo);
            return resultdapper;

        }


        public async Task<int> UpdatePerson(Rrhh rrhhmodel)
        {
            VerifyDataExist(rrhhmodel);

            RrhhDapperRepository dapperRepository = new RrhhDapperRepository();
            var resultdapper = await dapperRepository.UpdatePerson(rrhhmodel.Legajo, rrhhmodel.Nombre, rrhhmodel.Nivel, rrhhmodel.Passwd,
                                                            rrhhmodel.Cuil);
            return resultdapper;
        }

        private static void VerifyDataExist(Rrhh rrhhmodel)
        {
            if (rrhhmodel.Legajo == 0)
                throw new ArgumentException($"'No se puede agregar una persona con legajo igual a 0", nameof(rrhhmodel.Legajo));
            
            if (rrhhmodel.Nombre.IsNullOrEmpty())
                throw new ArgumentException($"'No se puede agregar una persona sin nombre", nameof(rrhhmodel.Nombre));
            if (rrhhmodel.Cuil.IsNullOrEmpty())
                throw new ArgumentException($"'No se puede agregar una persona sin cuil", nameof(rrhhmodel.Cuil));
            
            if (rrhhmodel.Nivel == 0)
                throw new ArgumentException($"'Debe asignarse un nivel a la persona", nameof(rrhhmodel.Nivel));
        }
    }
}
