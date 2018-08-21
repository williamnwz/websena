using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebSena.Repository
{
    public interface IUnityOfWork : IDisposable
    {
        void Commit();

        void Rollback();
    }
}
