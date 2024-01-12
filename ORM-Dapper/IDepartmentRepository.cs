using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
        public IEnumerable<Department> GetAllDepartments();
        public void InsertDepartment(int id, string newDepartment);
    }
}

