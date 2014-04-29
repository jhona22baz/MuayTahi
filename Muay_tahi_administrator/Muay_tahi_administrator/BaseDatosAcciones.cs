using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muay_tahi_administrator
{
    class BaseDatosAcciones
    {
        FigthersEntities db;
        public Alumno other { get; set; }

        public bool SearchAlumn(int id) 
        {
            try
            {
                db = new FigthersEntities();
                Alumno alumn = db.Alumno.FirstOrDefault(a=>a.Id == id);
                if (alumn == null)
                {
                    return false;
                }
                else {
                    other = alumn;
                    return true;
                }
            }
            catch
            {             
                return false;
            }            
        }
        public bool AddAlumn(int id, string name, string lastname, Double money, Double debe,DateTime date)
        {
            try
            {
                db = new FigthersEntities();
                Alumno someone = new Alumno();
                someone.Id = id;
                someone.nombre = name;
                someone.apellido = lastname;
                someone.pago = money;
                someone.debe = debe;
                someone.fechaPago = date;
                someone.habilitado = true;
                db.Alumno.Add(someone);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteAlumn(int id)
        {
            try {
                db = new FigthersEntities();
                Alumno someone = db.Alumno.FirstOrDefault(a => a.Id == id);
                
                if (someone == null)
                {
                    return false;
                }
                else {
                    db.Alumno.Remove(someone);
                    db.SaveChanges();
                    return true;
                }
            }
            catch { return false; }            
        }
        public bool Actualizar(int id, string name, string lastname, Double money,Double debe ,DateTime date)
        {
            try {
                db = new FigthersEntities();
                Alumno someone = db.Alumno.FirstOrDefault(a=> a.Id == id);
                someone.nombre = name;
                someone.apellido = lastname;
                someone.pago = money;
                someone.fechaPago = date;
                someone.debe = debe;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
            
        }
    }
}
