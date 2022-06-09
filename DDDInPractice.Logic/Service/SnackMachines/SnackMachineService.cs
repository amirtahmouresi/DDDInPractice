using DDDInPractice.Logic.Interface.Repository;
using DDDInPractice.Logic.Interface.Repository.SnackMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Service.SnackMachines
{
    public interface ISnackMachineService
    {
        SnackMachine Get();
        void Edit(SnackMachine model);
    }
    public class SnackMachineService : ISnackMachineService, IDisposable
    {
        private readonly IUnitOfWork _uow;
        private readonly ISnackMachineRepository _SnackMachineRepository;

        public SnackMachineService(IUnitOfWork uow, ISnackMachineRepository snackMachineRepository)
        {
            _uow = uow;
            _SnackMachineRepository = snackMachineRepository;
        }

        public SnackMachine Get()
        {
            return _SnackMachineRepository.Get()
                .Include(x => x.Slots)
                .ThenInclude(x => x.SnackPile.Snack)
                .First();
        }

        public void Edit(SnackMachine model)
        {
            _SnackMachineRepository.Update(model)
                .UpdateOwnedEntity(x => x.MoneyInside)
                .UpdateRelations(x => x.Slots)
                .UpdateInnerOwnedEntity(x => x.Slots, x => x.SnackPile);
            var savedCount = _uow.SaveChanges();
        }

        public void Dispose()
        {
            _uow.Dispose();
        }
    }
}
