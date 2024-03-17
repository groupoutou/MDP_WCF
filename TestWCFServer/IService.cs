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
        // mode 1 : attribution des role mode 2 : jeu
        string Maj(int ID ,int mode);

        [OperationContract]
        int AskID();
    }
}
