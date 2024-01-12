using System;
using System.Data;
using Dapper;

namespace ORM_Dapper
{
	public class DapperDepartmentRepository : IDepartmentRepository
	{

		private readonly IDbConnection _connection;

		public DapperDepartmentRepository(IDbConnection connection)
		{
			_connection = connection;
		}

        public IEnumerable<Department> GetAllDepartments()
        {
			return _connection.Query<Department>("select * from departments;");
        }

        public void InsertDepartment(int id, string newDepartment)
        {
            _connection.Execute("insert into departments (id, name) values (@ id, @departmentname);",
                new { id = id, deparmentname = newDepartment });
        }
    }
}

