using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    public class Employee : KernelObject
    {

        public Employee()
        {

            id = Guid.NewGuid();
            tableName = "employee";

        }

        public override string prepare_query_select()
        {

            string query = @" select 

                surname, 
                phone_number

            ";

            return query;

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
