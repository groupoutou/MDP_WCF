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
        void Envoie(int ID, string msg);

        [OperationContract]
        string Maj();

        [OperationContract]
        int AskID();
    }
}
