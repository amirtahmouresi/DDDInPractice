﻿using DDDInPractice.Logic.Interface.Repository;
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
    public class SnackMachineService : ISnackMachineService
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
            _SnackMachineRepository.Update(model);
            _uow.SaveChanges();
        }
    }
}
