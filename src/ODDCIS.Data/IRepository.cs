﻿using ODDCIS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ODDCIS.Data
{
    public interface IRepository
    {
        SearchResult GetResult(string query);
    }
}
