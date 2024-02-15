using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;


namespace TestWCF
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        void Envoie(string name, string msg);

        [OperationContract]
        string Maj();
    }
}
