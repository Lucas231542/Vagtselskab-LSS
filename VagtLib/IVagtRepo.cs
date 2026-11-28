using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public interface IVagtRepo
    {
        public void Add(Vagt vagt);
        public void Update(Vagt vagt);
        public void Delete(int vagtId);
        public Vagt GetById(int vagtId);

    }
}
