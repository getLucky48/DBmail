using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    public class TypePackage : KernelObject
    {

        public string name { get; set; }

        public TypePackage()
        {

            tableName = "type_package";

            id = Guid.NewGuid();
            name = string.Empty;

        }

        public override string prepare_query_select()
        {

            string query = " select id, name ";

            return query;

        }

        public override void Save()
        {

            string query = $@"

                insert into {tableName}(id, name) values ('{id}', '{name}')

                on conflict (id) do 
                update set name = '{name}';

            ";

            DBUtils.execQuery(query);

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {

            if (reader["id"] != null)
                this.id = Guid.Parse(reader["id"].ToString());

            if (reader["name"] != null)
                this.name = reader["name"].ToString();

        }

    }

}
