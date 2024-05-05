using System;
using JAbarcaS5.Models;
using SQLite;

namespace JAbarcaS5
{
	public class PersonRepository
	{
		string _dbPath;
		private SQLiteConnection conn;
		public PersonRepository(string dbPath)
		{
			_dbPath = dbPath;
		}
		public string StatusMessage  { get; set;}
		private void Init() {
			if (conn is not null) 
				return;
			conn = new(_dbPath);
			conn.CreateTable<Persona>();
			
		}
		public void AddNewPerson(string name) {
			int result = 0;
			try
			{
				Init();
				if (string.IsNullOrEmpty(name)) {
					throw new Exception("Nombre es Requerido");
				}
				Persona person = new() { Name = name };
                result = conn.Insert(person);
				StatusMessage = string.Format("Exito al insertar una persona",result,name);

            }
			catch (Exception ex)
			{
				StatusMessage = string.Format("Error al insertar una persona", name,ex.Message);
			}
		}
        public void EditPerson(string name, string id)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Nombre es Requerido");
                }
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("ID es requerido");
                }
                int valId = int.Parse(id);
                // Buscar la persona por su ID
                Persona person = conn.Table<Persona>().FirstOrDefault(p => p.Id == valId);
                if (person != null)
                {
                    // Actualizar el nombre
                    person.Name = name;

                    // Realizar la actualización en la base de datos
                    result = conn.Update(person);

                    if (result > 0)
                    {
                        StatusMessage = string.Format("Persona actualizada exitosamente: {0}", name);
                    }
                    else
                    {
                        StatusMessage = string.Format("No se pudo actualizar la persona: {0}", name);
                    }
                }
                else
                {
                    StatusMessage = string.Format("No se encontró ninguna persona con el ID: {0}", id);
                }
               /* result = conn.Insert(person);
                StatusMessage = string.Format("Exito al insertar una persona", result, name);*/

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al actualizar la persona: {0}", ex.Message);
            }
        }

        public void DropPerson(string id)
        {
            int result = 0;
            try
            {
                Init();
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("Nombre es Requerido");
                }
                if (string.IsNullOrEmpty(id))
                {
                    throw new Exception("ID es requerido");
                }
                int valId = int.Parse(id); 
                // Buscar la persona por su ID
                Persona person = conn.Table<Persona>().FirstOrDefault(p => p.Id == valId);
                if (person != null)
                {
                    // Eliminar la persona de la base de datos
                    result = conn.Delete(person);

                    if (result > 0)
                    {
                        StatusMessage = string.Format("Persona eliminada exitosamente");
                    }
                    else
                    {
                        StatusMessage = string.Format("No se pudo eliminar la persona");
                    }
                }
                else
                {
                    StatusMessage = string.Format("No se encontró ninguna persona con el ID: {0}", id);
                }

            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Error al eliminar la persona: {0}", ex.Message);
            }
        }

        public List<Persona> getAllPeople() { 

			try {
				Init();
				return conn.Table<Persona>().ToList();
			} catch (Exception ex) {
                StatusMessage = string.Format("Error al Listar Personas", ex.Message);

            }
			return new List<Persona>();

        }
		
	}

}

