using Common.Entities;
using DataAccess.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.BOL
{
    public class ClientBol
    {
        //Instances
        private ClientDal _clientDal = new ClientDal();
        public readonly StringBuilder stringBuilder = new StringBuilder();
        //Methods

        public void Registrate(Client client)
        {
            if (ValidateClient(client))
            {
                if (_clientDal.GetByid(client.IdClient) == null)
                {
                    _clientDal.Insert(client);
                }
                else
                {
                    _clientDal.Update(client);
                }
            }
        }

        public List<Client> GetClients()
        {
            return _clientDal.GetAll();
        }

        public List<Client> GetByName(string description)
        {
            return _clientDal.GetByName(description);
        }

        public Client GetById(Int64 idClient)
        {
            stringBuilder.Clear();

            if (idClient == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                return _clientDal.GetByid(idClient);
            }
            return null;
        }

        public void Delete(Int64 idClient)
        {
            stringBuilder.Clear();

            if (idClient == 0) stringBuilder.Append("Por favor proporcione un valor de Id valido");

            if (stringBuilder.Length == 0)
            {
                _clientDal.Delete(idClient);
            }
        }

        private bool ValidateClient(Client client)
        {
            stringBuilder.Clear();
            if (string.IsNullOrEmpty(client.IdClient.ToString())) stringBuilder.Append("El campo Dni es obligatorio");
            if (string.IsNullOrEmpty(client.FirstName)) stringBuilder.Append(Environment.NewLine + "El campo Apellido es obligatorio");
            if (string.IsNullOrEmpty(client.LastName)) stringBuilder.Append(Environment.NewLine + "El campo Nombre es obligatorio");
            return stringBuilder.Length == 0;
        }
    }
}
