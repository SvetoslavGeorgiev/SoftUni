﻿namespace MilitaryElite.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Models;
    
public interface ILieutenantGeneral
    {
        public IReadOnlyCollection<Private> Privates { get;}
    }
}
