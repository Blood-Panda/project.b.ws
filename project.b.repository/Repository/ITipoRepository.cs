﻿using project.b.entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.b.repository.Repository
{
    public interface ITipoRepository
    {
        List<TipoEntity> ListarTipos();
    }
}
