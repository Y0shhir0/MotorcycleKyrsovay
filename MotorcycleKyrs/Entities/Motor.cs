using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorcycleKyrs.Entities
{
    internal class Motor
    {
        private static KompanyMotorrrEntities _context;

        public static KompanyMotorrrEntities GetContext()
        {
            if (_context == null)
                _context = new KompanyMotorrrEntities();
            return _context;
        }
    }
}
