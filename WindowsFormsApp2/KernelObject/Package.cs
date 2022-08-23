using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2.KernelObject
{
    public class Package : KernelObject
    {

        public string sender { get; set; }
        public string start_point { get; set; }
        public string recipient { get; set; }
        public string finish_point { get; set; }
        public float weight { get; set; }
        public float pay { get; set; }
        public int start_point_index { get; set; }
        public int finish_point_index { get; set; }
        public Guid type_package_id { get; set; }

        public Package()
        {

            tableName = "package";

            id = Guid.NewGuid();
            sender = string.Empty;
            start_point = string.Empty;
            recipient = string.Empty;
            finish_point = string.Empty;
            weight = 0.0f;
            pay = 0.0f;
            start_point_index = 0;
            finish_point_index = 0;
            type_package_id = Guid.Empty;

        }

        public override string prepare_query_select()
        {

            string query = @" select 

                id,
                sender, 
                start_point, 
                recipient, 
                finish_point, 
                weight, 
                pay, 
                start_point_index, 
                finish_point_index,
                type_package_id

            ";

            return query;

        }

        public override void Save()
        {

            string query = $@"

                insert into {tableName}(
                    id,
                    sender, 
                    start_point, 
                    recipient, 
                    finish_point, 
                    weight, 
                    pay, 
                    start_point_index, 
                    finish_point_index, 
                    type_package_id
                ) 
                values (
                    '{id}',
                    '{sender}', 
                    '{start_point}', 
                    '{recipient}', 
                    '{finish_point}', 
                    '{weight.ToString().Replace(",", ".")}', 
                    '{pay.ToString().Replace(",", ".")}', 
                    '{start_point_index}', 
                    '{finish_point_index}', 
                    '{type_package_id}'
                )

                on conflict (id) do 
                update set 
                    sender = '{sender}', 
                    start_point = '{start_point}', 
                    recipient = '{recipient}', 
                    finish_point = '{finish_point}', 
                    weight = {weight.ToString().Replace(",", ".")}, 
                    pay = {pay.ToString().Replace(",", ".")}, 
                    start_point_index = '{start_point_index}', 
                    finish_point_index = '{finish_point_index}',
                    type_package_id = '{type_package_id}';
            ";

            DBUtils.execQuery(query);

        }

        protected override void FillByReader(NpgsqlDataReader reader)
        {

            if (reader["id"] != null)
                id = Guid.Parse(reader["id"].ToString());

            if (reader["sender"] != null)
                sender = reader["sender"].ToString();

            if (reader["start_point"] != null)
                start_point = reader["start_point"].ToString();

            if (reader["recipient"] != null)
                recipient = reader["recipient"].ToString();

            if (reader["finish_point"] != null)
                finish_point = reader["finish_point"].ToString();

            if (reader["weight"] != null)
                weight = float.Parse(reader["weight"].ToString());

            if (reader["pay"] != null)
                pay = float.Parse(reader["pay"].ToString());

            if (reader["start_point_index"] != null)
                start_point_index = int.Parse(reader["start_point_index"].ToString());

            if (reader["finish_point_index"] != null)
                finish_point_index = int.Parse(reader["finish_point_index"].ToString());

            if (reader["type_package_id"] != null)
                type_package_id = Guid.Parse(reader["type_package_id"].ToString());

        }

    }

}
