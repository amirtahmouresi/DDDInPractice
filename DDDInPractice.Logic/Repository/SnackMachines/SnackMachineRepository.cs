using DDDInPractice.Logic.Context;
using DDDInPractice.Logic.Interface.Repository.SnackMachines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDInPractice.Logic.Repository.SnackMachines
{
    public class SnackMachineRepository : GenericRepository<SnackMachine>, ISnackMachineRepository
    {
        public SnackMachineRepository(ApplicationDBContext context) : base(context)
        {
        }
    }
}
