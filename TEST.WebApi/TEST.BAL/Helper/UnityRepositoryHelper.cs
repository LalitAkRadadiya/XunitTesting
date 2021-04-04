using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEST.DAL;
using TEST.DAL.Repository;
using Unity;
using Unity.Extension;
namespace TEST.BAL.Helper
{
    public class UnityRepositoryHelper : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IPassengerRepository, PassengerRepository>();
        }
    }
}
