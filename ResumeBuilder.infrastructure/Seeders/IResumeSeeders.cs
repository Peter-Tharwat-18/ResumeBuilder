﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeBuilder.Infrastructure.Seeders
{
  public interface IResumeSeeders
    {
       Task Seed();
    }
}
