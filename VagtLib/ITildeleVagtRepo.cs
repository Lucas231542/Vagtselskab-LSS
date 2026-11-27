using System;
using System.Collections.Generic;
using System.Text;

namespace VagtLib
{
    public interface ITildeleVagtRepo
    {
        List<Vagt> HentMineVagter(int brugerId);
    }
}
