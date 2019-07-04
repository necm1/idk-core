using System;
using System.Collections.Generic;
using System.Text;

namespace IDK.Models
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}
