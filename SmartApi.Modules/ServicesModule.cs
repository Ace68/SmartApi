using Ninject.Modules;
using SmartApi.Persistence.Abstracts;
using SmartApi.Persistence.Repositories;
using SmartApi.Services.Abstracts;
using SmartApi.Services.Concretes;

namespace SmartApi.Modules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISmartApiUnitOfWork>().To<SmartApiUnitOfWork>().InThreadScope();

            this.Bind<IArticoliServices>().To<ArticoliServices>().InThreadScope();

            //this.Bind<INominativiServices>().To<NominativiServices>().InThreadScope();

        }
    }
}