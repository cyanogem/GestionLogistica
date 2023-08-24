using GestionLogistica.Abstraction.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLogistica.Abstraction
{
    public interface ICRUDBAL<T>
    {
        ResponseServicesDTO GetById(int id);
        ResponseServicesDTO GetAll();
        ResponseServicesDTO GetAllByPage(int _page, int _countByPage);
        ResponseServicesDTO Save(T entity);
        ResponseServicesDTO Update(T entity);
        ResponseServicesDTO DeleteById(int id);
    }
}
